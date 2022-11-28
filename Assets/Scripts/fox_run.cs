using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fox_run : MonoBehaviour
{
    private float speed = 4.0f;
    private float turnSpeed = 150.0F; 
    private float horizontalInput;
    private float forwardInput;

    Transform camera;

    Vector3 player_movement;

    Animator player_animator;

    bool has_horizontal_input;

    bool has_vertical_input;

    bool isRunning;
    float cont;

    public bool IsActive = true;
    public bool IsBlind = false;
    public bool ReducedVision = false;
    public bool reverse_movement = false;

    void Start()
    {
        player_animator = GetComponent<Animator>();
        camera = transform.Find("FoxCamera");
        horizontalInput = 0;
        forwardInput = 0;
    }

    void LateUpdate()
    {
        if(reverse_movement){
            /// Pega o movimento a partir das setas e atualiza no respectivo eixo
            if(Input.GetKeyDown(KeyCode.W)){
                forwardInput = -1;
            }
            if(Input.GetKeyDown(KeyCode.S)){
                forwardInput = 1;
            }
            if(Input.GetKeyDown(KeyCode.A)){
                horizontalInput = 1;
            }
            if(Input.GetKeyDown(KeyCode.D)){
                horizontalInput = -1;
            }
            // Faz com que o player não fique andando infinitamente
            if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S)){
                forwardInput = 0;
            }
            if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)){
                horizontalInput = 0;
            }

            cont = cont + Time.deltaTime;
            if (cont > 10.0f)
            {
                reverse_movement = false;
                cont= 0.0f;
            }
        }else{
            /// Pega o movimento a partir das setas e atualiza no respectivo eixo
            if(Input.GetKeyDown(KeyCode.W)){
                forwardInput = 1;
            }
            if(Input.GetKeyDown(KeyCode.S)){
                forwardInput = -1;
            }
            if(Input.GetKeyDown(KeyCode.A)){
                horizontalInput = -1;
            }
            if(Input.GetKeyDown(KeyCode.D)){
                horizontalInput = 1;
            }
            // Faz com que o player não fique andando infinitamente
            if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S)){
                forwardInput = 0;
            }
            if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)){
                horizontalInput = 0;
            }
        }

        //Pega os valores horizontais e verticais a cada frame
        player_movement.Set(horizontalInput, 0f, forwardInput);

        //"Normaliza" a velocidade do movimento(o Vector3) para que não pegue mais velocidade na diagonal
        player_movement.Normalize ();

        //Inicializa a variável booleana para verificar se existe algum input horizontal
        has_horizontal_input = !Mathf.Approximately (horizontalInput, 0f);

        //Inicializa a variável booleana para verificar se existe algum input vertical
        has_vertical_input = !Mathf.Approximately (forwardInput, 0f);

        //Combina as duas variáveis booleanas anteriores
        isRunning = has_horizontal_input || has_vertical_input;

        //Seta o booleano do animator com o valor da variável 'isRunning'
        player_animator.SetBool ("IsRunning", has_vertical_input);
    }

    void OnAnimatorMove ()
    {
        if(IsActive)
        {       
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
        }
        if(IsActive == false){
            cont = cont + Time.deltaTime;
            if (cont > 5.0f)
            {
                IsActive = true;
                cont= 0.0f;
            }
        }
        if(IsBlind){
            cont = cont + Time.deltaTime;

            camera.GetComponent<field_of_view_fox>().m_FieldOfView_fox = 0f;

            if (cont > 5.0f)
            {
                IsBlind = false;
                camera.GetComponent<field_of_view_fox>().m_FieldOfView_fox = 60f;
                cont= 0.0f;
            }
        }
        if(ReducedVision){
            cont = cont + Time.deltaTime;

            camera.GetComponent<field_of_view_fox>().m_FieldOfView_fox = 30f;

            if (cont > 5.0f)
            {
                ReducedVision = false;
                camera.GetComponent<field_of_view_fox>().m_FieldOfView_fox = 60f;
                cont= 0.0f;
            }
        }
    }

}