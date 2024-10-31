using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour
{

    public Rigidbody2D Corpo;
    public Animator Animador;
    void Start()
    {
        Corpo = GetComponent<Rigidbody2D>();
        Animador = GetComponent<Animator>();
    }

    void Update()
    {
        Mover();
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
    }
}
