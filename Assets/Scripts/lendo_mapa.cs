using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO; //necessário para leitura do arquivo

public class lendo_mapa : MonoBehaviour
{
    public GameObject parede;
    public GameObject fox;
    public GameObject chicken;
    GameObject chicken_instantiated;
    public GameObject teleport;
    public GameObject blind;
    public GameObject freeze;
    public GameObject reduced_vision;
    public GameObject reverse_movement;
    public GameObject chicken_item;

    public int[,] mapa = new int[70, 70];
    
    //--------------------------
    // Start is called before the first frame update
    void Start()
    {
        CriaMapa();
    }

    public void CriaMapa () {
        // -- Comando para ler do arquivo e salvar na matriz de inteiros --
        //meu arquivo é um csv, mas funciona com qualquer extensão de arquivo
        string arquivo = File.ReadAllText( @"C:\Workspace\projetos_unity\create_with_code\trabalho_final\Assets\Files\mapa.csv" );
        int i=0, j=0;
        
        foreach (var row in arquivo.Split('\n')) {
            j = 0;
            //separei meus números com vírgula, se o de vocês for espaço é só trocar no .Split()
            foreach (var col in row.Trim().Split(',')) { 
                mapa[i, j] = int.Parse(col.Trim());
                j++;
            }
            i++;
        }                                                                 
        // ----------------------------------------------------------------
        
        // -- percorre a matriz e insere o objeto quando lê 1 na matriz ---
        for (i=0; i<70; i++) {
            for (j=0; j<70; j++) {
                if (mapa[i,j] == 1){
                    //-20 é o ajuste para começar na parte superior esquerda
                    //posiciona em 1 de altura, pois o objeto altura 2 tem tamanho 1 para cima e 1 para baixo
                    Vector3 p = new Vector3(i-34.5f, 1.0f, j-34.5f); 
                    Instantiate(parede, p, Quaternion.identity);
                }
                if (mapa[i,j] == 2){
                    Vector3 f = new Vector3(i-34.5f, 0.05f, j-34.5f); 
                    Instantiate(fox, f, Quaternion.identity);
                }
                if (mapa[i,j] == 3){
                    Vector3 c = new Vector3(i-34.5f, 0.05f, j-34.5f); 
                    Instantiate(chicken, c, Quaternion.identity);
                }
                if (mapa[i,j] == 4){
                    Vector3 t = new Vector3(i-34.5f, 1.0f, j-34.5f); 
                    Instantiate(teleport, t, Quaternion.identity);
                }
                if (mapa[i,j] == 5){
                    Vector3 b = new Vector3(i-34.5f, 1.0f, j-34.5f); 
                    Instantiate(blind, b, Quaternion.identity);
                }
                if (mapa[i,j] == 6){
                    Vector3 fz = new Vector3(i-34.5f, 1.0f, j-34.5f); 
                    Instantiate(freeze, fz, Quaternion.identity);
                }
                if (mapa[i,j] == 7){
                    Vector3 r = new Vector3(i-34.5f, 1.0f, j-34.5f); 
                    Instantiate(reduced_vision, r, Quaternion.identity);
                }
                if (mapa[i,j] == 8){
                    Vector3 re = new Vector3(i-34.5f, 1.0f, j-34.5f); 
                    Instantiate(reverse_movement, re, Quaternion.identity);
                }
                if (mapa[i,j] == 9){
                    Vector3 c_i = new Vector3(i-34.5f, 1.0f, j-34.5f); 
                    Instantiate(chicken_item, c_i, Quaternion.identity);
                }
            }    
        }
        // ----------------------------------------------------------------
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
