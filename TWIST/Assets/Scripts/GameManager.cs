using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private GameManager GameManagerScript;
    public int DimNum; // 1 -> top   2 -> side
    public GameObject FloorConteiner;
    private bool ChangeToSide;
    private bool ChangeToTop;
    public float FloorRotationSpeed;
    private Animator FloorAnimController;

    void Start()
    {
        GameManagerScript = gameObject.GetComponent<GameManager>();
        DimNum = 1;
        FloorRotationSpeed = 10f;
        FloorAnimController = gameObject.GetComponent<Animator>();
    }


    public void ChangeDimension()
    {

        if (GameManagerScript.DimNum == 1)
        {
            // mudar para SIDEVIEW
            GameManagerScript.DimNum = 2;

            //
                        Quaternion initialRotation = new Quaternion(FloorConteiner.transform.localRotation.x, FloorConteiner.transform.localRotation.y, FloorConteiner.transform.localRotation.z, FloorConteiner.transform.localRotation.w);
            Quaternion finalRotation = Quaternion.Euler(FloorConteiner.transform.localRotation.x, FloorConteiner.transform.localRotation.y, 90f);
            FloorConteiner.transform.localRotation = Quaternion.Slerp(initialRotation, finalRotation, Time.deltaTime * FloorRotationSpeed);
            //
            Debug.Log("RODOU para side");
        }

        else if (GameManagerScript.DimNum == 2)
        {
            // mudar para TOPVIEW
            GameManagerScript.DimNum = 1;
            ChangeToSide = true;
            //
            float rotationSpeed = 4f;
            Quaternion initialRotation = new Quaternion(FloorConteiner.transform.localRotation.x, FloorConteiner.transform.localRotation.y, FloorConteiner.transform.localRotation.z, FloorConteiner.transform.localRotation.w);
            Quaternion finalRotation = Quaternion.Euler(FloorConteiner.transform.localRotation.x, FloorConteiner.transform.localRotation.y, 0f);
            FloorConteiner.transform.localRotation = Quaternion.Slerp(initialRotation, finalRotation, Time.deltaTime * FloorRotationSpeed);
            //
            Debug.Log("PARA TOP");
        }

    }


    void Update()
    {

        if (ChangeToSide == true)
        {
            
            ChangeToSide = false;
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            ChangeDimension();
        }

        

        if (ChangeToTop == true)
        {

            ChangeToTop = false;
        }

    }


}
