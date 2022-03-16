using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject player;
    public GameObject shootPoint;

    [SerializeField] protected EnemyData enemyStats;

    protected bool canMove;
    protected float startSpeed;
    protected RaycastHit hit;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        shootPoint = transform.GetChild(0).gameObject;
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
        if(canMove) transform.Translate(Vector3.forward * enemyStats.Speed * Time.deltaTime);
    }
    protected void LookPlayer()
    {
        Quaternion lookAt = Quaternion.LookRotation(player.transform.position - transform.position);
        Quaternion actualRotation = transform.rotation;
        transform.rotation = Quaternion.Lerp(actualRotation, lookAt, enemyStats.lerpSmoothness);
    }
}
