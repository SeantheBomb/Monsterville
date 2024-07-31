using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KittykatHealth : MonoBehaviour
{

    public int maxHealth;
    public int currentHealth;

    public static System.Action<int> OnHealthChange;
    public static System.Action OnHealthZero;

    bool isAlive = true;

    static KittykatHealth instance;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        SetHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        SetHealth(currentHealth - damage);
    }

    [ContextMenu("Test Damage")]
    public void TestHurt()
    {
        TakeDamage(1);
    }


    public void SetHealth(int health)
    {
        currentHealth = health;
        if (isAlive == false) return;
        OnHealthChange?.Invoke(currentHealth);
        if (currentHealth <= 0)
        {
            SetAlive(false);
            OnHealthZero?.Invoke();
            GameOverScreen.ShowLoseScreen();
        }
    }

    public static int AttackKitty(int damage)
    {
        instance.TakeDamage(damage);
        return instance.currentHealth;
    }

    void SetAlive(bool isAlive)
    {
        this.isAlive = isAlive;
        GetComponent<KittykatMove>().enabled = isAlive;
    }

    public void WinGame()
    {
        SetAlive(false);
    }
}
