using UnityEngine;

/// <summary>
/// This class controls the logic of the drag and drop feature
/// </summary>
public class DragController : MonoBehaviour
{
    // Access the current map information in scene
    public MapInfo Map;

    // Currently selected object from UI
    private BuildingData SelectedObject;

    // Get terrain layer for raycast detection
    public LayerMask PlacementLayer;

    // Current placeable objects 
    public BuildingData[] ObjectsInScene;

    // Current draggable objects to handle UI input
    public Draggable[] DraggableObjects;

    // Display the UI with the correct data
    public UIDisplayer ShowUI;

    // To spawn objects at the selected coordinate 
    public ObjectSpawner objectSpawner;

    void Awake()
    {
        // Events from each draggable to know when a drag and drop action was performed
        for (int i = 0; i < DraggableObjects.Length; i++)
        {
            DraggableObjects[i].ObjectChosenEvent += CheckChosenObject;
            DraggableObjects[i].ObjectPlacedEvent += CheckTileHit;

            // Get the current buildings in the scene
            DraggableObjects[i].StoredBuilding = ObjectsInScene[i];
        }

        // Display current buildings 
        ShowUI.DisplayBuildings(ObjectsInScene);
    }

    void OnDestroy()
    {
        // Unsubscribe to events
        for (int i = 0; i < DraggableObjects.Length; i++)
        {
            DraggableObjects[i].ObjectChosenEvent -= CheckChosenObject;
            DraggableObjects[i].ObjectPlacedEvent -= CheckTileHit;
        }
    }

    // Get the currently selected building from player input on begin drag
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
            if (Map.CheckAvailable(hit.collider.GetComponent<Tile>().Coordinates, SelectedObject.ObjectSize))
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