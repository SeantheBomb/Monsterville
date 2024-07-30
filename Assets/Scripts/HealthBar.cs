using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [SerializeField] Slider healthbar;

    // Start is called before the first frame update
    void Awake()
    {
        KittykatHealth.OnHealthChange += UpdateHealthbar;
    }


    private void OnDestroy()
    {
        KittykatHealth.OnHealthChange -= UpdateHealthbar;
    }

    private void UpdateHealthbar(int health)
    {
        healthbar.value = health;
    }

}
