using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class displays the current level UI based on game state and available draggable objects
/// </summary>
public class UIDisplayer : MonoBehaviour
{
    // Get images from drag UI slots to display each sprite
    [SerializeField]
    private Image[] _displaySlots;

    // Iterate through scriptable objects and get their images to display
    public void DisplayBuildings(BuildingData[] DisplayData)
    {
        for (int i = 0; i < _displaySlots.Length; i++)
        {
            _displaySlots[i].sprite = DisplayData[i].ObjectImage;
        }
    }
}