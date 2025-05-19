using UnityEngine;

public class CityShake : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeReference]
    private float Speed = 7;

    [SerializeField]
    public float MaxSpeed = 10;

    [SerializeField]
    private float forceStrength = 1;

    private bool _isShaking;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isShaking = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            _isShaking = false;
            rb.velocity = Vector2.zero;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_isShaking)
            rb.velocity = new Vector2(Mathf.Sin(Time.time * Speed), 0);
    }
}