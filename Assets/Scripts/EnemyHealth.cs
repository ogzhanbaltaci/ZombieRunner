using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    private EnemyAI enemyAI;

    private void Start()
    {
        enemyAI = GetComponent<EnemyAI>();
    }

    protected override void Die()
    {
        base.Die(); 
        enemyAI.isProvoked = false;
        GetComponent<CapsuleCollider>().enabled = false;
        GetComponent<Animator>().SetTrigger("Die");
    }
}
