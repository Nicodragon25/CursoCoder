using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorController : MonoBehaviour
{
    public GameObject SpawnedObject;

    public bool canShoot = true;
    public float shootingCD;
    public float timePass;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canShoot)
        {
            Spawn(new Vector3(0, 0, 0));
            canShoot = false;
        }
        if (Input.GetKeyDown("j") && canShoot)
        {
            Spawn(new Vector3(0,20,0));
            Spawn(new Vector3(0,-20,0));
            canShoot = false;

        }
        if (Input.GetKeyDown("k") && canShoot)
        {
            Spawn(new Vector3(0, 20, 0));
            Spawn(new Vector3(0, 0, 0));
            Spawn(new Vector3(0, -20, 0));
            canShoot = false;

        }
        if (Input.GetKeyDown("l") && canShoot)
        {
            Spawn(new Vector3(0, 20, 0));
            Spawn(new Vector3(0, 10, 0));
            Spawn(new Vector3(0, -10, 0));
            Spawn(new Vector3(0, -20, 0));
            canShoot = false;

        }
        if (!canShoot)
        {
            timePass += Time.deltaTime;
        }
        if(timePass >= shootingCD)
        {
            canShoot = true;
            timePass = 0;
        }
    }

    private void Spawn(Vector3 Rotation)
    {
        Instantiate(SpawnedObject, transform.position, transform.rotation = Quaternion.Euler(Rotation));
    }
}
