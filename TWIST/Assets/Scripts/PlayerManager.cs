using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour
{
    public float speed;

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        GetComponent<Rigidbody>().velocity = movement * speed;

        GetComponent<Rigidbody>().position = new Vector3
        (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, -2, 2),
            2f,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, -4, 4)
        );
    }
}