using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    private Rigidbody _rigidbody;

    [SerializeField] private float _speed;
    [SerializeField] private float _angleSpeed;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 moveVelocity = transform.forward * (Input.GetAxis("Vertical") * _speed);

        float angleSpeed = Input.GetAxis("Horizontal") * _angleSpeed;

        Quaternion angle = Quaternion.Euler(_rigidbody.rotation.x, angleSpeed + _rigidbody.rotation.eulerAngles.y, _rigidbody.rotation.z);

        _rigidbody.AddForce(moveVelocity);
        _rigidbody.rotation = Quaternion.Lerp(_rigidbody.rotation, angle, Time.fixedDeltaTime * _speed / 5);
    }
}
