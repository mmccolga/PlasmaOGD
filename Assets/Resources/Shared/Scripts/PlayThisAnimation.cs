using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayThisAnimation : MonoBehaviour
{
    //Uses a button to play an animation using the trigger parameter set for the animator
    public Animator animator; // Reference to the Animator component
    public string animationName1; // Name of the animation clip to play
    public Button button; // Reference to the button that triggers the animation
    

    private void Start()
    {
        if (animator == null)
        {
            Debug.LogError("No Animator component assigned to this script.");
        }

        if (button == null)
        {
            Debug.LogError("No Button component assigned to this script.");
        }
        else
        {
            // Add an event listener to the button's onClick event
            button.onClick.AddListener(PlayMyAnimation);
            

        }
    }

    public void PlayMyAnimation()
    {
        // Trigger the animation by setting the specified trigger parameter
        animator.SetTrigger("playMe");

    }
    
}
