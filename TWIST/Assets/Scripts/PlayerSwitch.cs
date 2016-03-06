using UnityEngine;
using System.Collections;

public class PlayerSwitch : MonoBehaviour {

    private GameObject ManagerGO;
    private GameManager GameManagerScript;
    private GameObject playerTop;
    private GameObject playerSide;

	void Start () {
        ManagerGO = GameObject.Find("GameManager");
        GameManagerScript = ManagerGO.GetComponent<GameManager>();
        playerTop = transform.FindChild("PlayerContainer").gameObject;
        playerSide = transform.FindChild("Drill").gameObject;
  //      playerSide.transform.localScale = new Vector3(0,0,0);
	}
	
	void Update () {
	    
        if(GameManagerScript.DimNum == 1) {
            playerTop.transform.localScale = new Vector3(20, 20, 20);
     //       playerSide.transform.localScale = new Vector3(0,0,0);
        }

        if(GameManagerScript.DimNum == 2) {
      //      playerTop.transform.localScale = new Vector3(0, 0, 0);
       //     playerSide.transform.localScale = new Vector3(46, 46, 46);
        }

    }
}
