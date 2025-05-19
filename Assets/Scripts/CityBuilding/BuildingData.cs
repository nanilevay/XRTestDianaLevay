using UnityEngine;

[CreateAssetMenu(menuName ="Building Data")]
public class BuildingData : ScriptableObject
{
    public int objectId;

    public int[,] objectSize;

    public string objectName;

    public Sprite objectImage;

    public GameObject objectPrefab;   
}