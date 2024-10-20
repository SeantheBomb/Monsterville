using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="AvatarCatalog", menuName = "Monsterville/AvatarCatalog")]
public class AvatarCatalog : ScriptableObject
{

    public Avatar[] avatars;

    public int selectedIndex;

    public int Count => avatars.Length;

    public Avatar GetAvatar(int index)
    {
        return avatars[index];
    }

    public Avatar GetCurrentAvatar()
    {
        selectedIndex = PlayerPrefs.GetInt("CurrentAvatarIndex", 0);
        return GetAvatar(selectedIndex);
    }

    public void LoadSaveProgress()
    {
        for (int i = 0; i < avatars.Length; i++)
        {
            Avatar avatar = avatars[i];
            int startUnlocked = avatar.startsUnlocked ? 1 : 0;
            int saveValue = PlayerPrefs.GetInt($"Unlocked_{avatar.name}", startUnlocked);
            avatar.isUnlocked = saveValue == 1 || avatar.startsUnlocked;
            Debug.Log($"AvatarCatalog: Load {avatar.name} starts unlocked {startUnlocked} save value {saveValue} is unlocked {avatar.isUnlocked}");
        }
    }

}

[System.Serializable]
public class Avatar
{
    public string name;
    public Sprite kittySprite;
    public Sprite eggSprite;
    public AudioClip meow;
    public bool isUnlocked;
    public bool startsUnlocked;
}
