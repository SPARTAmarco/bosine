using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player; // Assegna il player
    public float speed = 3f;
    public float chaseRange = 5f; // Distanza di inseguimento
    public float stopDistance = 1f; // Distanza a cui si ferma

    private bool isFacingRight = true;

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance < chaseRange && distance > stopDistance)
        {
            // Muove il nemico verso il player
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            Flip();
        }
    }

    void Flip()
    {
        if ((player.position.x > transform.position.x && !isFacingRight) ||
            (player.position.x < transform.position.x && isFacingRight))
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }
}
