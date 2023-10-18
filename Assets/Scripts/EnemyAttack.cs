using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerCatcher playerCatcher;
    
    [SerializeField] float damage = 40f;
    void Start()
    {
        playerCatcher = GetComponentInChildren<PlayerCatcher>();
        
    }

    public void AttackHitEvent()
    {
        if(playerCatcher.target == null) return;
        playerCatcher.target.TakeDamage(damage);
        playerCatcher.target.GetComponent<DisplayDamage>().ShowDamageImpact();
    }

    
}
