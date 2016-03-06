using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    Text playerSpeech;


	[SerializeField]
	Text playerSpeech;

    void Start()
    {
<<<<<<< HEAD
        StartCoroutine(StartSpeech());
=======
        StartCoroutine(SpawnWaves());
		StartCoroutine (StartSpeech());
>>>>>>> 17f18120a4b4a03d11a72a740a69c741240b1b06
    }

    IEnumerator StartSpeech()
    {
<<<<<<< HEAD
        yield return new WaitForSeconds(2);
        FadingText fd = playerSpeech.GetComponent<FadingText>();
        fd.fade("I sense something...");
        yield return new WaitForSeconds(fd.fadeTime + 2);
        fd.fade("I sense the world is not right...");
        yield return new WaitForSeconds(fd.fadeTime + 2);
        fd.fade("I sense a connection...");
        yield return new WaitForSeconds(fd.fadeTime + 2);
        fd.fade("I must keep flying...");
=======
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
>>>>>>> 17f18120a4b4a03d11a72a740a69c741240b1b06
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