using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float hp;
    public Vector3 playerScale;
    public Vector3 playerDirection;
    void Start()
    {
        transform.localScale = new Vector3(playerScale.x, playerScale.y, playerScale.z);


        TakeDamage(40);
        Healing(15);
        Debug.Log(hp);
        Debug.Assert(playerDirection.x <= 1, "Por favor, elegir la/las direcciones colocando \"1\" en el eje que desee mover al personaje");
        Debug.Assert(playerDirection.y <= 1, "Por favor, elegir la/las direcciones colocando \"1\" en el eje que desee mover al personaje");
        Debug.Assert(playerDirection.z <= 1, "Por favor, elegir la/las direcciones colocando \"1\" en el eje que desee mover al personaje");
    }

    void Update()
    {

        /* if (Input.GetKey("w"))
         {
             PlayerMovement(Vector3.forward);
         }
        */
        PlayerMovement(playerDirection);
    }


    void PlayerMovement(Vector3 direction)
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void TakeDamage(int damageTaken)
    {
        hp = hp - damageTaken;
    }

    void Healing(int healAmount)
    {
        hp = hp + healAmount;
    }
}
