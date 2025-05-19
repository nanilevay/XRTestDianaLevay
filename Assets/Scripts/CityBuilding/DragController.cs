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

            DraggableObjects[i].StoredBuilding = BuildingsInScene[i];
        }

        ShowUI.DisplayBuildings(BuildingsInScene);
    }

    private void OnDestroy()
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

    // Check if terrain tile was hit
    public void CheckTileHit(Vector3 Position)
    {
        // Cast a ray from the camera to the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Position);

        // If terrain layer was hit
        if (Physics.Raycast(ray, out RaycastHit hit, 1000, PlacementLayer))
        {
            //Debug.Log("Placed" + SelectedObject.name + "at " + hit.point);
            if (!hit.collider.gameObject.GetComponent<Tile>().Occupied)
            {
                objectSpawner.SpawnPrefab(SelectedObject, WorldToTile.CalculateTile(hit.point, grid));
                //hit.collider.gameObject.GetComponent<Tile>().Occupied = true;
            }

            else
                Debug.Log("Tile occupied");
        }

        ReleaseObject();
    }

    // Deselect object
    private void ReleaseObject()
    {
        SelectedObject = null;
    }
}