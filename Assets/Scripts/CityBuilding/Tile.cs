using UnityEngine;

/// <summary>
/// Store tile information during runtime
/// </summary>
public class Tile : MonoBehaviour
{
    // Tile location within grid
    public Vector2Int TileCoordinates;

    // Type of tile to determine if it can contain a building
    public TypeOfTile TileType;

    // Check whether or not tile is currently occupied
    public bool Occupied;

    // If locked, a tile can't get occupied due to it's terrain type
    public bool Locked;

    // Check if tile is storing a building and lock it
    private void OnTriggerEnter(Collider other)
    {
        Occupied = true;   
    }
}

/// <summary>
///  Types of tiles
/// </summary>
public enum TypeOfTile
{
    Road,
    Terrain
}