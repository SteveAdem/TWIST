using UnityEngine;
using System.Collections;

public class CameraAnimEvents : MonoBehaviour {

    private GameObject GameManagerGO;
    private GameManager GameManagerScript;
    private WorldSetRotation WorldSetRotationScript;

    void Start()
    {
        GameManagerGO = GameObject.Find("GameManager");
        GameManagerScript = GameManagerGO.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }



    public void ChangeCompleteToTop()
    {
        // acabou de mudar para top view
        GameManagerScript.SetCamTop();
    }

    public void ChangeCompleteToSide()
    {
        // acabou de mudar para side view
        GameManagerScript.SetCamSide();
    }

}