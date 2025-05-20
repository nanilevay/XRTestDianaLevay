using UnityEngine;

/// <summary>
/// Get the grid position based on mouse click
/// </summary>
public static class WorldToTile
{
    // Calculate proper tile placement
    public static Vector3 CalculateTile(Vector3 WorldPos, Grid grid)
    {
        // Get position on the cell grid based on clicked world position
        Vector3Int CellPos = grid.WorldToCell(WorldPos);

        // Center object on selected cell based on offset
        Vector3 FixedPos = grid.GetCellCenterWorld(CellPos);

        FixedPos.y = 1;

        return FixedPos;
    }
}