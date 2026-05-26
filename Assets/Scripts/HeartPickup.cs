using UnityEngine;

public class HeartPickup : MonoBehaviour
{
    [SerializeField] private int healAmount = 1;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Health health = col.GetComponent<Health>();
            if (health != null) health.HealHealth(healAmount);
            Destroy(gameObject);
        }
    }
}