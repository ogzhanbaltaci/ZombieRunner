using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    //[SerializeField] GameObject bloodHitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] ProceduralRecoil proceduralRecoil;
    [SerializeField] float timeBetweenShots = 0.5f;

    bool canShoot = true;
    private void OnEnable() 
    {
        canShoot =  true;    
    }

    void Update()
    {
        if(Input.GetMouseButton(0) && canShoot == true)
        {
            StartCoroutine(Shoot());   
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if(ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            PlayMuzzleFlash();
            ProcessRaycast();
            proceduralRecoil.Recoil();
            ammoSlot.ReduceCurrentAmmo(ammoType);
        }
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {   
            CreateHitImpact(hit, hitEffect);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit, GameObject effect)
    {
        GameObject impact = Instantiate(effect, hit.point, Quaternion.LookRotation(hit.normal));

        Destroy(impact, 1f);
    }
}
