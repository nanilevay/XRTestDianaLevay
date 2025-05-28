using UnityEngine;
/// <summary>
/// This class spawns a prefab of a given object using it's position and parent
/// </summary>
public class ObjectSpawner : MonoBehaviour
{
    // Parent to assign the child to
    public Transform Parent;

    // Spawn given prefab on desired location
    public void SpawnPrefab(BuildingData ObjectToSpawn, Vector3 SpawnPosition, Vector3 SpawnRotation)
    {
        // Instantiate given object on tile using parent's current rotation
        GameObject Instant =
            Instantiate(ObjectToSpawn.ObjectPrefab, SpawnPosition, Parent.transform.rotation);

        // Parent object and keep grid placement
        Instant.transform.SetParent(Parent.transform, true);

        Instant.transform.Rotate(SpawnRotation, Space.Self);

        // Destroy the effect particle in prefab 2 seconds after spawning
        Destroy(Instant.GetComponentInChildren<ParticleSystem>().gameObject, 2f);
    }
}