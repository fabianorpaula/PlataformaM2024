using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Atirador : MonoBehaviour
{
    public GameObject Bala;
    

    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameObject myBala = Instantiate(Bala,
                transform.position,
                Quaternion.identity);
            Destroy(myBala,3f);
            if(transform.localScale.x == 1)
            {
                myBala.GetComponent<Rigidbody2D>().velocity = 
                    new Vector2(5, 0);
            }
            if (transform.localScale.x == -1)
            {
                {
                    myBala.GetComponent<Rigidbody2D>().velocity =
                        new Vector2(-5, 0);
                }
            }



        }
    }
}
