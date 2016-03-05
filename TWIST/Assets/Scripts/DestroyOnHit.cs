using UnityEngine;
using System.Collections;

public class DestroyOnHit : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
		Debug.Log ("DestroyOnHit:"+other);
		Destroy(gameObject);
    }
}