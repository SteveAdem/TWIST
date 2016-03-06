using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public float startWait;

	[SerializeField]
	Text playerSpeech;

	PlayerScore ps;
	PlayerHealth ph;

    void Start()
    {
		GameObject player = GameObject.Find("PlayerContainer");
		ps = player.GetComponent<PlayerScore>();
		ph = player.GetComponent<PlayerHealth>();
		StartCoroutine (StartLevel());
        StartCoroutine(StartFirstNarrative());
    }

    IEnumerator StartLevel() {
        yield return new WaitForSeconds(startWait);
        ps.isScoring = true;
        ph.isDepleting = true;
    }        

    IEnumerator StartFirstNarrative() { 
		FadingText fd = playerSpeech.GetComponent<FadingText> ();
		fd.fade("I sense something...");
		yield return new WaitForSeconds(fd.fadeTime+2);
		fd.fade("I sense the world is not right...");
		yield return new WaitForSeconds(fd.fadeTime+2);
		fd.fade("I sense a connection...");
		yield return new WaitForSeconds(fd.fadeTime+2);
		fd.fade("I must keep flying...");
	}

	public IEnumerator StartSecondNarrative() {
		Debug.Log ("starting second narrative");
		ps.isScoring = false;
		ph.isDepleting = false;
		GameObject.Find ("SpawnObj").GetComponent<SpawnObjects> ().spawningHalted = true;
		FadingText fd = playerSpeech.GetComponent<FadingText> ();
		fd.fade("I can't explain...");
		yield return new WaitForSeconds(fd.fadeTime+2);
		fd.fade("I feel strange...");
		yield return new WaitForSeconds(fd.fadeTime+2);
		fd.fade("I feel compelled to dig...");
		yield return new WaitForSeconds(fd.fadeTime+2);
		fd.fade("I must find those goblets...");
		yield return new WaitForSeconds(fd.fadeTime+2);
		ps.isScoring = true;
		ph.isDepleting = true;
		GameObject.Find ("SpawnObj").GetComponent<SpawnObjects> ().spawningHalted = false;
	}
}