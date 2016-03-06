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
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            GetComponent<Rigidbody>().velocity = movement * speed;

            GetComponent<Rigidbody>().position = new Vector3
            (
                Mathf.Clamp(GetComponent<Rigidbody>().position.x, -7, 7),
                2f,
                4f
            );

            float x = 0;
            float y = 0;
            float z = GetComponent<Rigidbody>().velocity.x * -tilt;
            GetComponent<Rigidbody>().rotation = Quaternion.Euler(x, y, z);
        } else

        if(GameManagerScript.DimNum == 2) {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            GetComponent<Rigidbody>().velocity = movement * speed;

            GetComponent<Rigidbody>().position = new Vector3
            (
                Mathf.Clamp(GetComponent<Rigidbody>().position.x, -10, 10),
                2f,
                4f
            );

            float x = 0;
            float y = 0;
            float z = GetComponent<Rigidbody>().velocity.x * -tilt;
            GetComponent<Rigidbody>().rotation = Quaternion.Euler(x, y, z);
        }
    }
}