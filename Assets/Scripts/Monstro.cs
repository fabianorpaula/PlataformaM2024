using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monstro : MonoBehaviour
{
    public int life;
    public Rigidbody2D Corpo;
    public float speedM= 3;


    void Update()
    {
        Corpo.velocity = new Vector2(speedM, 0);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bala")
        {
            Destroy(collision.gameObject);
            life--;
            if(life <= 0)
            {
                Destroy(this.gameObject);
            }
            
        }

        if (collision.gameObject.tag == "LimiteEsquerdo")
        {
            speedM = 3;
        }

        if (collision.gameObject.tag == "LimiteDireito")
        {
            speedM = -3;
        }



    }

}
