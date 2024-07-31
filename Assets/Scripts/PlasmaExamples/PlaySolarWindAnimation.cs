using UnityEngine;
using UnityEngine.UI;

public class PlaySolarWindAnimation : MonoBehaviour
{
    //Uses a button to play an animation using the trigger parameter set for the animator
    public Animator animator; // Reference to the Animator component
    public string animationName1, animationName2; // Name of the animation clip to play
    public Button button1, button2; // Reference to the button that triggers the animation

    private void Start()
    {
        if (animator == null)
        {
            Debug.LogError("No Animator component assigned to this script.");
        }

        if (button1 == null | button2 == null)
        {
            Debug.LogError("No Button component assigned to this script.");
        }
        else
        {
            // Add an event listener to the button's onClick event
            button1.onClick.AddListener(PlayAnimationSmall);
            button2.onClick.AddListener(PlayAnimationBig);

        }
    }

    public void PlayAnimationSmall()
    {
        // Trigger the animation by setting the specified trigger parameter
        animator.SetTrigger("PlaySmall");

    }
    public void PlayAnimationBig()
    {
        // Trigger the animation by setting the specified trigger parameter
        animator.SetTrigger("PlayBig");

    }
}

