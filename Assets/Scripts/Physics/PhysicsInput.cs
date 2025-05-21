using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsInput : MonoBehaviour
{
    // To store the x and y axis inputs 
    private float _verticalMovement;
    
    private float _horizontalMovement;

    // Check if physical interactions toggle is on
    public bool PhysicsOn = false;

    [SerializeField]
    private CityTilt _tiltControl;

    // Update is called once per frame
    void Update()
    {
        if (PhysicsOn)
        {
            _horizontalMovement = Input.GetAxis("Horizontal");
            _verticalMovement = Input.GetAxis("Vertical");
        }
    }

    private void FixedUpdate()
    {
        if (PhysicsOn)
        {
            _tiltControl.ApplyTorqueHorizontal(_horizontalMovement);
            _tiltControl.ApplyTorqueVertical(_verticalMovement);
        }

        else
        {
            _tiltControl.ReturnToOrigin(); 
        }
    }

    public void TogglePhysics()
    {
        PhysicsOn = !PhysicsOn;
        _tiltControl.GetComponent<Rigidbody>().isKinematic = !_tiltControl.GetComponent<Rigidbody>().isKinematic;
    }
}