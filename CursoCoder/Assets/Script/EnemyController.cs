using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject player;
    public float lerpSmoothness;

    public float speed;
    public float h;


    enum EnemyTypes {Enemigo1, Enemigo2};
    [SerializeField] EnemyTypes enemyType;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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

                // ahora usé la forma supongo esperada de medir distancias, por una cuestion de lo sencilla que es
                // en comparacion al otro choclazo de codigo jajaja
                if (Vector3.Distance(transform.position, player.transform.position) > 2)
                {
                    transform.Translate(Vector3.forward * speed * Time.deltaTime);
                }

                
            break;
        }
    }
}
