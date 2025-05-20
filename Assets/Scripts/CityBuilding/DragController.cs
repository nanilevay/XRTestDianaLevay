using UnityEngine;

public class DragController : MonoBehaviour
{
    public LayerMask PlacementLayer;

    private BuildingData SelectedObject;

    public BuildingData[] BuildingsInScene;

    public Draggable[] DraggableObjects;

    public Grid grid;

    public UIDisplayer ShowUI;

    public ObjectSpawner objectSpawner;

    void Awake()
    {
        for (int i = 0; i < DraggableObjects.Length; i++)
        {
            DraggableObjects[i].ObjectChosenEvent += CheckChosenObject;
            DraggableObjects[i].ObjectPlacedEvent += CheckTileHit;

            Debug.Log(BuildingsInScene[i].name);

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
            // Check if the tile isn't currently occupied
            if (!hit.collider.gameObject.GetComponent<Tile>().Occupied)
            {
                // Spawn object on selected tile with due cell adjustments and parenting 
                objectSpawner.SpawnPrefab(SelectedObject, WorldToTile.CalculateTile(hit.point, grid));


                //hit.collider.gameObject.GetComponent<Tile>().Occupied = true;
            }

            // 
            else
                Debug.Log("Tile occupied");
        }

        ReleaseObject();
    }

    // Deselect object for new selection
    private void ReleaseObject()
    {
        SelectedObject = null;
    }
}