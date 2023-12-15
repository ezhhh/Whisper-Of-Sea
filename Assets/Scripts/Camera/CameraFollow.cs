using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float distance = 5.0f;
    [SerializeField] private float xSpeed = 250.0f;
    [SerializeField] private float ySpeed = 120.0f;
    [SerializeField] private float yMinLimit = -20;
    [SerializeField] private float yMaxLimit = 80;
    [SerializeField] private float distanceMin = 0.5f;
    [SerializeField] private float distanceMax = 15f;

    public float yaw = 0.0f;
    public float pitch = 0.0f;

    private float targetDistance;

    private const string MouseXAxis = "Mouse X";
    private const string MouseYAxis = "Mouse Y";
    private const string MouseScrollWheel = "Mouse ScrollWheel";

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        InitializeCamera();
    }

    private void InitializeCamera()
    {
        Vector3 angles = transform.eulerAngles;
        yaw = angles.y;
        pitch = angles.x;
        targetDistance = distance;
    }

    private void Update() { HandleInput(); }

    private void LateUpdate()
    {
        if (GameManager.Instance.Player == null || GameManager.Instance.Player.EyePosition() == null) return;

        pitch = NormalizeAngle(pitch, yMinLimit, yMaxLimit);
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        HandleMouseScroll();

        Vector3 position = rotation * new Vector3(0.0f, 0.0f, -targetDistance) + GameManager.Instance.Player.EyePosition();
        transform.SetPositionAndRotation(position, rotation);

        yaw = WrapDegrees(yaw);
    }

    private void HandleInput()
    {
        yaw += GameSettings.Instance.ReadAxis(MouseXAxis) * xSpeed * 0.02f;
        pitch -= GameSettings.Instance.ReadAxis(MouseYAxis) * ySpeed * 0.02f;
    }

    private void HandleMouseScroll()
    {
        distance = Mathf.Clamp(distance - (GameSettings.Instance.ReadAxis(MouseScrollWheel) * 5), distanceMin, distanceMax);
    }

    private float NormalizeAngle(float angle, float min, float max)
    {
        if (angle < -360F) angle += 360F;
        if (angle > 360F) angle -= 360F;

        return Mathf.Clamp(angle, min, max);
    }

    private float WrapDegrees(float value)
    {
        value %= 360.0F;

        if (value >= 180.0F)
        {
            value -= 360.0F;
        }

        if (value < -180.0F)
        {
            value += 360.0F;
        }

        return value;
    }

}