using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// Place an object on the grid based on mouse position
/// </summary>
public class ObjectPlacer : MonoBehaviour
{
    // Position in the 3D space
    private Vector3 _worldPos;
    
    private Vector3 _fixedPos;

    // To place objects using a plane cast on the y axis
    private Plane plane = new Plane(Vector3.up, 0);

    // To get the grid position of mouse
    Vector3Int _cellPos;

    // prefab test - to be moved
    public GameObject TestPrefab;

    // grid test - to be moved
    public Grid grid;

    // tiles test - to be moved
    public Tilemap tiles;

    // Calculate proper tile placement
    public void CalculateTile()
    {
        // Cast a ray from the camera to the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Get the point of intersection with user click and plane
        if (plane.Raycast(ray, out float distance))
        {
            _worldPos = ray.GetPoint(distance);
        }

        // Get position on the cell grid based on clicked world position
        _cellPos = grid.WorldToCell(_worldPos);

        // Center object on selected cell based on offset
        _fixedPos = grid.GetCellCenterWorld(_cellPos);

        // test - move later
        SpawnPrefab(TestPrefab);
    }

    // prefab test - move later
    public void SpawnPrefab(GameObject BuildingToSpawn)
    {
        // Instantiate a new building on the correct tile assuming the rotation of the grid
        GameObject Instant = Instantiate(BuildingToSpawn, _fixedPos, grid.transform.rotation);

        // Parent object to grid test - to be changed
        Instant.transform.SetParent(tiles.transform, true);
    }
}