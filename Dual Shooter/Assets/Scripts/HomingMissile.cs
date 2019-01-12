using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;
    public float rotateSpeed = 220f;
    public bool rightToLeft = false;

    public string targetName;

    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag(targetName).transform;
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5);
    }

  

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target != null)
        {

            Vector2 direction = (Vector2)target.position - rb.position;

            direction.Normalize();

            float rotateAmount = Vector3.Cross(direction, transform.right).z;


            if (rightToLeft)
            {
                rb.angularVelocity = -rotateAmount * rotateSpeed;
                rb.velocity = transform.right * speed;
            }
            else
            {
                rb.angularVelocity = -rotateAmount * rotateSpeed;
                rb.velocity = transform.right * speed;
            }
        }
        else
        {
            Destroy(gameObject);
        }
        }

}
