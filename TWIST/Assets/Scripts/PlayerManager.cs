using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour
{
    public float speed;
    public float tilt;
    private GameObject ManagerGO;
    private GameManager GameManagerScript;
    public GameObject TopContainer;
    public GameObject SideContainer;
    private BGScrollerTop BGScrollerTopScript;
    private BGScrollerSide BGScrollerSideScript;
    private bool SlowPlayer;
    private bool isSlowing;
    public GameObject TerraEscavada;
    private bool InstantiateDirty;

    [SerializeField]
    AudioClip cloudHit;
    [SerializeField]
    AudioClip birdHit;
    [SerializeField]
    AudioClip crystalHit;
    [SerializeField]
    AudioClip oilDropHit;

    void Start()
    {
        ManagerGO = GameObject.Find("GameManager");
        GameManagerScript = ManagerGO.GetComponent<GameManager>();
        BGScrollerTopScript = TopContainer.GetComponent<BGScrollerTop>();
        BGScrollerSideScript = SideContainer.GetComponent<BGScrollerSide>();
    }

    IEnumerator SlowPlayerCloud() {
        SlowPlayer = true;
        yield return new WaitForSeconds(3f);
        SlowPlayer = false;
    }

    IEnumerator abanarSidePlayer() {
        
        for(int i = 1; i < 8; i++) {
            transform.localPosition = new Vector3(transform.localPosition.x + 0.25f, transform.localPosition.y, transform.localPosition.z);
            yield return new WaitForSeconds(0.05f);
            transform.localPosition = new Vector3(transform.localPosition.x - 0.25f, transform.localPosition.y, transform.localPosition.z);
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator MakeDirty()
    {
       if(GameManagerScript.DimNum == 2) {
            InstantiateDirty = false;
            Vector3 posTerra = new Vector3(transform.position.x, transform.position.y - 1.3f, transform.position.z);
            GameObject Terra = Instantiate(TerraEscavada, posTerra, Quaternion.FromToRotation(new Vector3(0, 0, 0), new Vector3(0, 0, 0))) as GameObject;
            Terra.transform.parent = SideContainer.transform;
            yield return new WaitForSeconds(1f);
            InstantiateDirty = true;
        }
    }


    public void OnTriggerEnter(Collider col) {

        if(col.tag == "Cloud") {
            GameObject.Find("PlayerContainer").GetComponent<PlayerHealth>().currentHealth -= 10;
            GetComponent<AudioSource>().PlayOneShot(cloudHit);
            StartCoroutine(SlowPlayerCloud());
            // som a puxar pelo motor
        } else
        if(col.tag == "Bird") {
            GameObject.Find("PlayerContainer").GetComponent<PlayerHealth>().currentHealth -= 10;
            GetComponent<AudioSource>().PlayOneShot(birdHit);
            SpecialEffectScript.Instance.PassarosEffect(col.transform.position);
            Destroy(col.gameObject);
        } else
        if(col.tag == "Crystal") {
            GameObject.Find("PlayerContainer").GetComponent<PlayerHealth>().currentHealth -= 10;
            GetComponent<AudioSource>().PlayOneShot(crystalHit);
            SpecialEffectScript.Instance.CrystalEffect(col.transform.position);
            Destroy(col.gameObject);
            StartCoroutine(abanarSidePlayer());
        } else
        if (col.tag == "FuelDrop") {
            GameObject.Find("PlayerContainer").GetComponent<PlayerHealth>().currentHealth = 100;
            GetComponent<AudioSource>().PlayOneShot(oilDropHit);
            Destroy(col.gameObject);
        }

    }

    void FixedUpdate()
    {

        if(SlowPlayer) {
            BGScrollerTopScript.scrollSpeed = Mathf.Lerp(-4, -1f, 2 * Time.time);
            isSlowing = true;
        } else if (SlowPlayer == false && isSlowing == true) {
            BGScrollerTopScript.scrollSpeed = Mathf.Lerp(-1f, -4, 2 * Time.time);
            isSlowing = false;
        }


        if (GameManagerScript.DimNum == 1)
        {

            // MOVE 

            float moveHorizontal = Input.GetAxis("Horizontal");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
            GetComponent<Rigidbody>().velocity = movement * speed;

            GetComponent<Rigidbody>().position = new Vector3
            (
                Mathf.Clamp(GetComponent<Rigidbody>().position.x, -7, 7), GetComponent<Rigidbody>().position.y, GetComponent<Rigidbody>().position.z );

            float x = 0;
            float y = 0;
            float z = GetComponent<Rigidbody>().velocity.x * -tilt;
            GetComponent<Rigidbody>().rotation = Quaternion.Euler(x, y, z);


        } else

        if(GameManagerScript.DimNum == 2) {
            InstantiateDirty = true;
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3((moveVertical - 2 * moveVertical), 0.0f, 0.0f);
            GetComponent<Rigidbody>().velocity = movement * speed;

            GetComponent<Rigidbody>().position = new Vector3
            (
                Mathf.Clamp(GetComponent<Rigidbody>().position.x, -4.0f, 4.5f), GetComponent<Rigidbody>().position.y, -5.0f);

            float x = 0;
            float y = GetComponent<Rigidbody>().velocity.x * tilt;
            float z = 0;
            GetComponent<Rigidbody>().rotation = Quaternion.Euler(x, y, 90 * Time.time);

            if(InstantiateDirty == true) {
                StartCoroutine(MakeDirty());
            }
        }
    }

        
            

    


}