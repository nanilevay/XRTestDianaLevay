using UnityEngine;

/// <summary>
/// Tilt the city based on mouse input and an applied torque force
/// </summary>
public class CityTilt : MonoBehaviour
{
    // Get rigidbody from object
    private Rigidbody rb;

    // Force to be applied with torque
    [SerializeField]
    private float _tiltForce = 10;

    // Force to be applied with torque
    [SerializeField]
    private float _spinForce = 10;

    // To fine tune mouse sensitivity
    [SerializeField]
    private float sensitivity = 0.08f;

    // Speed at which the object will return to original rotation
    [SerializeField]
    private float _returnSpeed = 0.08f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0, -4, 0);
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

    // Apply torque forces to the city based on user input
    public void ApplyTorqueHorizontal(float Direction)
    {
        rb.AddTorque(transform.forward * Direction * sensitivity * _tiltForce, ForceMode.Impulse);
    }

    public void ApplyTorqueVertical(float Direction)
    {

        rb.AddTorque(transform.up * Direction * sensitivity * _spinForce, ForceMode.VelocityChange);
    }
}