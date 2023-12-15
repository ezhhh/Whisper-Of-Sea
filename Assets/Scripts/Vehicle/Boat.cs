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

        Vector3 moveVector = _speed * moveAxis * Time.deltaTime * transform.forward;
        Quaternion turnQuaternion = Quaternion.Euler(0f, turnAxis * _turnSpeed * Time.deltaTime, 0f);

        _rb.MovePosition(_rb.position + moveVector);
        _rb.MoveRotation(_rb.rotation * turnQuaternion);
    }

    private void FixedUpdate()
    {
        if (!IsAboveWater())
        {
            _rb.useGravity = true;
            return;
        }

        _rb.useGravity = false;
        _rb.AddForce(_waterPush * Vector3.up, ForceMode.Impulse);
    }

    private bool IsAboveWater()
    {
        return Physics.Raycast(transform.position, Vector3.down, 0.35f,GameManager.Instance.WaterLayer);
    }
}
