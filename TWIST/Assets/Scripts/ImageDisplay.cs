using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ImageDisplay : MonoBehaviour {

		public Texture imageToDisplay;
		public float timeToDisplayImage;
		public int nextLevelToLoad;

		private float timeForNextLevel;
	public AudioSource music;

		public void Start() {
			timeForNextLevel = Time.time + timeToDisplayImage;
		music.Play ();
		}

		public void OnGUI() {
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), imageToDisplay);
			if (Time.time >= timeForNextLevel) {
			music.Stop ();
			SceneManager.LoadScene(nextLevelToLoad);
			}
		}
	}
