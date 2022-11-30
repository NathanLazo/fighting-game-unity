using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinematic : MonoBehaviour
{
    public GameObject GameTitle;

    public GameObject CinematicObject;

    public GameObject MainCharacter;
    public GameObject MainCanvas;

    public GameObject FadeToBlack;

    public void ShowTitle()
    {
        GameTitle.SetActive(true);
        StartCoroutine(WaitForSongEnding());
    }

    public void ShowOtherCamera()
    {
        MainCharacter.SetActive(true);
        MainCanvas.SetActive(true);
        CinematicObject.SetActive(false);
    }


    IEnumerator WaitForSongEnding()
    {
        yield return new WaitForSeconds(17f);
        FadeToBlack.SetActive(true);
    }
}
