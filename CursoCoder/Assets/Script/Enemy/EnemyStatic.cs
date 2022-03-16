using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatic : EnemyController
{
    protected override void Update()
    {
        LookPlayer();
    }
}
