using UnityEngine;
using System.Collections;

public class PlayerSwitch : MonoBehaviour {

    private GameObject ManagerGO;
    private GameManager GameManagerScript;
    public GameObject playerTop;
    public GameObject playerSide;

	void Start () {
        ManagerGO = GameObject.Find("GameManager");
        GameManagerScript = ManagerGO.GetComponent<GameManager>();
        playerSide.SetActive(false);
	}
	
	void Update () {
	    
        if(GameManagerScript.DimNum == 1) {
            playerTop.SetActive(true);
            playerSide.SetActive(false);
        }

        if(GameManagerScript.DimNum == 2) {
            playerSide.SetActive(true);
            playerTop.SetActive(false);
        }

    }
}
