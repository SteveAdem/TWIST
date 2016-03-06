using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TwistBang : MonoBehaviour {

	[SerializeField]
	public float fadeTime = 1.0f;

	[SerializeField]
	float finalAlpha = 1.0f;

	Text text;

	Vector3 initialPosition, finalPosition;

	bool fadingIn = false;
	bool fadingOut = false;
	float elapsedTime = 0.0f;

	float translateSpeed = 5.0f;
	Quaternion initialRotation;
	Quaternion frontRotation;
	Quaternion backRotation;
	Quaternion currentRotation;
	bool front = true;

	// Use this for initialization
	void Start () {
		text = gameObject.GetComponent<Text> ();
		text.canvasRenderer.SetAlpha (0.0f);
		initialRotation = new Quaternion (text.transform.rotation.x, text.transform.rotation.y, text.transform.rotation.z, text.transform.rotation.w);
		frontRotation = Quaternion.Euler (180.0f, 90.0f, 90.0f);
		backRotation = Quaternion.Euler (0.0f, 0.0f, 0.0f);
		//finalRotation = new Quaternion (text.transform.rotation.x, text.transform.rotation.y, text.transform.rotation.z, text.transform.rotation.w);
		//initialPosition = new Vector3 (text.transform.position.x-50, text.transform.position.y, text.transform.position.z);
		//finalPosition = new Vector3 (text.transform.position.x+50, text.transform.position.y, text.transform.position.z); 
	}

	// Update is called once per frame
	void Update () {

		if ((fadingIn) || (fadingOut)) {
			text.transform.rotation = Quaternion.Slerp(text.transform.rotation, 
				currentRotation, Time.deltaTime * translateSpeed);
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
				front = !front;
				//text.transform.rotation = initialRotation;
				elapsedTime = 0.0f;
			}
		}
	}

	public void bang(string msg) {
		// fade in
		Debug.Log("BANG!");
		if ((fadingIn) || (fadingOut)) return;
		text.text = msg;
		text.CrossFadeAlpha (finalAlpha, fadeTime, false);
		if (front) {
			currentRotation = frontRotation;
		} else {
			currentRotation = backRotation;
		}
		fadingIn = true;
	}
}
