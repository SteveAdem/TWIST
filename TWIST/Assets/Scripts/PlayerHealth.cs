﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth;
	public int currentHealth;
	public Slider healthSlider;
	public Image damageImage;
	// public AudioClip deathClip;
	public float flashSpeed = 5f;
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
	public bool isDepleting = false;

    [SerializeField]
    private GameObject newsImage;

    [SerializeField]
	private float fuelDepletionSpeed = 0.1f;

	//Animator anim;
	//AudioSource playerAudio;
	public bool isDead;
	bool damaged;

	float timer;

	void Awake()
	{
		//anim = GetComponent<Animator>();
		//playerAudio = GetComponent<AudioSource>();
		currentHealth = startingHealth;
		timer = 0.0f;
	}


	void Update()
	{
		if (!isDepleting)
			return;
		damaged = false;
		timer += Time.deltaTime;
		if (timer >= fuelDepletionSpeed) {
			TakeDamage (1);
			timer = 0.0f;
		}
	}

	public void TakeDamage(int amount)
	{
		damaged = true;
		currentHealth -= amount;
		healthSlider.value = currentHealth;

		Debug.Log ("health:" + currentHealth);

		//playerAudio.Play();

		if (currentHealth <= 0 && !isDead)
		{
			Death();
		}
	}


	void Death()
	{
		isDead = true;

		Debug.Log ("DEAD!!!");
        newsImage.SetActive(true);

        GameObject ScoreTextGO = GameObject.Find("FinalScoreText").gameObject;
        Text scoreText = ScoreTextGO.GetComponent<Text>();
        GameObject playerContainerGO = GameObject.Find("PlayerContainer").gameObject;
        int finalScore = playerContainerGO.GetComponent<PlayerScore>().score;
        scoreText.text = ""+finalScore;


        GameObject.Find("PlayerContainer").SetActive(false);
        GameObject.Find("World").SetActive(false);


        //playerAudio.clip = deathClip;
        //playerAudio.Play();

    }
}