using UnityEngine;

public class ObjectPreview : MonoBehaviour
{
    // Parent to assign the child to
    public Transform Parent;

    [SerializeField]
    private GameObject PreviewObject;

    [SerializeField]
    private Material ValidMaterial;

    [SerializeField]
    private Material InvalidMaterial;

    public Quaternion Rotation;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            PreviewObject.transform.Rotate(0,90,0, Space.Self);
            Rotation = PreviewObject.transform.localRotation;
        }
    }
 
    public void ShowObjectPreview(BuildingData objectToShow, Vector3 position)
    {   
        PreviewObject.GetComponent<MeshFilter>().mesh = objectToShow.ObjectPrefab.GetComponent<MeshFilter>().sharedMesh;

        PreviewObject.transform.localScale = objectToShow.ObjectPrefab.transform.localScale;

        PreviewObject.SetActive(true);

        PreviewObject.GetComponent<Renderer>().material = ValidMaterial;

        PreviewObject.transform.position = new Vector3(position.x, position.y - 1, position.z);
    }

    public void StopObjectPreview()
    {
        PreviewObject.SetActive(false);
        PreviewObject.transform.position = Vector3.zero;
        PreviewObject.transform.Rotate(0, 0, 0, Space.Self);
    }
}