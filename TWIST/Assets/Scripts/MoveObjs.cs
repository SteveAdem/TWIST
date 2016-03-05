using UnityEngine;
using System.Collections;

public class MoveObjs : MonoBehaviour {

    // Velocidade da nave
    public Vector3 speed = new Vector3(3, 3, 3);

    // Guarda o movimento da nave
    private Vector3 movement;

    public Vector3 direction = new Vector3(0, 0,-1);

    // Update is called once per frame
    void Update()
    {

        //Faz a movimentaçao pela direcao
        movement = new Vector3(
            direction.x * speed.x,
            direction.y * speed.y,
            direction.z * speed.z
            );

    }

    // Movimento do objeto 
    void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = movement;
    }
}
