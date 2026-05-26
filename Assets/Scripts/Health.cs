using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    private int currentHealth;
    private UIManager uiManager;

    void Start()
    {
        currentHealth = maxHealth;
        uiManager = FindAnyObjectByType<UIManager>();
        if (uiManager == null) { Debug.LogError("UIManager not found!"); return; }
        uiManager.UpdateHearts(currentHealth, maxHealth);
    }

    public void TakeDamage(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth - amount, 0, maxHealth);
        if (uiManager != null) uiManager.UpdateHearts(currentHealth, maxHealth);

        if (currentHealth <= 0)
            GameManager.Instance.GameOver();
        else
            transform.position = CheckpointManager.Instance.GetCheckpoint();
    }

    public void HealHealth(int amount)
    {
        maxHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        if (uiManager != null) uiManager.UpdateHearts(currentHealth, maxHealth);
    }

    public void RestoreHealth()
    {
        currentHealth = maxHealth;
        if (uiManager != null) uiManager.UpdateHearts(currentHealth, maxHealth);
    }

    public int GetHealth() => currentHealth;
    public int GetMaxHealth() => maxHealth;
}