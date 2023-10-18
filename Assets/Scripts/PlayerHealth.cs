using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    private DeathHandler deathHandler;

    private void Start()
    {
        deathHandler = GetComponent<DeathHandler>();
    }

    protected override void Die()
    {
        base.Die(); 
        deathHandler.HandleDeath();
    }
}
