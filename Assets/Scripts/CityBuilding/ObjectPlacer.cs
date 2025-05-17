using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Place an object on the grid based on mouse position
/// </summary>
public class ObjectPlacer : MonoBehaviour
{
    // Mouse screen position 
    private Vector3 _screenPos;

    // Position in the 3D space
    private Vector3 _worldPos;

    // To place objects using a plane cast on the y axis
    private Plane plane = new Plane(Vector3.up, 0);

    public void PlaceObject()
    {
        _screenPos = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.z);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (plane.Raycast(ray, out float distance))
        {
            _worldPos = ray.GetPoint(distance);
        }
    }

    public void SpawnPrefab(GameObject BuildingToSpawn)
    {
        Instantiate(BuildingToSpawn, _worldPos, Quaternion.identity);
    }
}