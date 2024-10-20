using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public bool pressed
    {
        get; protected set;
    }

    public bool pressedThisFrame
    {
        get; private set;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pressed = true;
        pressedThisFrame = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressed = false;
    }

    void LateUpdate()
    {
        pressedThisFrame = false;
    }

}
