using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Display the current level UI based on game state and draggable buildings
/// </summary>
public class UIDisplayer: MonoBehaviour
{
    // Get the slots from the drag UI to display each image
    [SerializeField]
    private Image[] _displaySlots;

    // Start is called before the first frame update
    public void DisplayBuildings(BuildingData[] DisplayData)
    {
        // Display each scriptable object in the game's associated image
        for (int i = 0; i < _displaySlots.Length; i++)
        {
            _displaySlots[i].sprite = DisplayData[i].objectImage;
        }
    }

    // Show the specified UI type (drag / physics)
    public void ShowUI(GameObject UIType)
    {
        UIType.SetActive(true);
    }

    // Hide the specified UI type (drag / physics)
    public void HideUI(GameObject UIType)
    {
        UIType.SetActive(false);
    }
}