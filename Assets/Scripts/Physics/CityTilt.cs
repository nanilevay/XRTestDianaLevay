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
    private float _forceStrength = 10;

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
        rb.centerOfMass = Vector3.zero;
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            PhysicsOn = true;
            rb.isKinematic = false;
            _mouseMovement.x = Input.GetAxis("Mouse X") * sensitivity;
            _mouseMovement.y = Input.GetAxis("Mouse Y") * sensitivity;     
        }

        if (Input.GetMouseButtonUp(0))
        {
            PhysicsOn = false;
            rb.isKinematic = true;
            _mouseMovement.x = 0;
            _mouseMovement.y = 0;
        }
    }

    private void FixedUpdate()
    {
        if (PhysicsOn)
            ApplyTorque();

        else
            ReturnToOrigin();
    }

    /// <summary>
    /// Return the city back to its original setup - still fine tuning solution with physics
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
        rb.AddTorque(transform.forward * _mouseMovement.x * _forceStrength, ForceMode.VelocityChange);

        rb.AddTorque(transform.up * _mouseMovement.y * _forceStrength, ForceMode.VelocityChange);
    }
}