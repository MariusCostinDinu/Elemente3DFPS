using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField] ParticleSystem flash;
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 25;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;

    [SerializeField] TextMeshProUGUI ammoText;

    void Update()
    {
        DisplayAmmo();
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }       
    
    }

    private void DisplayAmmo()
    {
        int currentAmmo = ammoSlot.GetCurrentAmmo();
        ammoText.text = currentAmmo.ToString();
    }

    //ray cast
    private void Shoot()
    {



        PlayMuzzleFlash();
        if (ammoSlot.GetCurrentAmmo() > 0)
        {
            ammoSlot.ReduceCurentAmmo();
            RaycastHit hit;
            //from direcrection and distance
            if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
            {
                //Debug.Log("hit:" + hit.transform.name);
                CreateHitImact(hit);
                EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
                if (target == null) return;
                target.TakeDamage(damage);
            }
            else
            {
                return;
            }
        }       
    }

    private void CreateHitImact(RaycastHit hit)
    {
       GameObject impact= Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal)); // hiting normals
        Destroy(impact, 1);
    }

    private void PlayMuzzleFlash()
    {
        flash.Play();
    }
}
