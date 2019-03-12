﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissileScript : MonoBehaviour
{
    GameObject target;
    public GameObject explosion;
    public float rotationSpeed = 1f;

    Quaternion rotateToTarget;
    Vector3 dir;

    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("targetWood");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update method");

        dir = (target.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        rotateToTarget = Quaternion.Slerp(transform.rotation, rotateToTarget,
            Time.deltaTime * rotationSpeed);
        rb.velocity = new Vector2(dir.x*2, dir.y*2);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("OnTriggerEnter2D method");

        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        Destroy(target);
    }
}