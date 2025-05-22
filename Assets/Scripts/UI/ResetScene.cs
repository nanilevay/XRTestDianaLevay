using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This script just resets the scene for simplicity
/// </summary>
public class ResetScene : MonoBehaviour
{
    // Reload the only scene in the build
    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
