using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class field_of_view_chicken : MonoBehaviour
{
    //This is the field of view that the Camera has
    public float m_FieldOfView_chicken;
    public Camera ChickenCamera;

    void Start()
    {
        //Start the Camera field of view at 60
        m_FieldOfView_chicken = 60.0f;
        ChickenCamera = GameObject.FindGameObjectWithTag("CurrentCamera").GetComponent<Camera>() as Camera;
    }

    void Update()
    {
        //Update the camera's field of view to be the variable returning from the Slider
        ChickenCamera.fieldOfView = m_FieldOfView_chicken;
    }
}
