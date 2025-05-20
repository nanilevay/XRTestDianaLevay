using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public Transform Parent;

    // prefab test - move later
    public void SpawnPrefab(BuildingData ObjectToSpawn, Vector3 SpawnPosition)
    {
        // Instantiate a new building on the correct tile assuming the rotation of the grid
        GameObject Instant = Instantiate(ObjectToSpawn.objectPrefab, SpawnPosition, Parent.transform.rotation);

        // Parent object to grid test - to be changed
        Instant.transform.SetParent(Parent.transform, true);
    }
}