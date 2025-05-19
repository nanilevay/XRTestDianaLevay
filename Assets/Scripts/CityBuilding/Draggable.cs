using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Drag an image from the UI into the grid then reset position
/// </summary>
public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // Get starting image position 
    private RectTransform _currentPos;

    public BuildingData StoredBuilding;

    public event System.Action<BuildingData> ObjectChosenEvent;

    public event System.Action<Vector3> ObjectPlacedEvent;

    void Awake()
    {
        // Get initial image position in UI
        _currentPos = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        ObjectChosenEvent.Invoke(StoredBuilding);
    }
    public void OnDrag(PointerEventData eventData)
    {
        _currentPos.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        ObjectPlacedEvent.Invoke(_currentPos.position);
        ResetPosition();
    }

    // Return image to starting position after release
    private void ResetPosition()
    {
        // Reset anchored position to 0,0
        _currentPos.anchoredPosition = Vector2.zero;
    }
}