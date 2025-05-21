using UnityEngine;

/// <summary>
/// Store tile information during runtime
/// </summary>
public class Tile : MonoBehaviour
{
    public Vector2Int Coordinates;

    // Type of tile to determine if it can contain a building
    public TypeOfTile Type;

    // Check whether or not tile is currently occupied
    public bool Occupied;

    // If locked, a tile can't get occupied due to it's terrain type
    public bool Locked;
}

/// <summary>
///  Types of tiles
/// </summary>
public enum TypeOfTile
{
    Road,
    Terrain
}