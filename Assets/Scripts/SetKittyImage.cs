using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetKittyImage : MonoBehaviour
{
    public Image view;
    public AvatarCatalog catalog;


    // Start is called before the first frame update
    void Start()
    {
        Avatar avatar = catalog.GetCurrentAvatar();
        view.sprite = avatar.kittySprite;
    }
}
