using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{

    static GameOverScreen instance;


    public TMP_Text text;

    public string winText;
    public string loseText;


    private void Start()
    {
        text.gameObject.SetActive(false);
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public static void ShowWinScreen()
    {
        instance.text.text = instance.winText;
        instance.gameObject.SetActive(true);
    }

    public static void ShowLoseScreen()
    {
        instance.text.text = instance.loseText;
        instance.gameObject.SetActive(true);
    }
}
