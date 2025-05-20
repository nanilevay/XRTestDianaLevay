using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityTilt : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField]
    private float _forceStrength = 10;

    private Vector2 _mouseMovement;

    [SerializeField]
    private float _maxAngularVelocity = 10f;

    [SerializeField]
    private Vector3 _inertia = new Vector3(2,2,2);

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = Vector3.zero;
        rb.inertiaTensor = _inertia;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _mouseMovement.x = Input.GetAxis("Mouse X");
            _mouseMovement.y = Input.GetAxis("Mouse Y");

        }

        if (Input.GetMouseButtonUp(0))
        {
            _mouseMovement.x = 0;
            _mouseMovement.y = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.rotation.z <= 0.1f && transform.rotation.z >= -0.1f)
        {
            rb.AddTorque(transform.forward * _mouseMovement.x * _forceStrength, ForceMode.VelocityChange);
            rb.angularVelocity = Vector3.ClampMagnitude(rb.angularVelocity, _maxAngularVelocity);
        }
    }
}