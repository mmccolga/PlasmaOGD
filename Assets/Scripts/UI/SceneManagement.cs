using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    private string previousSceneName;

    private void Start()
    {
        // Get the name of the current scene
        previousSceneName = SceneManager.GetActiveScene().name;
    }

    public void SetPreviousScene(string sceneName)
    {
        previousSceneName = sceneName;
    }

    public void LoadPreviousScene()
    {
        // Load the previous scene using its name
        SceneManager.LoadScene(previousSceneName);
    }
}

