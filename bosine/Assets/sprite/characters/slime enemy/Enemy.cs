using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 50;
    public Animator animator;
    private bool isDead = false;

    public void TakeDamage(int damage)
    {
        if (isDead) return; // Evita di ricevere danni dopo la morte
        {
        health -= damage;
        animator.SetTrigger("Hurt"); // Attiva l'animazione di danno
        }
        if (health <= 0)
        {
            Die();
        } 
    }

    void Die()
    {
        if (isDead) {return;} // Evita che la funzione venga chiamata più volte
        isDead = true;

        animator.SetTrigger("Die"); // Attiva animazione di morte

        // Disattiva il Collider per evitare interazioni dopo la morte
        GetComponent<Collider2D>().enabled = false;

        // Disattiva la fisica (ferma il movimento e la gravità)
        if (GetComponent<Rigidbody2D>() != null)
        {
            GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }

        // Distrugge il nemico dopo la durata dell'animazione di morte
        Destroy(gameObject, 0.2857143f); // Cambia 1.5f con la durata esatta della tua animazione
    }
}
