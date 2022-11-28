using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blind_script : MonoBehaviour
{
    public GameObject chicken;
    public GameObject fox;
    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<Rigidbody>().mass == 51){
            chicken = GameObject.FindWithTag("chickentag");
            chicken.GetComponentInChildren<chicken_run>().IsBlindChicken = true;
            Destroy(gameObject);
        }else if(other.GetComponent<Rigidbody>().mass == 50){
            fox = GameObject.FindWithTag("foxtag");
            fox.GetComponentInChildren<fox_run>().IsBlind = true;
            Destroy(gameObject);
        }
    }
}
