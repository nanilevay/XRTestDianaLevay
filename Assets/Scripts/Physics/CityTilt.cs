using UnityEngine;

/// <summary>
/// This class allows us to tilt the city based on keyboard input 
/// and an applied torque force, as well as rotate it smoothly
/// </summary>
public class CityTilt : MonoBehaviour
{
    // Get rigidbody from object
    private Rigidbody rb;

    // Force to be applied on X axis with torque
    [SerializeField]
    private float _tiltForce = 10;

    // Force to be applied on Y axis with torque
    [SerializeField]
    private float _spinForce = 10;

    // To fine tune desired sensitivity
    [SerializeField]
    private float sensitivity = 0.08f;

    // Speed at which the object will return to original rotation
    [SerializeField]
    private float _returnSpeed = 0.08f;

    void Start()
    {
        // Assign center of mass slightly below grid for a better feel when applying forces
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0, -4, 0);
    }

    // Apply an impulsive torque that tilts the map around itself on the X axis - mass conscious
    public void ApplyTorqueHorizontal(float Direction)
    {
        rb.AddTorque(transform.forward * -Direction * sensitivity * _tiltForce, ForceMode.Impulse);
    }

    // Apply an acceleration that rotates the map around itself on the Y axis - not mass conscious
    public void ApplyTorqueVertical(float Direction)
    {
        rb.AddTorque(rb.transform.position * Direction * sensitivity * _spinForce, ForceMode.Acceleration);
    }

    /// <summary>
    /// Return the city back to its original setup
    /// </summary>
    public void ReturnToOrigin()
    {
        float step = _returnSpeed * Time.deltaTime;

        // Set translation and rotation back towards origin smoothly
        transform.position =
            Vector3.MoveTowards(transform.position, Vector3.zero, step);

        transform.rotation =
            Quaternion.RotateTowards(transform.rotation, Quaternion.identity, step);
    }
}