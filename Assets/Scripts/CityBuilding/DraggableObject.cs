using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Drag an image from the UI into the grid
/// </summary>
public class DraggableObject : MonoBehaviour, IDragHandler, IEndDragHandler
{
    // Get image's position 
    private RectTransform _currentPos;

    // Mouse screen position 
    private Vector3 _screenPos;

    // Position in the 3D space
    private Vector3 _worldPos;

    // To place objects using a plane cast on the y axis
    private Plane plane = new Plane(Vector3.up, 0);

    void Awake()
    {
        // Get image's initial position in UI
        _currentPos = GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Follow mouse position while dragged
        _currentPos.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Reset position when user places image on map
        ResetPosition();

    }

    // Return image to starting position after release
    private void ResetPosition()
    {
        // Reset anchored position to 0,0
        _currentPos.anchoredPosition = Vector2.zero;
    }
}
