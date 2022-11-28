using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class chicken_win_script : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<Rigidbody>().mass == 50){
            Time.timeScale = Time.timeScale == 1.0f ? 0.0f : 1.0f;
            Debug.Log("Chicken Wins!!!");
            Destroy(gameObject);
        }
    }
    void Update(){
        if(Time.timeScale == 0.0f){
                Application.Quit();
        }
    }
}
