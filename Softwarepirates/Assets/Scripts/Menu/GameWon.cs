using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameWon : MonoBehaviour
{
    public GameObject winScreen;
    public void Execute()
    {
        StartCoroutine(ShowWinScreen());
    }

    public IEnumerator ShowWinScreen()
    {
        winScreen.GetComponent<AudioSource>().Play();
        winScreen.GetComponent<Image>().enabled = true;
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);
    }
}
