using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public GameObject arrowPrefab;
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot(player.transform.localRotation.eulerAngles);
        }
    }

    private void Shoot(Vector3 Rotation)
    {
        Instantiate(arrowPrefab, transform.position, transform.rotation = Quaternion.Euler(Rotation));
    }
}
