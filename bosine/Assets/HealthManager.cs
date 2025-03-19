using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image[] hearts; // Array di immagini dei cuori
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;

    public void UpdateHearts(int currentHealth, int maxHealth)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            int heartIndex = i * 2; // Ogni cuore rappresenta 2 HP
            
            if (currentHealth >= heartIndex + 2)
            {
                hearts[i].sprite = fullHeart; // Cuore pieno
            }
            else if (currentHealth == heartIndex + 1)
            {
                hearts[i].sprite = halfHeart; // Mezzo cuore
            }
            else
            {
                hearts[i].sprite = emptyHeart; // Cuore vuoto
            }
        }
    }
}
