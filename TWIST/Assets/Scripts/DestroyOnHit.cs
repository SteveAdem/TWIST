using UnityEngine;
using System.Collections;

public class DestroyOnHit : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}