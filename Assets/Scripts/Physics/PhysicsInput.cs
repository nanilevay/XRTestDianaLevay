using UnityEngine;

/// <summary>
/// This class oversees user input regarding the physics component of the game
/// It sends information of each input axis to be used in force calculations 
/// </summary>
public class PhysicsInput : MonoBehaviour
{
    // To store the x and y axis inputs 
    private float _verticalMovement;
    
    private float _horizontalMovement;

    // Check if physical interactions toggle is on
    public bool PhysicsOn = false;

    // To control the city tilt with input
    [SerializeField]
    private CityTilt _tiltControl;

    void Update()
    {
        // Get user input every frame
        if (PhysicsOn)
        {
            _horizontalMovement = Input.GetAxis("Horizontal");
            _verticalMovement = Input.GetAxis("Vertical");
        }
    }

    private void FixedUpdate()
    {
        // Send user input in physics cycle
        if (PhysicsOn)
        {
            _tiltControl.ApplyTorqueHorizontal(_horizontalMovement);
            _tiltControl.ApplyTorqueVertical(_verticalMovement);
        }

        // Return the city to it's original transform configuration
        else
        {
            _tiltControl.ReturnToOrigin(); 
        }
    }

    // To be attached to a toggle and switch physics features on and off in game
    public void TogglePhysics()
    {
        PhysicsOn = !PhysicsOn;
        _tiltControl.GetComponent<Rigidbody>().isKinematic = 
            !_tiltControl.GetComponent<Rigidbody>().isKinematic;
    }
}