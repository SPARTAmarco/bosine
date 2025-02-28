using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image[] hearts; // Array delle immagini dei cuori
    public Sprite fullHeart;   // Cuore pieno (2 HP)
    public Sprite halfHeart;   // Mezzo cuore (1 HP)
    public Sprite emptyHeart;  // Cuore vuoto (0 HP)

    public void UpdateHearts(int currentHealth, int maxHealth)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth / 2) // Cuore pieno se il player ha almeno 2 HP per quel cuore
            {
                hearts[i].sprite = fullHeart;
            }
            else if (i == currentHealth / 2 && currentHealth % 2 == 1) // Mezzo cuore se il player ha 1 HP in più
            {
                hearts[i].sprite = halfHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart; // Cuore vuoto
            }
        }
    }
}
