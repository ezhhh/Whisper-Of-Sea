using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class LocalPlayer : MonoBehaviour
{
    [Header("Player Meta")]
    [SerializeField] private float _baseSpeed = 6.0f;
    [SerializeField] private float _jumpForce = 4.0f;

    [Space, Header("Modifiers")]
    [SerializeField] private float _runModifier = 1.5f;
    [SerializeField] private float _crouchModifier = 0.5f;

    [HideInInspector] public AbstractInteractable PointedObject;

    [SerializeField] private Transform _meshTransform;

    private readonly float RotationSpeed = 360.0f;

    private bool _isRowingBoat = false;

    public bool RowingBoat { get => _isRowingBoat; set => _isRowingBoat = value; }

    private CharacterController _controller;
    private CameraFollow _cameraFollow;
    private Vector3 _velocity;

    public enum MovementState
    {
        Idle,
        Walking,
        Running,
        Crouching,
        Rowing,
        Swimming
    }

    public MovementState CurrentMovementState { get; set; } = MovementState.Idle;

    private void Start() {
        _controller = GetComponent<CharacterController>();
        _cameraFollow = Camera.main.gameObject.GetComponent<CameraFollow>();
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void FixedUpdate() { UpdatePointedObject(); }

    public void Jump()
    {
        if (CurrentMovementState == MovementState.Rowing)
        {
            return;
        }

        if (IsGrounded && _velocity.y < 0) _velocity.y = -2f;

        if (IsGrounded && GameSettings.Instance.IsDown(GameSettings.Instance.JumpKey))
            _velocity.y = Mathf.Sqrt(_jumpForce * -2f * Physics.gravity.y);

        
        _velocity.y += Physics.gravity.y * Time.deltaTime;
        
        _controller.Move(_velocity * Time.deltaTime);
    }

    private void HandleMovementStates(Vector3 movement)
    {
        if (GameSettings.Instance.IsDown(GameSettings.Instance.RunKey))
        {
            CurrentMovementState = MovementState.Running;
        }
        else if (GameSettings.Instance.IsDown(GameSettings.Instance.CrouchKey))
        {
            CurrentMovementState = MovementState.Crouching;
        }
        else if (movement.magnitude > 0f)
        {
            CurrentMovementState = MovementState.Walking;
        }
        else if (_isRowingBoat)
        {
            CurrentMovementState = MovementState.Rowing;
        }
        else
        {
            CurrentMovementState = MovementState.Idle;
        }
    }

    public void Move()
    {
        if (CurrentMovementState == MovementState.Rowing)
        {
            return;
        }

        float horizontalInput = GameSettings.Instance.ReadAxis("Horizontal");
        float verticalInput = GameSettings.Instance.ReadAxis("Vertical");

        Vector3 moveDirection = Quaternion.Euler(0, _cameraFollow.yaw, 0) * new Vector3(horizontalInput, 0f, verticalInput).normalized;

        HandleMovementStates(moveDirection);

        float speedModifier = 1.0f;

        switch (CurrentMovementState)
        {
            case MovementState.Running:
                speedModifier = _runModifier;
                break;
            case MovementState.Crouching:
                speedModifier = _crouchModifier;
                break;
        }

        if (CurrentMovementState != MovementState.Idle && moveDirection.magnitude > Mathf.Epsilon)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection * -1, Vector3.up);
            _meshTransform.rotation = Quaternion.RotateTowards(_meshTransform.rotation, toRotation, RotationSpeed * Time.deltaTime);
        }

        _controller.Move(speedModifier * _baseSpeed * Time.deltaTime * moveDirection);
    }

    private void UpdatePointedObject()
    {
        if (Physics.Raycast(EyePosition(), _cameraFollow.transform.forward, out RaycastHit hit, ReachDistance()))
        {
            GameObject rayTraceResult = hit.transform.gameObject;
            PointedObject = rayTraceResult.TryGetComponent<AbstractInteractable>(out var interactable)
                ? interactable
                : null;
        }
        else { PointedObject = null; }

        if (PointedObject != null)
        {
            if (GameSettings.Instance.IsPressed(GameSettings.Instance.InteractKey))
            {
                PointedObject.Interact(this);
            }
            else if (GameSettings.Instance.IsPressed(GameSettings.Instance.BestiariyKey))
            {
                if (PointedObject.TryGetComponent<BestiariyInteract>(out var x))
                {
                    x.ShowBestiariy();
                }
            }
        }
    }

    public void UpdateScore()
    {
        GameManager.Instance.score++;
    }

    public bool IsSwimming()
    {
        return CurrentMovementState == MovementState.Swimming;
    }

    public float EyeHeight() { return 1.8f; }

    public Vector3 EyePosition() { return _meshTransform.position + Vector3.up * EyeHeight(); }

    public float ReachDistance() { return 7.5f; }

    private bool IsGrounded { get => _controller.isGrounded; }
}
