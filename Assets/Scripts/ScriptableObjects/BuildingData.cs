using UnityEngine;
/// <summary>
/// This class stores a building's necessary data for functionality
/// </summary>
[CreateAssetMenu(menuName ="Building Data")]
public class BuildingData : ScriptableObject
{
    // Size of the object in tiles for map placement 
    public Vector2Int ObjectSize;

    // Sprite to be displayed on drag UI
    public Sprite ObjectImage;

    // Prefab to be spawned on scene
    public GameObject ObjectPrefab;   
}