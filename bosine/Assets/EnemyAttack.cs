using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damage = 10;
    public float attackRange = 2f;  // Distanza di attacco
    public float attackCooldown = 1.5f;
    private float lastAttackTime;

    private Transform player;  

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;  // Trova il Player
    }

    void Update()
    {
        if (player != null)
        {
            float distance = Vector2.Distance(transform.position, player.position);

            if (distance <= attackRange && Time.time > lastAttackTime + attackCooldown)
            {
                player.GetComponent<PlayerHealth>().TakeDamage(damage);
                lastAttackTime = Time.time;
            }
        }
    }
}
