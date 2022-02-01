using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed;
    public Vector3 Direction;
    public float Dmg;
    public float destroyTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * bulletSpeed * Time.deltaTime);
        Destroy(gameObject, destroyTime);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.localScale = transform.localScale * 2;
        }
    }
}
