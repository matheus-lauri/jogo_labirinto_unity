using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fox_win_script : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<Rigidbody>()){
            if(other.GetComponent<Rigidbody>().mass == 51){
            Time.timeScale = Time.timeScale == 1.0f ? 0.0f : 1.0f;
            Debug.Log("Fox Wins!!!");
            }
        }
    }
    void Update(){
        if(Time.timeScale == 0.0f){
                Application.Quit();
        }
    }
}