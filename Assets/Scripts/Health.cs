using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    public bool isDead = false;
    [SerializeField] bool isPlayer;
    [SerializeField] bool isZombie;
    

    public bool IsDead()
    {
        return isDead;
    }

    public void TakeDamage(float damage)
    {   
        if(isZombie)
            BroadcastMessage("OnDamageTaken");
        if (isDead) return;
            hitPoints -= damage;
        if (hitPoints <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        if (isDead) return;
        isDead = true;
    }
    
}