using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaJogador : MonoBehaviour
{
    public Camera Camera;
    public float Velocidade = 10;

    // Update is called once per frame
    void Update()
    {
        float eixoX = Input.GetAxis("Horizontal");  // -1 left, 0 middle, 1 right (teclas para esquerda e para direita)
        float eixoZ =  Input.GetAxis("Vertical");   // -1 down, 0 middle, 1 up (teclas para cima e para baixo)

        Vector3 direcao = new Vector3(eixoX, 0 , eixoZ);
        Vector3 direcao_camera = new Vector3(eixoX, eixoZ, 0);

        this.transform.Translate(direcao * this.Velocidade * Time.deltaTime); //movimentar na direção Z

        // identificar se o objeto está se movendo
        if( direcao != Vector3.zero ){
            // GetComponent é usado para obter obter os componentes dos objetos
            // Animator é o componente que usaremos
            // SetBool é o método usado para setar uma variável com boolean
            // Movendo é a variável definida na animação do objeto para controlar a troca de estados
            GetComponent<Animator>().SetBool("Movendo", true);
        }else{
            GetComponent<Animator>().SetBool("Movendo", false);
        }

        Camera.transform.Translate(direcao_camera * this.Velocidade * Time.deltaTime); // movimentação da camera
    }
}
