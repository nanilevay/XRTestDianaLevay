using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Object Info")]
public class CityObject : ScriptableObject
{
    public int objectId;

    public int[,] objectSize;

    public string objectName;

    public Sprite objectImage;

    public GameObject objectPrefab;   
}