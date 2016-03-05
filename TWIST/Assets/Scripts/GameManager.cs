using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private GameManager GameManagerScript;
    public int DimNum; // 1 -> top   2 -> side
    private bool ChangeToSide;
    private bool ChangeToTop;
    public float FloorRotationSpeed;
    public GameObject World;
    private Animator WorldAnimController;
    private Animator CameraAnimController;
    private WorldSetRotation WorldSetRotationScript;

    void Start()
    {
        GameManagerScript = gameObject.GetComponent<GameManager>();
        DimNum = 1;
        FloorRotationSpeed = 10f;
        WorldAnimController = World.GetComponent<Animator>();
        CameraAnimController = Camera.main.GetComponent<Animator>();
        WorldSetRotationScript = World.GetComponent<WorldSetRotation>();
    }


    public void ChangeDimension()
    {

        if (GameManagerScript.DimNum == 1)
        {
            // mudar para SIDEVIEW
            GameManagerScript.DimNum = 2;
            WorldAnimController.SetTrigger("ToSide");
            CameraAnimController.SetTrigger("CamToSide");
    //        WorldSetRotationScript.SetWorldSide();
            Debug.Log("teste");
        }

        else if (GameManagerScript.DimNum == 2)
        {
            // mudar para TOPVIEW
            GameManagerScript.DimNum = 1;
            WorldAnimController.SetTrigger("ToTop");
            CameraAnimController.SetTrigger("CamToTop");
        //    WorldSetRotationScript.SetWorldTop();
            Debug.Log("testeeeeeeeee");
        }

    }

    public void SetWorldSide() {
        //   World.transform.Rotate(0,0,0);
        /*      Vector3 posInicial = new Vector3(0, 0, 90);
              Vector3 posFinal = new Vector3(0, 0, 90);
              World.transform.rotation = Quaternion.FromToRotation(posInicial, posFinal); */
        World.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
        Debug.Log("TESTE SIDE");
    }

    public void SetWorldTop()
    {
        //   World.transform.Rotate(0, 0, 0);
        /*   Vector3 posInicial = new Vector3(0,0,0);
           Vector3 posFinal = new Vector3(0,0,0);
           World.transform.rotation = Quaternion.FromToRotation(posInicial, posFinal); */
        World.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        Debug.Log("TESTE TOP");
    }

    public void SetCamTop(){
        Camera.main.transform.rotation = Quaternion.Euler(90.0f, 0.0f, 0.0f);
    }

    public void SetCamSide() {
        Camera.main.transform.rotation = Quaternion.Euler(90.0f, 0.0f, 90.0f);
    }

    void Update()
    {


        if (Input.GetKeyDown(KeyCode.H))
        {
            ChangeDimension();
        }



    }


}
