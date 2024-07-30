using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class SpeechBubble: MonoBehaviour
{
    public SpeechBlurb[] speechText;

    [SerializeField] TMP_Text speechBubble;
    [SerializeField] AudioSource speechOutput;

    int speechIndex;


    // Start is called before the first frame update
    void Start()
    {
        speechIndex = 0;
        ShowNextSpeech();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ShowNextSpeech()
    {
        //speechBubble.text = speechText[speechIndex];
        StopAllCoroutines();
        StartCoroutine(ShowText(speechText[speechIndex]));
        speechIndex++;
    }

    IEnumerator ShowText(SpeechBlurb blurb)
    {
        blurb.action?.Invoke();
        speechBubble.text = "";
        speechOutput.clip = blurb.voiceover;
        speechOutput.Play();
        foreach(char c in blurb.text)
        {
            speechBubble.text += c;
            yield return new WaitForSeconds(0.1f);
        }
    }

    [Serializable]
    public struct SpeechBlurb
    {
        [TextArea]
        public string text;
        public AudioClip voiceover;
        public UnityEvent action;
    }
}
