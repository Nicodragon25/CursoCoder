using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] protected PlayerData playerStats;

    public float jumpForce;
    [SerializeField] int runtimeHp;
    [SerializeField] float runtimeSpeed;
    float mouseX;
    bool canRotate;
    void Start()
    {
        playerStats.Score = GameManager.instance.score;
        runtimeHp = playerStats.HP;
        runtimeSpeed = playerStats.Speed;
        canRotate = true;
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
        transform.Translate(direction * runtimeSpeed * Time.deltaTime);
    }

    void TakeDamage(int damageTaken)
    {
        runtimeHp = runtimeHp - damageTaken;

        if (runtimeHp <= 0)
        {
            OnPlayerDeath?.Invoke();
            canRotate = false;
            runtimeSpeed = 0;
        }
    }

    void Healing(int healAmount)
    {
        runtimeHp = runtimeHp + healAmount;
    }

    void PlayerRotation()
    {
        if (canRotate)
        {
            mouseX += Input.GetAxis("Mouse X");
            transform.rotation = Quaternion.Euler(0, mouseX, 0);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            switch (other.gameObject.name)
            {
                case "Enemy":
                    TakeDamage(other.gameObject.GetComponent<EnemyChaser>().enemyStats.dmg);
                    break;
                case "Strong Enemy":
                    TakeDamage(other.gameObject.GetComponent<EnemyChaser>().enemyStats.dmg);
                    break;
                case "Sentinel Enemy":
                    TakeDamage(other.gameObject.GetComponent<EnemySentinel>().enemyStats.dmg);
                    break;
                case "Static Enemy":
                    TakeDamage(other.gameObject.GetComponent<EnemyStatic>().enemyStats.dmg);
                    break;
            }
        }
    }

    public event Action OnPlayerDeath;
}
