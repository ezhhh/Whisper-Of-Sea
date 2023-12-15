using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAgent : MonoBehaviour
{
    private Transform _transform;

    private void Start()
    {
        _transform = transform; 
    }

    private void Update()
    {
        _transform.Translate(_transform.forward * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        _transform.Rotate(0, Random.Range(-2.0f, 2.0f), 0);
    }
}
