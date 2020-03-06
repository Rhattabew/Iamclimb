using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderCube : MonoBehaviour
{
    /*
    Creator/Editor: Kit
    Creation Date: 6/3/2020
    Last Update: 6/3/2020
    */
    public bool cubeUp = false;
    public bool cubeDown = false;
    public bool cubeLeft = false;
    public bool cubeRight = false;
    public bool cubeForward = false;
    public bool cubeBack = false;
    public bool cubeUpLeft = false;
    public bool cubeUpRight = false;
    public bool cubeDownLeft = false;
    public bool cubeDownRight = false;
    public bool cubeUpForward = false;
    public bool cubeUpBack = false;
    public bool cubeDownForward = false;
    public bool cubeDownBack = false;
    void Start()
    {
        GetComponent<BoxCollider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        DetectDistance();
        Movement();
    }
    void LateUpdate()
    {

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

        Ray rayUpLeft = new Ray(transform.position, Vector3.up + Vector3.left);
        Debug.DrawRay(transform.position, Vector3.up + Vector3.left, Color.green);

        Ray rayUpRight = new Ray(transform.position, Vector3.up + -Vector3.left);
        Debug.DrawRay(transform.position, Vector3.up + -Vector3.left, Color.green);

        Ray rayDownLeft = new Ray(transform.position, -Vector3.up + Vector3.left);
        Debug.DrawRay(transform.position, -Vector3.up + Vector3.left, Color.green);

        Ray rayDownRight = new Ray(transform.position, -Vector3.up + -Vector3.left);
        Debug.DrawRay(transform.position, -Vector3.up + -Vector3.left, Color.green);

        Ray rayUpForward = new Ray(transform.position, Vector3.up + Vector3.forward);
        Debug.DrawRay(transform.position, Vector3.up + Vector3.forward, Color.green);

        Ray rayUpBack = new Ray(transform.position, Vector3.up + -Vector3.forward);
        Debug.DrawRay(transform.position, Vector3.up + -Vector3.forward, Color.green);

        Ray rayDownForward = new Ray(transform.position, -Vector3.up + Vector3.forward);
        Debug.DrawRay(transform.position, -Vector3.up + Vector3.forward, Color.green);

        Ray rayDownBack = new Ray(transform.position, -Vector3.up + -Vector3.forward);
        Debug.DrawRay(transform.position, -Vector3.up + -Vector3.forward, Color.green);

        //Detects if there is an object next to the cube, if so changes the corresponding bool to true
        if (Physics.Raycast(rayUp, out hit, 1))
        {
            cubeUp = true;
            Debug.Log("Up");
        }
        else
        {
            cubeUp = false;
        }
        if (Physics.Raycast(rayDown, out hit , 1))
        {
            cubeDown = true;
            Debug.Log("Down");
        }
        else
        {
            cubeDown = false;
        }
        if (Physics.Raycast(rayLeft, out hit, 1))
        {
            cubeLeft = true;
            Debug.Log("Left");
            Debug.Log(hit.collider.gameObject.name);
        }
        else
        {
            cubeLeft = false;
        }
        if (Physics.Raycast(rayRight, out hit, 1))
        {
            cubeRight = true;
            Debug.Log("Right");
        }
        else
        {
            cubeRight = false;
        }
        if (Physics.Raycast(rayForward, out hit, 1))
        {
            cubeForward = true;
            Debug.Log("Forward");
        }
        else
        {
            cubeForward = false;
        }
        if (Physics.Raycast(rayBack, out hit, 1))
        {
            cubeBack = true;
            Debug.Log("Back");
        }
        else
        {
            cubeBack = false;
        }
        if (Physics.Raycast(rayUpLeft, out hit, 1) && cubeLeft == false && cubeUp == false)
        {
            cubeUpLeft = true;
            Debug.Log("UpLeft");
        }
        else
        {
            cubeUpLeft = false;
        }
        if (Physics.Raycast(rayUpRight, out hit, 1) && cubeRight == false && cubeUp == false)
        {
            cubeUpRight = true;
            Debug.Log("UpRight");
        }
        else
        {
            cubeUpRight = false;
        }
        if (Physics.Raycast(rayDownLeft, out hit, 1) && cubeLeft == false && cubeDown == false)
        {
            cubeDownLeft = true;
            Debug.Log("UpLeft");
        }
        else
        {
            cubeDownLeft = false;
        }
        if (Physics.Raycast(rayDownRight, out hit, 1) && cubeRight == false && cubeDown == false)
        {
            cubeDownRight = true;
            Debug.Log("DownRight");
        }
        else
        {
            cubeDownRight = false;
        }
        if (Physics.Raycast(rayUpForward, out hit, 1) && cubeForward == false && cubeUp == false)
        {
            cubeUpForward = true;
            Debug.Log("UpForward");
        }
        else
        {
            cubeUpForward = false;
        }
        if (Physics.Raycast(rayUpBack, out hit, 1) && cubeBack == false && cubeUp == false)
        {
            cubeUpBack = true;
            Debug.Log("UpBack");
        }
        else
        {
            cubeUpBack = false;
        }
        if (Physics.Raycast(rayDownForward, out hit, 1) && cubeForward == false && cubeDown == false)
        {
            cubeDownForward = true;
            Debug.Log("DownForward");
        }
        else
        {
            cubeDownForward = false;
        }
        if (Physics.Raycast(rayDownBack, out hit, 1) && cubeBack == false && cubeDown == false)
        {
            cubeDownBack = true;
            Debug.Log("DownBack");
        }
        else
        {
            cubeDownBack = false;
        }
    }

    void Movement()
    {
        if(Input.GetKeyDown(KeyCode.W) && cubeUp == false)
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
        if (Input.GetKeyDown(KeyCode.Q) && cubeDown == false)
        {
            transform.Translate(Vector3.forward);
        }
        if (Input.GetKeyDown(KeyCode.E) && cubeDown == false)
        {
            transform.Translate(-Vector3.forward);
        }
    }

    void PlaceCube()
    {
        GetComponent<BoxCollider>().enabled = true;
    }
}
