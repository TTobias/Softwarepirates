using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PirateCounterController : MonoBehaviour
{
    public GameObject pirateIcon;
    private GameObject[] icons;
    public int distance;
    public int initPirates;
    private int pirates;
    private TextMeshProUGUI tmp;
    private GameOver gameOver;

    void Start()
    {
        RectTransform rect = GetComponent<RectTransform>();
        icons = new GameObject[initPirates];
        for(int i = 0; i < initPirates; i++)
        {
            GameObject instance = Instantiate(pirateIcon);
            instance.transform.SetParent(transform.parent);
            instance.GetComponent<RectTransform>().SetPositionAndRotation(rect.position + new Vector3(0,i*distance,0), rect.rotation);
            icons[i] = instance;
        }
        gameOver = FindObjectOfType<GameOver>();
        pirates = initPirates;
        tmp = GetComponent<TextMeshProUGUI>();
        //UpdateIcons();
    }

    public void AddPirate()
    {
        if (pirates < initPirates)
            pirates++;
        else
            Debug.LogWarning("Added pirate, but was already at max.");

        UpdateIcons();
    }

    public void RemovePirate()
    {
        pirates--;
        UpdateIcons();
        if (pirates <= 0)
            gameOver.Execute();
    }

    private void UpdateIcons()
    {
        //tmp.text = "Pirates: " + pirates + "/" + initPirates;
        Debug.Log("Setting Color");
        //icons[pirates-1].GetComponent<Image>().color = new Color(255,255,255,100);
        icons[pirates].GetComponent<Image>().enabled = false;
    }
}
