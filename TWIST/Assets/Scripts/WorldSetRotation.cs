using UnityEngine;
using System.Collections;

public class WorldSetRotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.L)) {

           transform.Rotate(0, 0, 90);
          //  transform.eulerAngles = new Vector3(0, 0, 90);
            Debug.Log("CARREGOU L");
        }
	}

    public void SetWorldSide()
    {
        transform.Rotate(0, 0, 90);
        Debug.Log("TESTE SIDE");
    }

    public void SetWorldTop()
    {
        transform.Rotate(0, 0, -90);
        Debug.Log("TESTE TOP");
    }

}
