using UnityEngine;

public class CityShake : MonoBehaviour
{
    // Get rigidbody to apply physics
    private Rigidbody rb;

    // Set the speed of shake - to be finetuned
    [SerializeReference]
    private float Speed = 7;

    // Set the maximum speed at which shake happens
    [SerializeField]
    public float MaxSpeed = 10;

    // Strength of the force applied to the object
    [SerializeField]
    private float forceStrength = 1;

    // Check whether object is shaking or not
    public bool _isShaking;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_isShaking)
        {
            // Add force to shake city back and forth horizontally - to be fine tuned
            rb.AddForce(transform.forward  * Mathf.Sin(Time.time * Speed) * forceStrength, 0);
        }
    }
}