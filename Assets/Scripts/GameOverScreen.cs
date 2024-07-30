using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{

    static GameOverScreen instance;


    public TMP_Text title, body;
    public Button yesButton, noButton;

    public AudioSource audioOutput;

    public GameOverBlurb win, lose;


    private void Start()
    {
        gameObject.SetActive(false);
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
        instance.ShowBlurb(instance.win);
        instance.gameObject.SetActive(true);
    }

    public static void ShowLoseScreen()
    {
        instance.ShowBlurb(instance.lose);
        instance.gameObject.SetActive(true);
    }

    public void ShowBlurb(GameOverBlurb blurb)
    {
        title.text = blurb.title;
        body.text = blurb.body;
        yesButton.onClick.RemoveAllListeners();
        yesButton.onClick.AddListener(()=>blurb.yesAction?.Invoke());
        noButton.onClick.RemoveAllListeners();
        noButton.onClick.AddListener(()=>blurb.noAction?.Invoke());
        audioOutput.PlayOneShot(blurb.sound);
    }
}

[Serializable]
public struct GameOverBlurb
{
    public string title;
    public string body;
    public UnityEvent yesAction;
    public UnityEvent noAction;
    public AudioClip sound;
}
