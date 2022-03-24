using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed;
    public Rigidbody rb;
    public Vector3 Direction;
    public int Dmg;
    public float destroyTime;
    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(Vector3.forward * bulletSpeed * 5, ForceMode.Impulse);
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Ground")
        {
            Destroy(gameObject, 0.5f);
            Debug.Log(collision.gameObject.name);
        }
    }
}
