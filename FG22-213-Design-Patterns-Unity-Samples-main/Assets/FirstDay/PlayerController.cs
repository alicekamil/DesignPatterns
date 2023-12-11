using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // health
    public int health;

    // Update is called once per frame
    void Update()
    {
        // player input
        if (Input.GetKeyDown(KeyCode.W))
        {
            // player movement
            GetComponent<Rigidbody>().AddForce(Vector3.up * 100);
        }
    }

    public void Heal()
    {
        health += 3;
    }

    private void OnCollisionEnter(Collision other)
    {
        // damage
        health--;
    }
}
