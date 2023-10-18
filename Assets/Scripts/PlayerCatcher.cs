using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCatcher : MonoBehaviour
{
    public PlayerHealth target;
    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player")
        {
            target = other.GetComponent<PlayerHealth>();
        }    
    }
}
