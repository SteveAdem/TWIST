﻿using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour
{
    public float speed;
    public float tilt;

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        GetComponent<Rigidbody>().velocity = movement * speed;

        GetComponent<Rigidbody>().position = new Vector3
        (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, -10, 10),
            2f,
            4f
        );

        float x = 90;
        float y = GetComponent<Rigidbody>().velocity.x * -tilt;
        float z = 0;
        GetComponent<Rigidbody>().rotation = Quaternion.Euler(x,y,z);

    }
}