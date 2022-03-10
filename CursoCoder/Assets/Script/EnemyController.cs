using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject player;
    public GameObject shootPoint;
    public float lerpSmoothness;

    public float speed;
    public float startSpeed;
    public float h;
    float rayDistance = 20f;
    float secondRayDistance = 2f;


    RaycastHit hit;
    public enum EnemyTypes {Enemigo1, Enemigo2, Enemigo3};
    [SerializeField] public EnemyTypes enemyType;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        startSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        // hice para probar la forma matematica de calcular la distancia entre 2 puntos
        //h = Mathf.Sqrt( Mathf.Pow(transform.position.x - player.transform.position.x, 2) + Mathf.Pow(transform.position.z - player.transform.position.z, 2));
        
        switch (enemyType)
        {

            case EnemyTypes.Enemigo1:
               Quaternion lookAt = Quaternion.LookRotation(player.transform.position - transform.position);
                Quaternion actualRotation = transform.rotation;
                transform.rotation = Quaternion.Lerp(actualRotation, lookAt, lerpSmoothness);
            break;

            case EnemyTypes.Enemigo2:
                lookAt = Quaternion.LookRotation(player.transform.position - transform.position);
                actualRotation = transform.rotation;
                transform.rotation = Quaternion.Lerp(actualRotation, lookAt, lerpSmoothness);

                transform.Translate(Vector3.forward * speed * Time.deltaTime);
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, secondRayDistance))
                {
                    speed = 0;
                }
                if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, secondRayDistance))
                {
                    speed = startSpeed;
                }

                break;
            case EnemyTypes.Enemigo3:
                RayCasting();
                break;
            default:
                Debug.Log("Error: no se seleccionó un tipo de enemigo válido");
            break;
        }
    }

    void RayCasting()
    {
        if (Physics.Raycast(shootPoint.transform.position, shootPoint.transform.TransformDirection(Vector3.forward), out hit, rayDistance))
        {
            if (hit.collider.CompareTag("Player"))
            {
                enemyType = EnemyTypes.Enemigo2;
            }
        }
    }
    private void OnDrawGizmos()
    {
        if (enemyType == EnemyTypes.Enemigo3)
        {
            Gizmos.color = Color.white;
            Vector3 direction = shootPoint.transform.TransformDirection(Vector3.forward) * rayDistance;
            Gizmos.DrawRay(shootPoint.transform.position, direction);
        }
    }
}
