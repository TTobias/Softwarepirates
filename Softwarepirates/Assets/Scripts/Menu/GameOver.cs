using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject loseScreen;
    public GameObject musicPlayer;
    public float startTime;
    public void Execute()
    {
        StartCoroutine(ShowKillScreen());
    }

    public IEnumerator ShowKillScreen()
    {
        musicPlayer.SetActive(false);
        GetComponent<AudioSource>().time = startTime;
        GetComponent<AudioSource>().Play();
        //Camera.main.transform.GetComponent<AudioListener>().enabled = false;
        loseScreen.GetComponent<Image>().enabled = true;
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);
    }
}
