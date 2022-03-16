using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] protected PlayerData playerStats;

    float runtimeHp;
    float mouseX;
    void Start()
    {
        playerStats.Score = GameManager.instance.score;
        runtimeHp = playerStats.HP;
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

        GameManager.instance.playerScore = playerStats.Score;
    }


    void PlayerMovement(Vector3 direction)
    {
        transform.Translate(direction * playerStats.Speed * Time.deltaTime);
    }

    void TakeDamage(int damageTaken)
    {
        runtimeHp = runtimeHp - damageTaken;
    }

    void Healing(int healAmount)
    {
        runtimeHp = runtimeHp + healAmount;
    }

    void PlayerRotation()
    {
        mouseX += Input.GetAxis("Mouse X");

        transform.rotation = Quaternion.Euler(0, mouseX,0);
    }
}
