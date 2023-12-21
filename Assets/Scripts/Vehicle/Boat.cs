using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Boat : MonoBehaviour
{
    private Rigidbody _rb;

    private LocalPlayer _localPlayer;

    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _turnSpeed = 10f;
    [SerializeField] private float _waterPush = 0.6f;

    private float _currentSpeed = 0.0f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!_localPlayer)
        {
            _localPlayer = GameManager.Instance.Player;
            return;
        }

        if (!_localPlayer.RowingBoat)
        {
            return;
        }

        float moveAxis = GameSettings.Instance.ReadAxis("Vertical");
        float turnAxis = GameSettings.Instance.ReadAxis("Horizontal");

        _currentSpeed = Mathf.Lerp(_currentSpeed, _speed * moveAxis, 2 * Time.deltaTime);

        Vector3 moveVector = _currentSpeed * Time.deltaTime * transform.forward;
        Quaternion turnQuaternion = Quaternion.Euler(0f, turnAxis * _turnSpeed * Time.deltaTime, 0f);

        _rb.MovePosition(_rb.position + moveVector);
        _rb.MoveRotation(_rb.rotation * turnQuaternion);
    }

    private void FixedUpdate()
    {
      
    }

    private bool IsAboveWater()
    {
        return Physics.Raycast(transform.position, Vector3.down, 0.35f,GameManager.Instance.WaterLayer);
    }
}
