using UnityEngine;

public class DragController : MonoBehaviour
{
    public LayerMask PlacementLayer;

    private BuildingData SelectedObject;

    public BuildingData[] BuildingsInScene;

    public Draggable[] DraggableObjects;

    public UIDisplayer ShowUI;

    public ObjectSpawner objectSpawner;

    public MapInfo Map;

    void Awake()
    {
        for (int i = 0; i < DraggableObjects.Length; i++)
        {
            DraggableObjects[i].ObjectChosenEvent += CheckChosenObject;
            DraggableObjects[i].ObjectPlacedEvent += CheckTileHit;

            DraggableObjects[i].StoredBuilding = BuildingsInScene[i];
        }

        ShowUI.DisplayBuildings(BuildingsInScene);
    }

    void OnDestroy()
    {
        for (int i = 0; i < DraggableObjects.Length; i++)
        {
            DraggableObjects[i].ObjectChosenEvent -= CheckChosenObject;
            DraggableObjects[i].ObjectPlacedEvent -= CheckTileHit;
        }
    }

    public void CheckChosenObject(BuildingData ChosenObject)
    {
        SelectedObject = ChosenObject;
    }

    // Check if terrain tile was hit for object placement
    public void CheckTileHit(Vector3 Position)
    {
        // Cast a ray from the camera to the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Position);

        // If terrain layer was hit
        if (Physics.Raycast(ray, out RaycastHit hit, 1000, PlacementLayer))
        {
            // Check if the tile and surroundings aren't currently occupied
            if (Map.CheckAvailable(hit.collider.GetComponent<Tile>().Coordinates, SelectedObject.objectSize))
            {
                // Spawn object on selected tile with due cell adjustments and parenting 
                objectSpawner.SpawnPrefab(SelectedObject, WorldToTile.CalculateTile(hit.point, Map.grid));
            }
        }

        ReleaseObject();
    }

    // Deselect object for new selection
    private void ReleaseObject()
    {
        SelectedObject = null;
    }
}