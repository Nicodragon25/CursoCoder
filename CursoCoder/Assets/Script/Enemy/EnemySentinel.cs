using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySentinel : EnemyController
{
    bool isChaser = false;

   protected override void Update()
    {
        if (!isChaser) RayCasting();
        if (isChaser)
        {
            base.Update();
        }
    }

    void RayCasting()
    {
        if (Physics.Raycast(shootPoint.transform.position, shootPoint.transform.TransformDirection(Vector3.forward), out hit, enemyStats.rayDistance))
        {
            if (hit.collider.CompareTag("Player"))
            {
                isChaser = true;
            }
        }
    }
}
