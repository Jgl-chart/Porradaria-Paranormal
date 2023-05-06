using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public int DamageDiceNumber = 1;
    public int DamageDice = 10;
    public int Soma = 0;

    private float Damage = 10f;
    public float range = 100f;

    public float impactForce = 100f;

    public Camera fpsCam;
    public ParticleSystem particles;

    public GameObject impacEffect;

    public float fireRate = 15f;
    private float nextTimeToFire;

    private void Start()
    {
        if(fpsCam == null)
        {
            fpsCam = Camera.current;
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            Damage = GameManager.RollDanoDice(DamageDiceNumber, DamageDice, Soma);
            nextTimeToFire = Time.time + 1f / fireRate;
            particles.Play();
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            if(hit.transform.TryGetComponent<Target>(out Target target))
            {
                target.TakeDamage(Damage);
                
            }

            if (hit.transform.TryGetComponent<Rigidbody>(out Rigidbody rb))
            {
                rb.AddForce(-hit.normal * impactForce);

            }

            GameObject impactGo = Instantiate(impacEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGo, 2f);

        }

    }
}
