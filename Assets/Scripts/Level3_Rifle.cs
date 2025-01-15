using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3_Rifle : MonoBehaviour
{
    [Header("Rifle Things")]
    public Camera cam;
    public float giveDamageOf = 10f;
    public float shootingRange = 100f;
    public float fireCharge = 15f;
    private float nextTimeToShoot = 0f;
    public Level3_PlayerScript player;
    public Transform hand;

    public Animator animator;


    [Header("Rifle Ammunition ans shooting")]
    private int maximumAmmunation = 32;
    public int mag = 10;

    private void Awake()
    {
        transform.SetParent(hand);
    }

    [Header("Rifle Effects")]
    public ParticleSystem muzzleSpark;
    public GameObject WoodenEffect;
    public GameObject goreEffect;

    [Header("Sounds and UI")]
    public AudioClip shootingSound;
    public AudioClip reloading;
    public AudioSource audioSource;

    private void Update()
    {
        // Shooting logic goes here
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToShoot)
        {
            nextTimeToShoot = Time.time + 1f / fireCharge;
            animator.SetBool("Fire", true);
            animator.SetBool("Idle", false);

            // Start the muzzleSpark particle system when shooting
            StartMuzzleSpark();

            Shoot();
        }
        else if (!Input.GetButton("Fire1"))
        {
            // Stop the muzzleSpark particle system when shooting stops
            muzzleSpark.Stop();
            animator.SetBool("Fire", false);
            animator.SetBool("Idle", true);
            animator.SetBool("FireWalk", false);
        }
        else if ((Input.GetButton("Fire1") && Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.UpArrow) && Input.GetButton("Fire1")))
        {
            animator.SetBool("Idle", false);
            animator.SetBool("FireWalk", true);
        }

        else if (Input.GetButton("Fire1") && Input.GetButton("Fire2"))
        {
            animator.SetBool("Idle", false);
            animator.SetBool("IdleAim", true);
            animator.SetBool("FireWalk", true);
            animator.SetBool("Walk", true);
            animator.SetBool("Reloading", false);
        }

        else
        {
            animator.SetBool("Fire", false);
            animator.SetBool("Idle", true);
            animator.SetBool("FireWalk", false);
        }
    }

    private void Shoot()
    {

        audioSource.PlayOneShot(shootingSound);
        RaycastHit hitInfo;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hitInfo, shootingRange))
        {
            Debug.Log(hitInfo.transform.name);

            Level3_Zombie zombie1 = hitInfo.transform.GetComponent<Level3_Zombie>();

            if (zombie1 != null)
            {
                zombie1.zombieHitDamage(giveDamageOf);
                GameObject goreEffectGo = Instantiate(goreEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                Destroy(goreEffectGo, 1f);
            }

            Level3_Titan titan =hitInfo.transform.GetComponent<Level3_Titan>();

            if(titan != null)
            {
                titan.titanHitDamage(giveDamageOf);
                GameObject goreEffectGo = Instantiate(goreEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                Destroy(goreEffectGo, 1f);
            }
        }
        audioSource.PlayOneShot(reloading);
    }

    private void StartMuzzleSpark()
    {
        // Ensure the muzzleSpark is not playing before starting it
        if (!muzzleSpark.isPlaying)
        {
            muzzleSpark.Play();
        }
    }

    public void StopShooting()
    {
        muzzleSpark.Stop(); // Stop the muzzle flash particle system.
    }

}
