using UnityEngine;
/// <summary>
/// Spawn a prefab of a given object using it's position and parenting to the scene's grid
/// </summary>
public class ObjectSpawner : MonoBehaviour
{
    // Parent to align the child to
    public Transform Parent;

    // Spawn given prefab on desired location
    public void SpawnPrefab(BuildingData ObjectToSpawn, Vector3 SpawnPosition)
    {
        // Instantiate a new building on the correct tile assuming the rotation of the grid
        GameObject Instant = Instantiate(ObjectToSpawn.objectPrefab, SpawnPosition, Parent.transform.rotation);

        // Parent object to grid
        Instant.transform.SetParent(Parent.transform, true);
    }
}