using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private int damageAmount = 1;
    [SerializeField] private bool stopAtEdges = true;

    private int direction = 1;
    private SpriteRenderer sr;
    private Collider2D col;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        transform.position += Vector3.right * direction * moveSpeed * Time.deltaTime;
        if (stopAtEdges) CheckEdge();
    }

    // Рейкаст вниз перед ворогом — якщо немає підлоги, розвернутись
    void CheckEdge()
    {
        float halfW = col != null ? col.bounds.extents.x + 0.1f : 0.35f;
        float halfH = col != null ? col.bounds.extents.y : 0.25f;

        Vector2 checkPos = new Vector2(
            transform.position.x + direction * halfW,
            transform.position.y - halfH
        );

        RaycastHit2D hit = Physics2D.Raycast(checkPos, Vector2.down, 0.3f);
        if (hit.collider == null) Flip();
    }

    void Flip()
    {
        direction *= -1;
        if (sr != null) sr.flipX = direction < 0;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Health health = collision.gameObject.GetComponent<Health>();
            if (health != null) health.TakeDamage(damageAmount);
            return;
        }

        // Вдарив у стіну/перешкоду — розвернутись
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (Mathf.Abs(contact.normal.x) > 0.5f)
            {
                Flip();
                break;
            }
        }
    }
}