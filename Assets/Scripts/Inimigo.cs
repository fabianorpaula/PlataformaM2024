using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ataque")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Bala")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Personagem>().TomouDano();
        }
    }


}
