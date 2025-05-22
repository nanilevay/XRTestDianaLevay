using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This script just resets the scene and closes the application for simplicity
/// </summary>
public class ResetScene : MonoBehaviour
{
    // Reload the only scene in the build
    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }
}