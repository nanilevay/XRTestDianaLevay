using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

/// <summary>
/// This class controls the user input regarding dragging an UI image
/// into the grid then animating it and resetting the position for new drag
/// </summary>
public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // Get starting image position 
    private RectTransform _currentPos;

    // Get the building stored in this slot
    public BuildingData StoredBuilding;

    // Set an event to notify of chosen object action
    public event System.Action<BuildingData> ObjectChosenEvent;

    public event System.Action<Vector3> DraggingObjectEvent;

    // Set an event to notify of object placed action
    public event System.Action<Vector3> ObjectPlacedEvent;

    [SerializeField]
    private float AnimationWaitTime = 0.4f;

    void Awake()
    {
        // Get initial image position in UI
        _currentPos = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Send event with stored building to controller
        ObjectChosenEvent.Invoke(StoredBuilding);
    }
    public void OnDrag(PointerEventData eventData)
    {
        // Follow mouse position with selected image
        _currentPos.position = eventData.position;

        DraggingObjectEvent.Invoke(_currentPos.position);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Send event of final mouse position to controller
        ObjectPlacedEvent.Invoke(_currentPos.position);

        // Reset image position back to its slot
        StartCoroutine(FadeAnimation());
    }

    // Animate image with simple fade effect
    private IEnumerator FadeAnimation()
    {
        GetComponent<Animator>().SetBool("FadeOut", true);

        yield return new WaitForSeconds(AnimationWaitTime);

        ResetPosition();

        yield return new WaitForSeconds(AnimationWaitTime);

        GetComponent<Animator>().SetBool("FadeIn", true);

        yield return new WaitForSeconds(AnimationWaitTime);

        GetComponent<Animator>().SetBool("FadeOut", false);
        GetComponent<Animator>().SetBool("FadeIn", false);
    }

    // Return image to starting position after release
    private void ResetPosition()
    {
        _currentPos.anchoredPosition = Vector2.zero;
    }
}