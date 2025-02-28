using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;
    public float chaseRange = 5f;
    public float stopDistance = 1f;

    private Rigidbody2D rb;
    private bool isFacingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true; // Evita che il nemico si ribalti
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance < chaseRange && distance > stopDistance)
        {
            // Muove il nemico SOLO in orizzontale usando Rigidbody2D
            Vector2 direction = (player.position - transform.position).normalized;
            rb.linearVelocity = new Vector2(direction.x * speed, rb.linearVelocity.y);

            Flip(direction.x);
        }
        else
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y); // Se è fermo, non si muove
        }
    }

    void Flip(float directionX)
    {
        if ((directionX > 0 && !isFacingRight) || (directionX < 0 && isFacingRight))
        {
            isFacingRight = !isFacingRight;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }
}
