using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reverse_movement_script : MonoBehaviour
{
    public GameObject chicken;
    public GameObject fox;
    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<Rigidbody>().mass == 51){
            Debug.Log("Fox");
            chicken = GameObject.FindWithTag("chickentag");
            chicken.GetComponentInChildren<chicken_run>().reverse_movement = true;
            Destroy(gameObject);
        }else if(other.GetComponent<Rigidbody>().mass == 50){
            Debug.Log("Chicken");
            fox = GameObject.FindWithTag("foxtag");
            fox.GetComponentInChildren<fox_run>().reverse_movement = true;
            Destroy(gameObject);
        }
    }
}
