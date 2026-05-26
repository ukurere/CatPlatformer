using UnityEngine;

public class BubbleRise : MonoBehaviour
{
    [SerializeField] private float riseSpeed = 0.8f;
    [SerializeField] private float maxRise = 2f;
    [SerializeField] private float wobbleStrength = 0.03f;
    [SerializeField] private float wobbleSpeed = 3f;

    private float startY;
    private float startX;
    private SpriteRenderer sr;
    private float phase;

    void Start()
    {
        startY = transform.position.y;
        startX = transform.position.x;
        sr = GetComponent<SpriteRenderer>();
        phase = Random.Range(0f, Mathf.PI * 2f);
    }

    void Update()
    {
        float risen = transform.position.y - startY;
        float progress = risen / maxRise;

        float wobbleX = startX + Mathf.Sin(Time.time * wobbleSpeed + phase) * wobbleStrength;
        transform.position = new Vector3(wobbleX, transform.position.y + riseSpeed * Time.deltaTime, 0);

        if (sr != null)
        {
            Color c = sr.color;
            c.a = Mathf.Lerp(0.8f, 0f, progress);
            sr.color = c;
        }

        if (risen >= maxRise) Destroy(gameObject);
    }
}