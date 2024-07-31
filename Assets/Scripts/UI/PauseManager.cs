using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private bool isPaused = false;

    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            // The application is paused
            ARStaticVarHolder.wasWarned = false;
            isPaused = true;

            // You can add your pause-related code here, such as pausing the game, showing a pause menu, etc.
            // For example, you might use Time.timeScale to pause the game:
            Time.timeScale = 0f;
        }
        else
        {
            // The application is resumed
            Debug.Log("Application resumed");
            isPaused = false;

            // You can add your resume-related code here, such as resuming the game, hiding the pause menu, etc.
            // For example, you might set Time.timeScale back to 1 to resume the game:
            Time.timeScale = 1f;
        }
    }
}
