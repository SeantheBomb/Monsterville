using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AvatarSelection : MonoBehaviour
{

    [Header("Design")]
    public AvatarCatalog avatars;


    [Header("References")]
    public Image image;
    public AudioSource audio;
    public TMP_Text text;
    public Button playButton;

    int currentIndex;

    // Start is called before the first frame update
    void Start()
    {
        avatars.LoadSaveProgress();
        ShowAvatar(PlayerPrefs.GetInt("CurrentAvatarIndex", 0));
    }

    public void ShowAvatar(int index)
    {
        if(index < 0 || index >= avatars.Count) { return; }

        Avatar avatar = avatars.GetAvatar(index);

        image.sprite = avatar.isUnlocked ? avatar.kittySprite : avatar.eggSprite;
        text.text = avatar.isUnlocked ? avatar.name : "Locked";

        currentIndex = index;

        playButton.interactable = avatar.isUnlocked;

        if (avatar.isUnlocked)
        {
            audio.PlayOneShot(avatar.meow);
            PlayerPrefs.SetInt("CurrentAvatarIndex", currentIndex);
            avatars.selectedIndex = currentIndex;
        }
    }

    public void ShowNext()
    {
        ShowAvatar(currentIndex + 1);
    }

    public void ShowPrevious()
    {
        ShowAvatar(currentIndex - 1);
    }


    
}


