using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsMovement : MonoBehaviour
{
    public GameObject clone;
    public Rigidbody2D rb;
    void Start()
    {
        Movement();
    }
    void Update()
    {
        if (rb.transform.position.x > 10 || rb.transform.position.x < -10
            || rb.transform.position.y > 5 || rb.transform.position.y < -5)
        {
            Destroy(clone);
        }
    }
    void OnCollisionEnter2D()
    {
        Destroy(clone.gameObject);
    }
    void Movement()
    {
        rb.velocity =  Quaternion.Euler(PlayerController.angles) * Vector3.left * -15f;
    }
}
