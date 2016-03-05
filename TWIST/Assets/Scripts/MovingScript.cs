using UnityEngine;
using System.Collections;

public class MovingScript : MonoBehaviour
{
    public float speed;

    void Start()
    {

        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }
}
