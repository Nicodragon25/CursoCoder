using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float hp;
    public Vector3 playerScale;
    public Vector3 playerDirection;

    float mouseX;
    void Start()
    {
        transform.localScale = new Vector3(playerScale.x, playerScale.y, playerScale.z);
    }

    void Update()
    {

         if (Input.GetKey("w"))
         {
             PlayerMovement(Vector3.forward);
         }
        if (Input.GetKey("s"))
        {
            PlayerMovement(Vector3.back);
        }
        if (Input.GetKey("a"))
        {
            PlayerMovement(Vector3.left);
        }
        if (Input.GetKey("d"))
        {
            PlayerMovement(Vector3.right);
        }

        PlayerRotation();
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

    void PlayerRotation()
    {
        mouseX += Input.GetAxis("Mouse X");

        transform.rotation = Quaternion.Euler(0, mouseX,0);
    }
}
