using UnityEngine;
using System.Collections;

public class WorldAnimBehaviour : MonoBehaviour {

    private GameObject GameManagerGO;
    private GameManager GameManagerScript;
    private WorldSetRotation WorldSetRotationScript;

    void Start()
    {
        GameManagerGO = GameObject.Find("GameManager");
        GameManagerScript = GameManagerGO.GetComponent<GameManager>();
        WorldSetRotationScript = gameObject.GetComponent<WorldSetRotation>();
    }

    // Update is called once per frame
    void Update () {
	
	}

 

    public void ChangeCompleteToTop()
    {
        // acabou de mudar para top view
        GameManagerScript.SetWorldTop();
       // WorldSetRotationScript.SetWorldTop();
        Debug.Log("LOLOLLOLOLOLOLOLOL");
    }

    public void ChangeCompleteToSide()
    {
        // acabou de mudar para side view
        GameManagerScript.SetWorldSide();
      //  WorldSetRotationScript.SetWorldSide();
        Debug.Log("LOLOL");
    }

}

