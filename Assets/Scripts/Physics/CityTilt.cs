using UnityEngine;

/// <summary>
/// Tilt the city based on mouse input x,y coordinates
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

    // For magnitude clamping
    [SerializeField]
    private float _maxAngularVelocity = 10f;

    // To fine tune mouse sensitivity
    [SerializeField]
    private float sensitivity = 0.08f;

    // Speed at which the object will return to original rotation
    [SerializeField]
    private float _returnSpeed = 0.08f;

    // testing - change later
    public bool test = false;

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
            test = false;
            rb.isKinematic = false;
            _mouseMovement.x = Input.GetAxis("Mouse X") * sensitivity;
            _mouseMovement.y = Input.GetAxis("Mouse Y") * sensitivity;     
        }

        if (Input.GetMouseButtonUp(0))
        {
            test = true;
            rb.isKinematic = true;
            _mouseMovement.x = 0;
            _mouseMovement.y = 0;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!test)
        {
            rb.AddTorque(transform.forward * _mouseMovement.x * _forceStrength, ForceMode.VelocityChange);

            rb.AddTorque(transform.up * _mouseMovement.y * _forceStrength, ForceMode.VelocityChange);

            rb.angularVelocity = Vector3.ClampMagnitude(rb.angularVelocity, _maxAngularVelocity);
        }

        if (test)
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

}