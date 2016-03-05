using UnityEngine;
using System.Collections;

public class DestroyOnHit : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("INIMIGO ATINGIU O PLAYER");
        }
    }
}