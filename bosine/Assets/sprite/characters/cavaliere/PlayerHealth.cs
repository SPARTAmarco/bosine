using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 6; // Ora la vita è 6, perché 1 cuore = 2 HP
    private int currentHealth;

    public HealthManager healthManager; // Riferimento a HealthManager

    void Start()
    {
        currentHealth = maxHealth;
        healthManager.UpdateHearts(currentHealth, maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;

        healthManager.UpdateHearts(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;

        healthManager.UpdateHearts(currentHealth, maxHealth);
    }

    void Die()
    {
        Debug.Log("Il Player è morto!");
        // Qui puoi mettere animazioni di morte o respawn
    }
}
