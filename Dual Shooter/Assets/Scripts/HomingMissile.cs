using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;
    public float rotateSpeed = 220f;
    public bool rightToLeft = false;
    public GameObject homingExplode;

    public string targetName;

    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag(targetName).transform;
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 7);
    }

  

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target != null)
        {

            Vector2 direction = (Vector2)target.position - rb.position;

            direction.Normalize();

            float rotateAmount = Vector3.Cross(direction, transform.right).z;

                rb.angularVelocity = -rotateAmount * rotateSpeed;
                rb.velocity = transform.right * speed;
        }
        }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") || other.CompareTag("Player2") || other.CompareTag("Proiettile"))
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        GameObject PlayerEffect = Instantiate(homingExplode, transform.position, transform.rotation) as GameObject;
        Destroy(PlayerEffect, 2f);
    }

}
