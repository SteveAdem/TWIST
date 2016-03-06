using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

	[SerializeField]
	Text playerSpeech;

    void Start()
    {
        StartCoroutine(SpawnWaves());
		StartCoroutine (StartSpeech());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		PlayerScore ps = player.GetComponent<PlayerScore> ();
		ps.isScoring = true;
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

	IEnumerator StartSpeech() {
		yield return new WaitForSeconds(2);
		FadingText fd = playerSpeech.GetComponent<FadingText> ();
		fd.fade("I sense something...");
		yield return new WaitForSeconds(fd.fadeTime+2);
		fd.fade("I sense the world is not right...");
		yield return new WaitForSeconds(fd.fadeTime+2);
		fd.fade("I sense a connection...");
		yield return new WaitForSeconds(fd.fadeTime+2);
		fd.fade("I must keep flying...");
	}
}