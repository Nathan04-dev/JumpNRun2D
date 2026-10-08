using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;

public class HSSteuerung : MonoBehaviour
{

    private Rigidbody2D rb;
 
    [SerializeField] private float minSpeed = 2f;
    [SerializeField] private float maxSpeed = 10f;
    private float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = Random.Range(minSpeed, maxSpeed);




    }
    void FixedUpdate()
    {
        rb.linearVelocity = Vector2.left * speed;
    }

    void Update()
    {

        if (transform.position.y < -6f)
        {
        
            HSSpawner spawner = Object.FindAnyObjectByType<HSSpawner>();

            if (spawner != null)
            {
                spawner.SpawnNext();
            }

            Destroy(gameObject);
        }

  
    }







}
