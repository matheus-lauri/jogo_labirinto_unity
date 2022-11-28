using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class field_of_view_fox : MonoBehaviour
{
    //This is the field of view that the Camera has
    public float m_FieldOfView_fox;

    void Start()
    {
        //Start the Camera field of view at 60
        m_FieldOfView_fox = 60.0f;
    }

    void Update()
    {
        //Update the camera's field of view to be the variable returning from the Slider
        Camera.main.fieldOfView = m_FieldOfView_fox;
    }
}
