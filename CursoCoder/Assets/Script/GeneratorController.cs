using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorController : MonoBehaviour
{
    public GameObject SpawnedObject;

    public float spawnDelay;
    public float spawnRate;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Spawn(new Vector3(0, 0, 0));
        }
        if (Input.GetKeyDown("j"))
        {
            Spawn(new Vector3(0, 20, 0));
            Spawn(new Vector3(0, -20, 0));
        }
        if (Input.GetKeyDown("k"))
        {
            Spawn(new Vector3(0, 20, 0));
            Spawn(new Vector3(0, 0, 0));
            Spawn(new Vector3(0, -20, 0));
        }
        if (Input.GetKeyDown("l"))
        {
            Spawn(new Vector3(0, 20, 0));
            Spawn(new Vector3(0, 10, 0));
            Spawn(new Vector3(0, -10, 0));
            Spawn(new Vector3(0, -20, 0));
        }
    }

    private void Spawn(Vector3 Rotation)
    {
        Instantiate(SpawnedObject, transform.position, transform.rotation = Quaternion.Euler(Rotation));
    }
}
