using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class stores the information from the map and all tiles in the scene
/// </summary>
public class MapInfo : MonoBehaviour
{
    // Size of the array to store tiles
    public static int xSize = 30;
    public static int ySize = 30;

    // Array containing all the tiles in scene
    [SerializeField]
    public Tile[,] TilesInScene;

    // Material to change tiles that have become occupied
    public Material mat;

    // Get the grid component for calculations
    public Grid grid;

    void Start()
    {
        grid = GetComponent<Grid>();

        // Make a new array to sort all the existing tiles in the scene
        TilesInScene = new Tile[xSize, ySize];

        int childIndex = 0;

        // Add tiles to array and set their adjusted coordinates based on grid placement
        for (int i = 0; i < xSize; i++)
        {
            for (int j = 0; j < ySize; j++)
            {
                TilesInScene[i, j] = transform.GetChild(childIndex).GetComponent<Tile>();
                transform.GetChild(childIndex).GetComponent<Tile>().Coordinates = new Vector2Int(i, j);

                childIndex++;
            }
        }
    }

    // Check availability of neighbour tiles based on the center tile and size of object being placed
    public bool CheckAvailable(Vector2Int TileCoords, Vector2Int objectSize, Vector3 objectRotation)
    {
        // To lock tiles whenever a selection is valid
        List<Tile> Neighbours = new List<Tile>();

        int coordinatesForX; int coordinatesForY;
        if (objectRotation.y == 90 || objectRotation.y == 270)
        {
            // Get the max tiles forward / backward from the center tile
            coordinatesForX = Mathf.RoundToInt(objectSize.y / 2);
            coordinatesForY = Mathf.RoundToInt(objectSize.x / 2);
        }

        else
        {
            // Get the max tiles forward / backward from the center tile
            coordinatesForX = Mathf.RoundToInt(objectSize.x / 2);
            coordinatesForY = Mathf.RoundToInt(objectSize.y / 2);
        }

        // Iterate through the specified places on grid and check for occupied tiles
        for (int row = TileCoords.x - coordinatesForX; row <= TileCoords.x + coordinatesForX; row++)
        {
            for (int col = TileCoords.y - coordinatesForY; col <= TileCoords.y + coordinatesForY; col++)
            {
                // Check edges
                if (row >= xSize || row < 0)
                {
                    return false;
                }

                if (col >= ySize || col < 0)
                {
                    return false;
                }

                // If the tile is occupied then this position isn't valid
                if (TilesInScene[row, col].Locked || TilesInScene[row, col].Occupied)
                {
                    return false;
                }

                // If tile and neighbouring are free then add to list
                else
                {
                    Neighbours.Add(TilesInScene[row, col]);
                }
            }
        }

        // Set the new occupied tiles and change colour
        foreach (Tile tile in Neighbours)
        {
            tile.Occupied = true;

            if (tile.Type == TypeOfTile.Terrain)
                tile.GetComponent<MeshRenderer>().material = mat;
        }

        // Clear list for next iteration
        Neighbours.Clear();

        return true;
    }
}