using UnityEngine;
using System.Collections;

public class FadingText : MonoBehaviour {

	[SerializeField]
	float fadeTime = 1.0f;

	[SerializeField]
	float finalAlpha = 1.0f;

	UnityEngine.UI.Text text;

	Vector3 initialPosition, finalPosition;

	bool fadingIn = false;
	bool fadingOut = false;
	float elapsedTime = 0.0f;

	float translateSpeed = 0.5f;

	// Use this for initialization
	void Start () {
		text = gameObject.GetComponent<UnityEngine.UI.Text> ();
		text.canvasRenderer.SetAlpha (0.0f);
		initialPosition = new Vector3 (text.transform.position.x, text.transform.position.y, text.transform.position.z);
		finalPosition = new Vector3 (text.transform.position.x+150, text.transform.position.y, text.transform.position.z); 
	}
	
	// Update is called once per frame
	void Update () {
		if ((fadingIn) || (fadingOut)) {
			text.transform.position = Vector3.Slerp (text.transform.position, finalPosition, Time.deltaTime * translateSpeed);
		}
		if (fadingIn) {
			elapsedTime += Time.deltaTime;
			if (elapsedTime > fadeTime) {
				text.CrossFadeAlpha (0.0f, fadeTime, false);
				elapsedTime = 0.0f;
				fadingIn = false;
				fadingOut = true;
			}
		}
		if (fadingOut) {
			elapsedTime += Time.deltaTime;
			if (elapsedTime > fadeTime) {
				fadingOut = false;
				text.canvasRenderer.SetAlpha (0.0f);
				text.transform.position = initialPosition;
				elapsedTime = 0.0f;
			}
		}
	}
		
	public void fade() {
		// fade in
		if ((fadingIn) || (fadingOut)) return;
		text.CrossFadeAlpha (finalAlpha, fadeTime, false);
		fadingIn = true;
	}

	
}
