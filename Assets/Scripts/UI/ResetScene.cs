using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{


    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
