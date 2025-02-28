using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damage = 2; // Danno in punti vita (2 = 1 cuore intero, 1 = mezzo cuore)
    public float attackRange = 2f;  // Distanza di attacco
    public float attackCooldown = 1.5f;
    public Animator animator;
    private float lastAttackTime;

    private Transform player;
    private PlayerHealth playerHealth;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
            playerHealth = playerObj.GetComponent<PlayerHealth>();
        }
    }

    void Update()
    {
        if (player != null && playerHealth != null)
        {
            float distance = Vector2.Distance(transform.position, player.position);

            if (distance <= attackRange && Time.time > lastAttackTime + attackCooldown)
            {
                AttackPlayer();
                lastAttackTime = Time.time;
            }
        }
    }

    void AttackPlayer()
    {
        if (playerHealth != null)
        {
            animator.SetTrigger("Attack");
            playerHealth.TakeDamage(damage);
        }
    }
}
