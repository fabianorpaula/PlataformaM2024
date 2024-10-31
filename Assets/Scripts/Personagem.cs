using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour
{

    public Rigidbody2D Corpo;
    void Start()
    {
        Corpo = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float velH = Input.GetAxis("Horizontal")*4;
        float velY = Corpo.velocity.y;
        Corpo.velocity = new Vector2 (velH, velY);
    }
}
