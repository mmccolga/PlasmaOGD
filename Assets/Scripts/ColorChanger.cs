using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ColorChanger : MonoBehaviour
{
    bool buttonPressed;
    Material mycolor;
    Material highlight;
    MeshRenderer[] meshRenderers;//new
    MeshRenderer[] oneMesh;
    //GameObject [] gameObj;
    Transform[] allChildren;
    Transform[] allGrands;
    int i;



    // Start is called before the first frame update
    void Start()
    {   //sets the highlight color and captures the color of the parent (all children and grandchildren will be the same color)
        highlight = Resources.Load("Materials/Green") as Material;//sets the highlight color
        mycolor = GetComponent<MeshRenderer>().material; //sets the color back color to the parent's original color - parent must have meshrenderer
        print("name " + transform.name + " childCount " + transform.childCount);
        print("name " + transform.name + " color " + mycolor);
    }





    // Update is called once per frame
    void Update()
    {

    }

    public void changeColorToRed()
    {
        if (transform.childCount > 0)//this counts the game objects inside the game object container
        {
            allChildren = GetComponentsInChildren<Transform>(); //gets all the children including the parent [0]
            foreach (Transform child in allChildren)//loops through all children
            {
                print(child);
                if (child == allChildren[0])//this is the parent so ignores
                    print("zero");
                else
                {
                    print("child " + child);
                    if (child.transform.childCount > 0)//this means there are grandchildren
                    {
                        allGrands = child.GetComponentsInChildren<Transform>();
                        print("grand count " + child.transform.childCount);
                        foreach (Transform grand in allGrands)//cycle through the grands
                        {
                            print("grand " + grand);
                            if (grand == allGrands[0])//this is the child
                            {
                                print("grand zero");
                            }
                            else
                            {
                                print("grand " + grand);
                                grand.GetComponent<MeshRenderer>().material = highlight; //sets the material to the highlight color
                                print(grand.GetComponent<MeshRenderer>().material);
                            }
                        }
                    }
                    else
                    {
                        child.GetComponent<MeshRenderer>().material = highlight; //this changes the color of the child - it could go with AllChidren[0]
                    }
                }
            }


        }
        else
        {
            GetComponent<Renderer>().material = highlight; //this changes the color of the container game object if it's not a container
        }
    }

    public void changeColorBack()
    {
        if (transform.childCount > 0)
        {
            allChildren = GetComponentsInChildren<Transform>();
            foreach (Transform child in allChildren)
            {
                print(child);
                if (child == allChildren[0])
                    print("zero");
                else
                {
                    print("child " + child);
                    if (child.transform.childCount > 0)
                    {
                        allGrands = child.GetComponentsInChildren<Transform>();
                        print("grand count " + child.transform.childCount);
                        foreach (Transform grand in allGrands)
                        {
                            print("grand " + grand);
                            if (grand == allGrands[0])
                            {
                                print("grand zero");
                            }
                            else
                            {
                                print("grand " + grand);
                                grand.GetComponent<MeshRenderer>().material = mycolor;
                                print(grand.GetComponent<MeshRenderer>().material);
                            }
                        }
                    }
                    else
                    {
                        child.GetComponent<MeshRenderer>().material = mycolor;
                    }
                }
            }
        }
        else
        {
            GetComponent<Renderer>().material = mycolor;
        }
    }




}
