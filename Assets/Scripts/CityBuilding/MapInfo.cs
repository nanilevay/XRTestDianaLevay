using System.Collections.Generic;
using UnityEngine;

public class MapInfo : MonoBehaviour
{
    public static int xSize = 30;
    public static int ySize = 30;

    [SerializeField]
    public Tile[,] TilesInScene;

    public Transform _object;

    public Grid grid;

    public Material mat;

    // Start is called before the first frame update
    void Start()
    {
        // Get the grid component from game object
        grid = GetComponent<Grid>();

        // Make a new array to sort all the tiles in the scene
        TilesInScene = new Tile[xSize, ySize];

        int ChildIndex = 0;

        // Add tiles to array and set their coordinates based on the grid placement
        for (int i = 0; i < xSize; i++)
        {
            for (int j = 0; j < ySize; j++)
            {
                TilesInScene[i, j] = _object.GetChild(ChildIndex).GetComponent<Tile>();
                _object.GetChild(ChildIndex).GetComponent<Tile>().Coordinates = new Vector2Int(i,j);

                ChildIndex++;
            }
        }
    }

    // Check availability of space based on the center tile and size of object being placed
    public bool CheckAvailable(Vector2Int TileCoords, Vector2Int objectSize)
    {
        // To lock tiles whenever a selection is valid
        List<Tile> Neighbours = new List<Tile>();

        // Get the max tiles forward / backward from the center tile
        int coordinatesForX = Mathf.RoundToInt(objectSize.x / 2);
        int coordinatesForY = Mathf.RoundToInt(objectSize.y / 2);

        // Iterate through the specified places on grid
        for (int row = TileCoords.x - coordinatesForX; row <= TileCoords.x + coordinatesForX; row++)
        {
            for (int col = TileCoords.y - coordinatesForY; col <= TileCoords.y + coordinatesForY; col++)
            {
                if (col >= xSize || col <= 0)
                {
                    return false;
                }

                if (row >= xSize || row <= 0)
                {
                    return false;
                }

                // If the tile is occupied position isn't valid
                if (!TilesInScene[row, col].Locked && TilesInScene[row, col].Occupied)
                {
                    return false;
                }

                else
                {
                    // If the tile isn't occupied then add to list
                    Neighbours.Add(TilesInScene[row, col]);
                }
            }
        }

        // Set the new occupied tiles
        foreach(Tile tile in Neighbours)
        {
            tile.Occupied = true;

            if(tile.Type == TypeOfTile.Terrain)
                tile.GetComponent<MeshRenderer>().material = mat;
        }

        // Clear list for next iteration
        Neighbours.Clear();

        return true;
    }
}