using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetKittyAvatar : MonoBehaviour
{

    public SpriteRenderer view;
    public KittykatMove move;

    public AvatarCatalog catalog;


    // Start is called before the first frame update
    void Start()
    {
        Avatar avatar = catalog.GetCurrentAvatar();
        view.sprite = avatar.kittySprite;
        move.meow = avatar.meow;
    }

}
