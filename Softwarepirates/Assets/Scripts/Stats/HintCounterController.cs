using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HintCounterController : MonoBehaviour
{
    public int neededHints;
    private int hints = 0;
    private TextMeshProUGUI tmp;
    private GameWon gameWon;
    public GameObject wormSpawner;
    public float adjustWaitTimeBy;

    void Start()
    {
        gameWon = FindObjectOfType<GameWon>();
        tmp = GetComponent<TextMeshProUGUI>();
        UpdateBar();
    }

    public void AddHint()
    {
        if(hints < neededHints)
        {
            hints++;
            wormSpawner.GetComponent<ItemSpawner>().maxWaitTime -= adjustWaitTimeBy;
            UpdateBar();
        }
        if (hints == neededHints)
            gameWon.Execute();
    }

    public void RemoveHint()
    {
        if(hints > 0)
        {
            hints--;
            UpdateBar();
        }
    }

    private void UpdateBar()
    {
        //tmp.text = "Hints: " + hints + "/" + neededHints;
        GetComponent<Image>().fillAmount = (float)hints / (float)neededHints;
    }
}
