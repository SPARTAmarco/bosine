using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPoint; // Punto da cui parte l'attacco
    public float attackRange = 0.5f;
    public int attackDamage = 20;
    public float attackRate = 1f;
    private float nextAttackTime = 0f;

    public LayerMask enemyLayers; // Layer dei nemici

    public Animator animator;

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.X)) // Premi SPAZIO per attaccare
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate; // Ritardo tra gli attacchi
            }
        }
    }

    void Attack()
    {
        // Attiva l'animazione di attacco
        animator.SetTrigger("Attack");

        // Controlla se colpiamo nemici
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    // Mostra il range di attacco nell'editor
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
