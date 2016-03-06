using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    private GameManager GameManagerScript;
    public int DimNum;   // 1 -> top   2 -> side
    private bool ChangeToSide;
    private bool ChangeToTop;
    public float FloorRotationSpeed;
    public GameObject World;
    private Animator WorldAnimController;
    private Animator CameraAnimController;
    private WorldSetRotation WorldSetRotationScript;

	public AudioSource twist;
	public AudioSource music;
	public AudioSource ambience;

	public Text text;

	private float nextTwist;
	private float elapsedTime;

    void Start()
    {
        GameManagerScript = gameObject.GetComponent<GameManager>();
        DimNum = 1;
        FloorRotationSpeed = 10f;
        WorldAnimController = World.GetComponent<Animator>();
        CameraAnimController = Camera.main.GetComponent<Animator>();
        WorldSetRotationScript = World.GetComponent<WorldSetRotation>();
		elapsedTime = 0.0f;
		nextTwist = Random.Range (5.0f, 10.0f);

    }


    public void ChangeDimension()
    {
		twist.PlayOneShot (twist.clip);
		twistBang ();

        if (DimNum == 1)
        {
            // mudar para SIDEVIEW
            DimNum = 2;
			changeMusic (DimNum);
            WorldAnimController.SetTrigger("ToSide");
            CameraAnimController.SetTrigger("CamToSide");
        }

        else if (DimNum == 2)
        {
			// mchangeMusicudar para TOPVIEW
            DimNum = 1;
			changeMusic (DimNum);
            WorldAnimController.SetTrigger("ToTop");
            CameraAnimController.SetTrigger("CamToTop");
        }

    }

    public void SetWorldSide() {
        World.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
    }

    public void SetWorldTop()
    {
        World.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
    }

    public void SetCamTop(){
        Camera.main.transform.rotation = Quaternion.Euler(90.0f, 0.0f, 0.0f);
    }

    public void SetCamSide() {
        Camera.main.transform.rotation = Quaternion.Euler(90.0f, 0.0f, 90.0f);
    }

	private void changeMusic(int dim) {
		if (music.isPlaying)
			music.Pause ();
		if (ambience.isPlaying) 
			ambience.Pause ();
		if (dim == 1) { // space
            music = GameObject.Find("SpaceMusic").GetComponent<AudioSource>();
			ambience = GameObject.Find("SpaceAmbience").GetComponent<AudioSource>();
		}
		if (dim == 2) { // underground
			music = GameObject.Find("ChickenMusic").GetComponent<AudioSource>();
			ambience = GameObject.Find("UndergroundAmbience").GetComponent<AudioSource>();
		}
		music.UnPause ();
		ambience.UnPause ();

	}

	private void twistBang() {
		text.GetComponent<TwistBang> ().bang ("TWIST");
	}

	void startMusic() {
		if (!music.isPlaying) 
			music.Play ();

		if (!ambience.isPlaying) 
			ambience.Play ();
	}

    void Update()
    {
		startMusic ();

        //introText();

		elapsedTime += Time.deltaTime;
		if (elapsedTime > nextTwist) {
			ChangeDimension();
			elapsedTime = 0.0f;
			nextTwist = Random.Range (5.0f, 10.0f);
		}
		/*
        if (Input.GetKeyDown(KeyCode.H))
        {
            ChangeDimension();
        }
*/
        Debug.Log("DIMENSAO: " + DimNum);
    }


}
