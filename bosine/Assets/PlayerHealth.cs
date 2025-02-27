using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Vita massima
    private int currentHealth;  // Vita attuale
    public Slider healthBar;    // Riferimento alla barra della vita
    public Animator animator;
    public Collider2D collider;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
    }

    // Funzione per ricevere danno
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.value = currentHealth;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Quando il player muore
    void Die()
    {
        Debug.Log("Il Player è morto!");
        collider.enabled = false;
        animator.SetTrigger("Die");
        // Puoi aggiungere animazioni, respawn o altre azioni
    }
}
