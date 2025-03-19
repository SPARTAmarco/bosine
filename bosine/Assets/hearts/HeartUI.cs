using UnityEngine;
using UnityEngine.UI;

public class HearthUI : MonoBehaviour
{
    public int maxHealth = 6; // 3 cuori = 6 HP
    public int currentHealth;

    public Image[] hearts; // Array di immagini dei cuori
    public Sprite fullHeart; 
    public Sprite halfHeart; 
    public Sprite emptyHeart; 

    void Start()
    {
        currentHealth = maxHealth; // Iniziamo con vita piena
        UpdateHearts();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
            currentHealth = 0;

        UpdateHearts();
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        UpdateHearts();
    }

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            int heartValue = (i + 1) * 2;

            if (currentHealth >= heartValue)
            {
                hearts[i].sprite = fullHeart;  // Cuore pieno
            }
            else if (currentHealth == heartValue - 1)
            {
                hearts[i].sprite = halfHeart;  // Mezzo cuore
            }
            else
            {
                hearts[i].sprite = emptyHeart; // Cuore vuoto
            }
        }
    }
}
