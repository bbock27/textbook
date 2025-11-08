using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{

    public GameObject bulletPrefab;
    public GameObject spawnLoaction;
    public ParticleSystem muzzleFlash;
    Animator animator;
    
    public float fireRate;

    public int bulletsAmount;

    public AudioSource shootSound;
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKey(KeyCode.Mouse0)){
        //     GameObject bullet = Instantiate(bulletPrefab, spawnLoaction.transform.position, spawnLoaction.transform.rotation);
        // }
    }

    public void OnFire(InputValue value){
        if(value.isPressed)
        {
            animator.SetBool("Shooting", value.isPressed);
            InvokeRepeating("Shoot", fireRate, fireRate);
        }
        else
        {
            animator.SetBool("Shooting", value.isPressed);
            CancelInvoke();
        }
    }

    public void Shoot()
    {
        if(bulletsAmount > 0 && Time.timeScale != 0)
        {
            bulletsAmount -= 1;
            GameObject clone = Instantiate(bulletPrefab, spawnLoaction.transform.position,
                spawnLoaction.transform.rotation);
            muzzleFlash.Play();
            shootSound.Play();
        }
    }
}
