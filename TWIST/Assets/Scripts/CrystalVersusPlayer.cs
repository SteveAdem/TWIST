using UnityEngine;
using System.Collections;

public class CrystalVersusPlayer : MonoBehaviour {

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col) {

        if(col.tag == "Player") {
            transform.position = new Vector3(col.transform.position.x, col.transform.position.y, col.transform.position.z + 1);
            Debug.Log("CRYSTAL TO PLAYER TRANSFORM");
            Debug.Log("PLAYER POS " + col.transform.localPosition);
            Debug.Log("CRYSTAL POS " + transform.localPosition);
            Debug.Log("NOME DO OBJ " + col.name);
        }

    }
}
