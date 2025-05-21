using UnityEngine;
/// <summary>
/// Store data for each building type that can be dragged onto the scene
/// </summary>
[CreateAssetMenu(menuName ="Building Data")]
public class BuildingData : ScriptableObject
{
    // Name of the building type to be displayed to user
    public string objectName;

    // Size of the object in tiles for placement purposes
    public Vector2Int objectSize;

    // Sprite to be displayed on drag UI
    public Sprite objectImage;

    // Prefab to be spawned on scene
    public GameObject objectPrefab;   
}