using UnityEngine;
using System.Collections;

public class SpawnObjects : MonoBehaviour {

    bool isSpawning = false;
    public float minTime = 1.0f;
    public float maxTime = 2.0f;
    public GameObject[] SideObjs;
    public GameObject[] TopObjs;
    private GameObject GameManagerGO;
    private GameManager GameManagerScript;

    void Start()
    {
        GameManagerGO = GameObject.Find("GameManager");
        GameManagerScript = GameManagerGO.GetComponent<GameManager>();
    }

    IEnumerator SpawnObject(int index, float seconds, int Dimension)
    {

        Vector3 spawnPosition = new Vector3(Random.Range(-10, 10), transform.position.y, transform.position.z);

        yield return new WaitForSeconds(seconds);

        if (Dimension == 1) {
            Instantiate(TopObjs[index], spawnPosition, transform.rotation);
        } else
        if(Dimension == 2) {
            Instantiate(SideObjs[index], spawnPosition, transform.rotation);
        }

        isSpawning = false;
    }

    void Update()
    {
        if (GameManagerScript.DimNum == 2) {

            if (!isSpawning)
            {
                isSpawning = true;
                int SideObjsIndex = Random.Range(0, SideObjs.Length);
                StartCoroutine(SpawnObject(SideObjsIndex, Random.Range(minTime, maxTime), 2));
            }

        }

        if (GameManagerScript.DimNum == 1)
        {

            if (!isSpawning)
            {
                isSpawning = true;
                int TopObjsIndex = Random.Range(0, TopObjs.Length);
                StartCoroutine(SpawnObject(TopObjsIndex, Random.Range(minTime, maxTime), 1));
            }
            Debug.Log("SPAWN DIM 1");
        }
    }
}
