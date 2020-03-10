﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{
    /*
    Creator/Editor: Kit
    Creation Date: 10/3/2020
    Last Update: 10/3/2020
    Description: Cube movement + placing cube for the builder.
    */
    public bool cubeUp = false;
    public bool cubeDown = false;
    public bool cubeLeft = false;
    public bool cubeRight = false;
    public bool cubeForward = false;
    public bool cubeBack = false;

    public Transform rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DetectDistance();
        movement();
    }

    void movement()
    {
        if (Input.GetKeyDown(KeyCode.W) && cubeUp == false)
        {
            transform.Translate(Vector3.up);
        }
        if (Input.GetKeyDown(KeyCode.A) && cubeLeft == false)
        {
            transform.Translate(Vector3.left);
        }
        if (Input.GetKeyDown(KeyCode.D) && cubeRight == false)
        {
            transform.Translate(-Vector3.left);
        }
        if (Input.GetKeyDown(KeyCode.S) && cubeDown == false)
        {
            transform.Translate(-Vector3.up);
        }
        if (Input.GetKeyDown(KeyCode.Q) && cubeForward == false)
        {
            transform.Translate(Vector3.forward);
        }
        if (Input.GetKeyDown(KeyCode.E) && cubeBack == false)
        {
            transform.Translate(-Vector3.forward);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject BuilderCubeTemp = ObjectPooler.SharedInstance.GetPooledObject("Builder Cube");
            if (BuilderCubeTemp != null)
            {
                BuilderCubeTemp.transform.position = rb.transform.position;
                BuilderCubeTemp.transform.rotation = rb.transform.rotation;
                BuilderCubeTemp.SetActive(true);
            }
        }
    }
    void DetectDistance()
    {
        RaycastHit hit;
        //Fires a raycast in each direction
        Ray rayUp = new Ray(transform.position, Vector3.up);
        Debug.DrawRay(transform.position, Vector3.up, Color.green);

        Ray rayDown = new Ray(transform.position, -Vector3.up);
        Debug.DrawRay(transform.position, -Vector3.up, Color.green);

        Ray rayLeft = new Ray(transform.position, Vector3.left);
        Debug.DrawRay(transform.position, Vector3.left, Color.green);

        Ray rayRight = new Ray(transform.position, -Vector3.left);
        Debug.DrawRay(transform.position, -Vector3.left, Color.green);

        Ray rayForward = new Ray(transform.position, Vector3.forward);
        Debug.DrawRay(transform.position, Vector3.forward, Color.green);

        Ray rayBack = new Ray(transform.position, -Vector3.forward);
        Debug.DrawRay(transform.position, -Vector3.forward, Color.green);

        //Detects if there is an object next to the cube, if so changes the corresponding bool to true
        if (Physics.Raycast(rayUp, out hit, 1))
        {
            cubeUp = true;
            //Debug.Log("Up")
        }
        else
        {
            cubeUp = false;
        }
        if (Physics.Raycast(rayDown, out hit, 1))
        {
            cubeDown = true;
            //Debug.Log("Down");
        }
        else
        {
            cubeDown = false;
        }
        if (Physics.Raycast(rayLeft, out hit, 1))
        {
            cubeLeft = true;
            //Debug.Log("Left");
            //Debug.Log(hit.collider.gameObject.name);
        }
        else
        {
            cubeLeft = false;
        }
        if (Physics.Raycast(rayRight, out hit, 1))
        {
            cubeRight = true;
            //Debug.Log("Right");
        }
        else
        {
            cubeRight = false;
        }
        if (Physics.Raycast(rayForward, out hit, 1))
        {
            cubeForward = true;
            //Debug.Log("Forward");
        }
        else
        {
            cubeForward = false;
        }
        if (Physics.Raycast(rayBack, out hit, 1))
        {
            cubeBack = true;
            //Debug.Log("Back");
        }
        else
        {
            cubeBack = false;
        }
    }
}
