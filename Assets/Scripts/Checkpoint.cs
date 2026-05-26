using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private Sprite lampOff;
    [SerializeField] private Sprite lampOn;
    private bool isActivated = false;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && !isActivated)
        {
            isActivated = true;
            GetComponent<SpriteRenderer>().sprite = lampOn;
            CheckpointManager.Instance.SetCheckpoint(transform.position);
        }
    }
}