using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    //Track sensitivity of x/y coordinates 
    public float sensX; 
    public float sensY;

    public Transform orientation; //Transform tracks position, rotation and scale of an object 

    float xRotation; 
    float yRotation; 

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //Lock movement of cursor, limit to middle of screen 
        Cursor.visible = false; //Cursor is invisible 
    }

    // Update is called once per frame
    void Update()
    {
        //Get mouse input 
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX; 
        xRotation -= mouseY;

        //Can't look up or down more than 90 degrees 
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); 

        //rotate cam and orientation 
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0); 
    }
}
