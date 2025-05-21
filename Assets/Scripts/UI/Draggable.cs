using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Drag an image from the UI into the grid then reset position
/// </summary>
public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // Get starting image position 
    private RectTransform _currentPos;

    // Get the building stored in this slot
    public BuildingData StoredBuilding;

    // Set an event to notify of specific chosen object
    public event System.Action<BuildingData> ObjectChosenEvent;

    // Set an event to notify of object placed 
    public event System.Action<Vector3> ObjectPlacedEvent;

    void Awake()
    {
        // Get initial image position in UI
        _currentPos = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Send event with stored building for dragging on map
        ObjectChosenEvent.Invoke(StoredBuilding);
    }
    public void OnDrag(PointerEventData eventData)
    {
        // Follow mouse position with selected building image
        _currentPos.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Send event of chosen building using mouse position
        ObjectPlacedEvent.Invoke(_currentPos.position);

        // Reset image position back to its slot
        StartCoroutine(FadeAnimation());
    }

    // Return image to starting position after release
    private void ResetPosition()
    {
        StartCoroutine(FadeAnimation());
        // Reset anchored position to 0,0
        _currentPos.anchoredPosition = Vector2.zero;
    }

    private IEnumerator FadeAnimation()
    {
        GetComponent<Animator>().SetBool("FadeOut", true);
        yield return new WaitForSeconds(0.4f);
        _currentPos.anchoredPosition = Vector2.zero;
        yield return new WaitForSeconds(0.4f);
        GetComponent<Animator>().SetBool("FadeOut", false);
        GetComponent<Animator>().SetBool("FadeIn", true);
        yield return new WaitForSeconds(0.4f);
        GetComponent<Animator>().SetBool("FadeOut", false);
        GetComponent<Animator>().SetBool("FadeIn", false);
    }
}