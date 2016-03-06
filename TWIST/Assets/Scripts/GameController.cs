using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public float startWait;

	[SerializeField]
	Text playerSpeech;

    void Start()
    {
		StartCoroutine (StartLevel());
        StartCoroutine(StartSpeech());
    }



    IEnumerator StartLevel() {
        yield return new WaitForSeconds(startWait);
        GameObject player = GameObject.Find("PlayerContainer");
        PlayerScore ps = player.GetComponent<PlayerScore>();
        PlayerHealth ph = player.GetComponent<PlayerHealth>();
        ps.isScoring = true;
        ph.isDepleting = true;
    }        

    IEnumerator StartSpeech() { 
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