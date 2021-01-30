using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PirateCounterController : MonoBehaviour
{
    public int initPirates;
    private int pirates;
    private TextMeshProUGUI tmp;

    void Start()
    {
        pirates = initPirates;
        tmp = GetComponent<TextMeshProUGUI>();
        UpdateText();
    }

    public void AddPirate()
    {
        if (pirates < initPirates)
            pirates++;
        else
            Debug.LogWarning("Added pirate, but was already at max.");

        UpdateText();
    }

    public void RemovePirate()
    {
        pirates--;
        UpdateText();
        if(pirates <= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void UpdateText()
    {
        tmp.text = "Pirates: " + pirates + "/" + initPirates;
    }
}
