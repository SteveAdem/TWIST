using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
	public int startingHealth = 100;
	public int currentHealth;
	public Slider healthSlider;
	public Image damageImage;
	// public AudioClip deathClip;
	public float flashSpeed = 5f;
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    public bool isDepleting = false;

	[SerializeField]
	private float fuelDepletionSpeed = 0.1f;

	//Animator anim;
	//AudioSource playerAudio;
	bool isDead;
	bool damaged;

	float timer;

	void Awake()
	{
		//anim = GetComponent<Animator>();
		//playerAudio = GetComponent<AudioSource>();
		currentHealth = startingHealth;
		timer = 0.0f;
        isDepleting = false;

    }


	void Update()
	{
		damaged = false;
		timer += Time.deltaTime;
		if (timer >= fuelDepletionSpeed && isDepleting) {
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
		//anim.SetTrigger("Die");

		//playerAudio.clip = deathClip;
		//playerAudio.Play();

	}
}