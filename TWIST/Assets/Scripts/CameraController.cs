using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    private GameManager GameManagerScript;

	void Start () {
        GameManagerScript = Camera.main.GetComponent<GameManager>();


    }

    public void ChangeDimension() {

        if (GameManagerScript.DimNum == 1) {
            // mudar para SIDEVIEW
            GameManagerScript.DimNum = 2;
            
        }

        if (GameManagerScript.DimNum == 2) {
            // mudar para TOPVIEW
            GameManagerScript.DimNum = 1;
        }

    }


    void Update () {
	
        if(Input.GetKeyDown(KeyCode.H)) {
            ChangeDimension();
        }

	}


}
