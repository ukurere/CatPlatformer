using UnityEngine;

public class PoisonZone : MonoBehaviour
{
    [SerializeField] private int damagePerTick = 1;
    [SerializeField] private float tickInterval = 1.5f;

    private float timer;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            timer = 0f;
            Health health = col.GetComponent<Health>();
            if (health != null) health.TakeDamage(damagePerTick);
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            timer += Time.deltaTime;
            if (timer >= tickInterval)
            {
                timer = 0f;
                Health health = col.GetComponent<Health>();
                if (health != null) health.TakeDamage(damagePerTick);
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player")) timer = 0f;
    }
}