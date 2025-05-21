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
    private float _tilForce = 10;

    // Force to be applied with torque
    [SerializeField]
    private float _spinForce = 10;

    // To store the x and y axis inputs 
    private Vector2 _mouseMovement;

    // To fine tune mouse sensitivity
    [SerializeField]
    private float sensitivity = 0.08f;

    // Speed at which the object will return to original rotation
    [SerializeField]
    private float _returnSpeed = 0.08f;

    // testing - change later
    public bool PhysicsOn = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0, -4, 0);
        PhysicsOn = true;
        rb.isKinematic = false;
    }
    private void Update()
    { 
        _mouseMovement.x = Input.GetAxis("Horizontal");
        _mouseMovement.y = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        if (PhysicsOn)
            ApplyTorque();

        else
            ReturnToOrigin();
    }

    public void TogglePhysics()
    {
        PhysicsOn = !PhysicsOn;
        rb.isKinematic = !rb.isKinematic;
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

    public void ApplyTorque()
    {
        if (PhysicsOn)
        {
            rb.AddTorque(transform.forward * _mouseMovement.x * sensitivity * _tilForce, ForceMode.Impulse);

            rb.AddTorque(transform.up * _mouseMovement.y * sensitivity * _spinForce, ForceMode.VelocityChange);
        }
    }
}