using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject loseScreen;
    public void Execute()
    {
        StartCoroutine(ShowKillScreen());
    }

    public IEnumerator ShowKillScreen()
    {
        Camera.main.transform.GetComponent<AudioListener>().enabled = false;
        loseScreen.GetComponent<Image>().enabled = true;
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);
    }
}
