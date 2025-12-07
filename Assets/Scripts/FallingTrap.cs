using System.Collections;
using UnityEngine;

public class FallingTrap : MonoBehaviour
{
    public int damage;
    public TriggerZone triggerZone;

    private Rigidbody2D body;
    private bool hasFallen = false;
    private Vector3 startPosition;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    void Update()
    {
        if (triggerZone.triggered && !hasFallen)
        {
            Fall();
            hasFallen = true;
        }
    }

    public void Fall()
    {
        body.gravityScale = 3;
    }

    IEnumerator Reset()
    {
        float liftSpeed = 1f;

        while (Vector2.Distance(transform.position, startPosition) > 0.01f)
        {
            transform.position = Vector2.MoveTowards(transform.position, startPosition, liftSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = startPosition;

        hasFallen = false;
        triggerZone.triggered = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }

        if (collision.CompareTag("Player") || collision.CompareTag("Platform"))
        {
            body.linearVelocity = Vector2.zero;
            body.gravityScale = 0;
            body.angularVelocity = 0;

            StartCoroutine(Reset());
        }
    }
}
