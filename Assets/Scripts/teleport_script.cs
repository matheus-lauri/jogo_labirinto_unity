using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport_script : MonoBehaviour
{
    public GameObject ground;
    int[,] mapa_read = new int[70, 70];
    int rand_number_x = 0;
    int rand_number_y = 0;

    int GeraNumeroRandom(){
        int rand_num = Random.Range(2, 68);
        return rand_num;
    }
    private void OnTriggerEnter(Collider other) {
         mapa_read = ground.GetComponent<lendo_mapa>().mapa;
            do{
                rand_number_x = GeraNumeroRandom();
                rand_number_y = GeraNumeroRandom();
            }while(mapa_read[rand_number_x,rand_number_y] != 0);
            Vector3 position = new Vector3(rand_number_x - 34, 0.05f, rand_number_y - 34);
            Instantiate(other.gameObject, position, Quaternion.identity);
            Destroy(other.gameObject);
    }
}
