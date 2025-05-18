using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    // Get the slots from the UI to display each image
    [SerializeField]
    private Image[] _displaySlots;

    // To place specific object when user drops image
    [SerializeField]
    private ObjectPlacer _objectPlacer;

    // Get the placeable object for this UI display
    [SerializeField]
    private CityObject[] _ObjectsInScene;

    // Get object data
    [SerializeField]
    private DraggableObject[] _draggableObject;

    // Start is called before the first frame update
    void Awake()
    {
        // Display the objects in their respective UI slot
        int i = 0;
        foreach (Image Slot in _displaySlots)
        {
            _displaySlots[i].sprite = _ObjectsInScene[i].objectImage;
            i++;
        }
    }
}
