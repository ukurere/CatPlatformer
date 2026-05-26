using UnityEngine;

public class WaveAnimator : MonoBehaviour
{
    [SerializeField] private float amplitude = 0.08f;
    [SerializeField] private float frequency = 2f;
    [SerializeField] private float phaseOffset = 0f;

    private Vector3 startPos;

    void Start() { startPos = transform.position; }

    void Update()
    {
        float y = startPos.y + Mathf.Sin(Time.time * frequency + phaseOffset) * amplitude;
        float scaleX = 1f + Mathf.Sin(Time.time * frequency * 0.5f + phaseOffset) * 0.02f;
        transform.position = new Vector3(startPos.x, y, startPos.z);
        transform.localScale = new Vector3(scaleX, transform.localScale.y, 1f);
    }
}