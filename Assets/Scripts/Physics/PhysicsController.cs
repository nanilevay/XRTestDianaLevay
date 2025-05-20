using UnityEngine;

/// <summary>
/// Activate the different physics mechanics depending on user input
/// </summary>
public class PhysicsController : MonoBehaviour
{
    // Get script to shake city
    private CityShake _cityShake;

    // Get script to tilt city
    private CityTilt _citytilt;


    // Start is called before the first frame update
    void Awake()
    {
        // Get shake script from game object
        _cityShake = GetComponent<CityShake>();

        // Get tilt script from game object
        _citytilt = GetComponent<CityTilt>();
    }

    // Update is called once per frame
    void Update()
    {
        // To be changed - if user presses button enable script
        if (Input.GetMouseButtonDown(0))
        {
            _citytilt.enabled = true;
        }

        // To be changed - if user releases button disable script
        if (Input.GetMouseButtonUp(0))
        {
            _citytilt.ReturnToOrigin();
            //_citytilt.enabled = false;
        }

        if (Input.GetMouseButtonDown(1))
        {
            _cityShake.enabled = true;
        }

        if (Input.GetMouseButtonUp(1))
        {
            _cityShake.enabled = false;
        }
    }
}