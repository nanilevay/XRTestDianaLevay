using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Drag an image from the UI into the grid
/// </summary>
public class DraggableObject : MonoBehaviour, IDragHandler, IEndDragHandler
{
    // Get image position 
    private RectTransform _currentPos;

    void Awake()
    {
        // Get initial image position in UI
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
