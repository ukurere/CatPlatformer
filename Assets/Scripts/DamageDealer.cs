using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private int damageAmount = 1;

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Collision with: " + col.gameObject.name);
        Health health = col.gameObject.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(damageAmount);
        }
    }
}