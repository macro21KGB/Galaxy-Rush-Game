using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


    [Header("Player Stats")]
    [SerializeField] int health = 500;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] GameObject Playerdead;

    [Header("Projectile Options")]
    [SerializeField] GameObject missilePrefab;
    [SerializeField] float projectileSpeed = 5f;
    [SerializeField] int magazineCapacity = 10;
    [SerializeField] float ReloadTime = 1.0f;

    [Header("Dual PLayer Options")]
    [SerializeField] float padding = 1.0f;
    [SerializeField] string HorizontalAxis = "Horizontal";
    [SerializeField] string VerticalAxis = "Vertical";
    [SerializeField] string FireThing = "Fire1";
    [Header("VFX - SFX")]
    [SerializeField] AudioClip playerDeadSound;
    [SerializeField] [Range(0,1)] float deathSoundVolume = 0.75f;
    [SerializeField] AudioClip playerShootSound;
    [SerializeField] [Range(0,1)] float shootSoundVolume = 0.75f;
    [SerializeField] AudioClip playerHitSound;
    [SerializeField] [Range(0, 1)] float hitSoundVolume = 0.40f;

    float xMin;
    float xMax;
    float yMin;
    float yMax;

    private CameraShake shake;
    int clipAmount;
    float shootInstanceTime;

    // Use this for initialization
    void Start () {

        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<CameraShake>();
        shootInstanceTime = ReloadTime;
        SetUpMoveBoundaries();
        clipAmount = magazineCapacity;
    }
	
	// Update is called once per frame
	void Update () {
        Move();
        Shoot();
        if (clipAmount != magazineCapacity) { Reload(); }

  
    }

    //Funzione di Sparo
    private void Shoot()
    {
        if (Input.GetButtonDown(FireThing) && clipAmount > 0)
        {
            AudioSource.PlayClipAtPoint(playerShootSound, Camera.main.transform.position, deathSoundVolume);
            var newProjectile = Instantiate(missilePrefab, transform.position, Quaternion.identity);
            newProjectile.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed, 0);
            clipAmount -= 1;

            
        }
    }





    //Ritrona la vita corrente del Player
    public int getHealth()
    {
        return health;
    }

    // Ritorna il numero di proiettili
    public int getAmmoClip()
    {
        return clipAmount;
    }

    //Funzioni di ricarica dei missili
    private void Reload()
    {

        shootInstanceTime -= Time.deltaTime;
        if (shootInstanceTime <= 0)
        {
            clipAmount += 1;
            shootInstanceTime = ReloadTime;
        }

    }


    //Movimento
    private void Move()
    {
            var deltaX = Input.GetAxis(HorizontalAxis) * Time.deltaTime * moveSpeed;
            var deltaY = Input.GetAxis(VerticalAxis) * Time.deltaTime * moveSpeed;

            var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
            var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
            transform.position = new Vector2(newXPos, newYPos);
    }


    //Quando avvien una collisione con un prioettile nemico o il nemico stesso
    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProcessHit(damageDealer);
    }

    //Scala la vita del Player e la morte
    private void ProcessHit(DamageDealer damageDealer)
    {
        shake.CamShake();
        AudioSource.PlayClipAtPoint(playerHitSound, Camera.main.transform.position, hitSoundVolume);
        health -= damageDealer.getDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Die();
        }
    }



    //Quando Il Player Muore
    private void Die()
    {

        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(playerDeadSound, Camera.main.transform.position, deathSoundVolume);
        GameObject PlayerEffect = Instantiate(Playerdead, transform.position, transform.rotation) as GameObject;
        Destroy(PlayerEffect, 1f);
        
        
    }


    //Setta i confini del Mondo
    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

}
