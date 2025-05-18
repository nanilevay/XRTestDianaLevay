using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Drag an image from the UI into the grid then reset position
/// </summary>
public class DraggableObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // Get starting image position 
    private RectTransform _currentPos;

    void Awake()
    {
        // Get initial image position in UI
        _currentPos = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // _currentObj = ;
        // get the chosen item's info
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

    // Check if terrain tile was hit
    public void CheckTileHit(int Layer)
    {
        // Cast a ray from the camera to the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // If terrain layer was hit
        if (Physics.Raycast(ray, out RaycastHit hit, 1000, Layer))
        {
            //CalculateTile(hit.point);
        }
    }
}