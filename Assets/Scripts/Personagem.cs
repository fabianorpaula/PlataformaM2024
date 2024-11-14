using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Personagem : MonoBehaviour
{

    public Rigidbody2D Corpo;
    public Animator Animador;
    public GameObject Espada;
    public GameObject Bala;
    public float barraDeVida = 10;
    public Image ImagemBarraDeVida;

    public bool estadoJogo = true;

    void Start()
    {
        Corpo = GetComponent<Rigidbody2D>();
        Animador = GetComponent<Animator>();
    }

    void Update()
    {

        if (estadoJogo == true)
        {
            Mover();
            Atacar();
        }


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
            

        }
    }


    public void ChamarAtaqueDistancia()
    {
        //DetectarLado
        //Olhando Pra Frente
        if(transform.localScale.x == 1)
        {
            Vector3 posBala = new Vector3(transform.position.x + 1f, 
                transform.position.y, transform.position.z);   
            GameObject MinhaBala = Instantiate(Bala, posBala, Quaternion.identity);
            Destroy(MinhaBala, 2f);
            MinhaBala.GetComponent<Rigidbody2D>().velocity = new Vector2(5, 0);
        }
        //Olhando Pra Trás
        if (transform.localScale.x == -1)
        {
            Vector3 posBala = new Vector3(transform.position.x - 1f,
                transform.position.y, transform.position.z);
            GameObject MinhaBala = Instantiate(Bala, posBala, Quaternion.identity);
            Destroy(MinhaBala, 2f);
            MinhaBala.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, 0);
        }

        
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

    //TomarDano
    public void TomouDano()
    {
        Animador.SetTrigger("Dano");
    }

    public void PederVida()
    {
        barraDeVida--;
        ImagemBarraDeVida.GetComponent<RectTransform>().sizeDelta = 
            new Vector2(barraDeVida*50, 50);
        if(barraDeVida <= 0)
        {
            //MORREU // FOI DE VELHO DA BOMBA DO STF
            
            estadoJogo = false;
            Animador.SetBool("Vida", false);
            Animador.SetTrigger("Morreu");
            Morte();
        }
    }

    void Morte()
    {
        GameObject.FindGameObjectWithTag("Cenas").
            GetComponent<TrocarCena>().IniciarGameOver();
    }
}
