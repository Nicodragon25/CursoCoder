using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyController : MonoBehaviour
{
    public GameObject player;
    public GameObject shootPoint;

    [SerializeField] public EnemyData enemyStats;
    protected bool canMove;
    protected float startSpeed;
    protected RaycastHit hit;

    float runtimeSpeed;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        shootPoint = transform.GetChild(0).gameObject;
        FindObjectOfType<Player>().OnPlayerDeath += PlayerDead;
    }
    private void Start()
    {
        runtimeSpeed = enemyStats.Speed;
    }
    protected virtual void Update()
    {
        // hice para probar la forma matematica de calcular la distancia entre 2 puntos
        //h = Mathf.Sqrt( Mathf.Pow(transform.position.x - player.transform.position.x, 2) + Mathf.Pow(transform.position.z - player.transform.position.z, 2));
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, enemyStats.secondRayDistance))
        {
            canMove = false;
        }
        if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, enemyStats.secondRayDistance))
        {
            canMove = true;
        }
        LookPlayer();
        Move();
    }

    
    private void OnDrawGizmos()
    {
            Gizmos.color = Color.white;
            Vector3 direction = shootPoint.transform.TransformDirection(Vector3.forward) * enemyStats.rayDistance;
            Gizmos.DrawRay(shootPoint.transform.position, direction);
    }

    protected void Move()
    {
        if(canMove) transform.Translate(Vector3.forward * runtimeSpeed * Time.deltaTime);
    }
    protected void LookPlayer()
    {
        Quaternion lookAt = Quaternion.LookRotation(player.transform.position - transform.position);
        Quaternion actualRotation = transform.rotation;
        transform.rotation = Quaternion.Lerp(actualRotation, lookAt, enemyStats.lerpSmoothness);
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name == "Player")
        {
            Destroy(gameObject, 0.5f);
        }
    }

    public void PlayerDead()
    {
        runtimeSpeed = 0;
    }
}
