﻿using UnityEngine;
using System.Collections;

public class SpawnObjects : MonoBehaviour
{


    float startWait;
	public bool spawningHalted = true;

    bool isSpawning = false;
    public float minTime = 1.0f;
    public float maxTime = 2.0f;
    public GameObject[] SideObjs;
    public GameObject[] TopObjs;
    private GameObject GameManagerGO;
    private GameManager GameManagerScript;
    private PlayerScore ps;
    private PlayerHealth pd;
    private GameObject player;

    void Start()
    {
        GameManagerGO = GameObject.Find("GameManager");
		startWait = GameManagerGO.GetComponent<GameController> ().startWait;
        GameManagerScript = GameManagerGO.GetComponent<GameManager>();
        player = GameObject.Find("PlayerContainer").gameObject;
        ps = player.GetComponent<PlayerScore>();
        pd = player.GetComponent<PlayerHealth>();

        StartCoroutine(WaveTiming());
    }

    IEnumerator WaveTiming()
    {
        yield return new WaitForSeconds(startWait);
		spawningHalted = false;

    }

    IEnumerator SpawnObject(int index, float seconds, int Dimension)
    {

        Vector3 spawnPosition = new Vector3(Random.Range(-10, 10), transform.position.y, transform.position.z);

        yield return new WaitForSeconds(seconds);

        if (Dimension == 1)
        {
            Instantiate(TopObjs[index], spawnPosition, transform.rotation);
        }
        else
        if (Dimension == 2)
        {
            Instantiate(SideObjs[index], spawnPosition, transform.rotation);
        }

        isSpawning = false;
    }

    void Update()
    {
		if (spawningHalted)
			return;
        if (GameManagerScript.DimNum == 2)
        {

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
        }
    }
}
