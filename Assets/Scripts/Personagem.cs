using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour
{

    public Rigidbody2D Corpo;
    public Animator Animador;
    public GameObject Espada;
    public GameObject Bala;

    void Start()
    {
        Corpo = GetComponent<Rigidbody2D>();
        Animador = GetComponent<Animator>();
    }

    void Update()
    {
        Mover();
        Atacar();


    }

    void Mover()
    {
        float velH = Input.GetAxis("Horizontal") * 4;
        if(velH < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            Animador.SetBool("Andar", true);
        }
        if (velH > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            Animador.SetBool("Andar", true);
        }
        if(velH == 0)
        {
            Animador.SetBool("Andar", false);
        }


        float velY = Corpo.velocity.y;
        Corpo.velocity = new Vector2(velH, velY);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Pular();
        }

    }

    void Pular()
    {
        Corpo.AddForce(Vector3.up * 300);
    }

    void Atacar()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Animador.SetTrigger("Ataque");
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Animador.SetTrigger("Disparo");
            ChamarAtaqueDistancia();

        }
    }


    void ChamarAtaqueDistancia()
    {
        GameObject MinhaBala = Instantiate(Bala, transform.position, Quaternion.identity);
        Destroy(MinhaBala,2f);
        MinhaBala.GetComponent<Rigidbody2D>().velocity = new Vector2(5, 0);
    }

    //Ativar e Desativar Espada

    public void AtivaEspada()
    {
        Espada.SetActive(true);
    }

    public void DesativaEspada()
    {
        Espada.SetActive(false);
    }

}
