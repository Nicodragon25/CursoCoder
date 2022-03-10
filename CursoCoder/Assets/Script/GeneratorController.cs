using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorController : MonoBehaviour
{
    public GameObject[] SpawnedObjects;

    public bool canShoot = true;
    public float shootingCD;
    public float timePass;
    bool normalBullet = true;
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
        if (Input.GetKeyDown(KeyCode.Alpha1)) normalBullet = true;
        if (Input.GetKeyDown(KeyCode.Alpha2)) normalBullet = false;
    }

    private void Spawn(Vector3 Rotation)
    {
        if(normalBullet) Instantiate(SpawnedObjects[0], transform.position, transform.rotation = Quaternion.Euler(Rotation));
        if(!normalBullet) Instantiate(SpawnedObjects[1], transform.position, transform.rotation = Quaternion.Euler(Rotation));
    }
}
