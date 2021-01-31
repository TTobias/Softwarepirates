using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Sprite enterSprite;

    private void Start()
    {
        Cursor.visible = true;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            GetComponent<Image>().sprite = enterSprite;
        }

        if(Input.GetKeyUp(KeyCode.Return))
        {
            StartGame();
        }
    }
    public void StartGame() {
        SceneManager.LoadScene(1);
    }
}
