using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Display the current level's placeable buildings
/// </summary>
public class UIDisplayer: MonoBehaviour
{
    // Get the slots from the UI to display each image
    [SerializeField]
    private Image[] _displaySlots;

    // Start is called before the first frame update
    public void DisplayBuildings(BuildingData[] DisplayData)
    {
        for (int i = 0; i < _displaySlots.Length; i++)
        {
            _displaySlots[i].sprite = DisplayData[i].objectImage;
            i++;
        }
    }
}