//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.Events;

//public class ToggleAnimation : MonoBehaviour
//{
//    [SerializeField] private Animator anim;
//    public Toggle myToggle;


//    void Start()
//    {
//        myToggle = GetComponent<UnityEngine.UI.Toggle>();
//        myToggle.onValueChanged.AddListener(delegate { valueChanged(myToggle); });

//        anim = GetComponent<Animator>();

//        Debug.Log("myToggle: " + myToggle + " animator: " + anim);
//    }

//    void Update()
//    {

//        //if (myToggle.isOn)
//        //{
//        //    Debug.Log("Toggle: " + myToggle);
//        //    if (anim != null)
//        //    {
//        //        anim.Play("Base Layer.EMWaves", 0, 1);
//        //    }
//        //}
//    }

//    public void valueChanged(Toggle test)
//    {
//        if (test.isOn)
//        {
//            Debug.Log("Toggle: " + test);
//            if (anim != null)
//            {
//                anim.Play("Base Layer.EMWaves", 0, 1);
//            }
//        }

//    }


//}

using UnityEngine;

public class ToggleAnimation : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component

    private void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
            if (animator == null)
            {
                Debug.LogError("Animator component not found on the GameObject or assigned to the script.");
            }
        }
    }

    private void OnEnable()
    {
        // Check if the GameObject is active when enabled
        if (gameObject.activeInHierarchy)
        {
            // Trigger the animation
            animator.SetBool("IsActivated", true); // Replace "IsActivated" with the parameter name used in your animation controller
        }
    }
}

