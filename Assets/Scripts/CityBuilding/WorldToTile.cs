using UnityEngine;

/// <summary>
/// This class sets the grid position for object placement based on 
/// world coordinates and a given grid component
/// </summary>
public static class WorldToTile
{
    // Calculate proper tile placement from mouse to world raycast position
    public static Vector3 CalculateTile(Vector3 WorldPos, Grid grid)
    {
        // Get position on the cell grid based on world position
        Vector3Int CellPos = grid.WorldToCell(WorldPos);

        // Center object on selected cell based on offset
        Vector3 FixedPos = grid.GetCellCenterWorld(CellPos);

        // Adjust due to animation
        FixedPos.y += 1;

        // Return correct position in grid
        return FixedPos;
    }
}