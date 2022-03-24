using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    public int hp;


    void TakeDamage(int dmg)
    {
        hp -= dmg;

        if(hp <= 0)
        {
            gameObject.SetActive(false);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(collision.gameObject.GetComponent<BulletController>().Dmg);
        }
    }
}
