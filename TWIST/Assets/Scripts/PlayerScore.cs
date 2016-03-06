using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScore : MonoBehaviour
{
    public static int score;        // The player's score.

	[SerializeField]
	private float scoringSpeed = 0.2f;
	[SerializeField]
	private int scoringIncrement = 10;
    
	[SerializeField]
	Text text; // Reference to the Text component.
	float timer;
	public bool isScoring = false;

    void Awake()
    {
        // Set up the reference.
        //text = GetComponent<Text>();

        // Reset the score.
        score = 0;
    }

    void Update()
    {
		if (!isScoring)
			return;
		timer += Time.deltaTime;
		if (timer >= scoringSpeed) {
			score += scoringIncrement;
			text.text = ""+score.ToString("000000");
			timer = 0f;
		}
    }
}