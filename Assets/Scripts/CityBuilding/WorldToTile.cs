using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// Get the grid position based on mouse click
/// </summary>
public class WorldToTile : MonoBehaviour
{
    public static Grid grid;

    // Calculate proper tile placement
    public static Vector3 CalculateTile(Vector3 _worldPos)
    {
        // Get position on the cell grid based on clicked world position
        Vector3Int _cellPos = grid.WorldToCell(_worldPos);

        // Center object on selected cell based on offset
        Vector3 _fixedPos = grid.GetCellCenterWorld(_cellPos);

        Debug.Log(_fixedPos.x + " " + _fixedPos.z);

        return _fixedPos;
    }
}