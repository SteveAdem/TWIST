using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    Text playerSpeech;


    void Start()
    {
        StartCoroutine(StartSpeech());
    }

    IEnumerator StartSpeech()
    {
        yield return new WaitForSeconds(2);
        FadingText fd = playerSpeech.GetComponent<FadingText>();
        fd.fade("I sense something...");
        yield return new WaitForSeconds(fd.fadeTime + 2);
        fd.fade("I sense the world is not right...");
        yield return new WaitForSeconds(fd.fadeTime + 2);
        fd.fade("I sense a connection...");
        yield return new WaitForSeconds(fd.fadeTime + 2);
        fd.fade("I must keep flying...");
    }
}