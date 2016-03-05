using UnityEngine;
using System.Collections;

public class MovingScript : MonoBehaviour
{
    public float speed;

    void Start()
    {
        GetComponent<Rigidbody>().rotation = new Quaternion(0.0f, 0.0f, 0.0f, 1.0f);
        GetComponent<Rigidbody>().velocity = -transform.forward * speed;
    }
}
