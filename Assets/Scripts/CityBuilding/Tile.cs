using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Vector2Int TileCoordinates;

    public TypeOfTile TileType;

    public bool Occupied;

    public bool Locked;

    public LayerMask layerMask;
    private void OnTriggerEnter(Collider other)
    {
        Occupied = true;   
    }
}

public enum TypeOfTile
{
    Road,
    Pavement,
    Terrain
}