using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Switch between dragging objects on map and tilting map with physics
/// </summary>
public class ToggleControl : MonoBehaviour
{
    // Toggle to switch between modes
    private Toggle _toggle;

    // Start is called before the first frame update
    void Awake()
    {
        // Get toggle attached to object
        _toggle = GetComponent<Toggle>();
    }
}