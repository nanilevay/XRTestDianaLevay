using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// Place an object on the grid based on mouse position and city rotation
/// </summary>
public class ObjectPlacer : MonoBehaviour
{
    // prefab test - to be moved
    public GameObject TestPrefab;
    public GameObject TestEffect;

    // grid test - to be moved
    public Grid grid;

    // tiles test - to be moved
    public Tilemap tiles;

    //// Calculate proper tile placement
    public void CheckTileHit()
    {
        // Cast a ray from the camera to the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Test - move later
        int layer_mask = LayerMask.GetMask("InteractableTerrain");

        if (Physics.Raycast(ray, out RaycastHit hit, 1000, layer_mask))
        {
            CalculateTile(hit.point);
        }
    }

    // Calculate proper tile placement
    private void CalculateTile(Vector3 _worldPos)
    {
        // Get position on the cell grid based on clicked world position
        Vector3Int _cellPos = grid.WorldToCell(_worldPos);

        // Center object on selected cell based on offset
        Vector3 _fixedPos = grid.GetCellCenterWorld(_cellPos);

        // test - move later
        SpawnPrefab(TestPrefab, _fixedPos);
    }

    // prefab test - move later
    public void SpawnPrefab(GameObject BuildingToSpawn, Vector3 position)
    {
        // Instantiate a new building on the correct tile assuming the rotation of the grid
        GameObject Instant = Instantiate(BuildingToSpawn, position, grid.transform.rotation);

        // Parent object to grid test - to be changed
        Instant.transform.SetParent(tiles.transform, true);

        GameObject Effect = Instantiate(TestEffect, position, grid.transform.rotation);
    }
}