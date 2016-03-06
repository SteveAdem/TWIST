using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour
{
    public float speed;
    public float tilt;
    private GameObject ManagerGO;
    private GameManager GameManagerScript;

    void Start()
    {
        ManagerGO = GameObject.Find("GameManager");
        GameManagerScript = ManagerGO.GetComponent<GameManager>();
    }

    void FixedUpdate()
    {
        if (GameManagerScript.DimNum == 1)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
     //       float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
            GetComponent<Rigidbody>().velocity = movement * speed;

            GetComponent<Rigidbody>().position = new Vector3
            (
                Mathf.Clamp(GetComponent<Rigidbody>().position.x, -7, 7), GetComponent<Rigidbody>().position.y, GetComponent<Rigidbody>().position.z );

            float x = 0;
            float y = 0;
            float z = GetComponent<Rigidbody>().velocity.x * -tilt;
            GetComponent<Rigidbody>().rotation = Quaternion.Euler(x, y, z);
        } else

        if(GameManagerScript.DimNum == 2) {
            float moveHorizontal = Input.GetAxis("Horizontal");
            //       float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
            GetComponent<Rigidbody>().velocity = movement * speed;

            GetComponent<Rigidbody>().position = new Vector3
            (
                Mathf.Clamp(GetComponent<Rigidbody>().position.x, -4.0f, 4.5f), GetComponent<Rigidbody>().position.y, -5.0f);

            float x = 0;
            float y = 0;
            float z = GetComponent<Rigidbody>().velocity.x * -tilt;
            GetComponent<Rigidbody>().rotation = Quaternion.Euler(x, y, z);
        }
    }
}