using System.Collections;
using UnityEngine;

public class FallingTrapNew : MonoBehaviour
{
    [Header("Ustawienia pułapki")]
    public int damage = 1;
    public float fallGravity = 5f;      // jak szybko ma spadać
    public float returnSpeed = 1f;      // prędkość powrotu do góry
    public float resetDelay = 0.5f;     // ile czeka po uderzeniu zanim zacznie wracać

    private Rigidbody2D rb;
    private Vector3 startPosition;
    private bool isFalling = false;
    private bool isReturning = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;

        // Upewniamy się, że na starcie wisi w miejscu
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = 0f;
        rb.linearVelocity = Vector2.zero;
    }

    // Wywoływane przez TriggerZone, gdy gracz wejdzie pod pułapkę
    public void Activate()
    {
        if (isFalling || isReturning)
            return;

        isFalling = true;
        rb.gravityScale = fallGravity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isFalling) 
            return;

        // Jeśli trafi gracza – zadaj obrażenia
        if (collision.collider.CompareTag("Player"))
        {
            Health health = collision.collider.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }

        // Jeśli trafi gracza LUB platformę – zatrzymaj się i wracaj
        if (collision.collider.CompareTag("Player") || collision.collider.CompareTag("Platform"))
        {
            StartCoroutine(StopAndReturn());
        }
    }

    private IEnumerator StopAndReturn()
    {
        isFalling = false;

        // Zatrzymanie ruchu
        rb.linearVelocity = Vector2.zero;
        rb.gravityScale = 0f;

        // Mała pauza po uderzeniu
        yield return new WaitForSeconds(resetDelay);

        isReturning = true;

        // Ruch z powrotem do startPosition
        while (Vector2.Distance(transform.position, startPosition) > 0.01f)
        {
            transform.position = Vector2.MoveTowards(transform.position, startPosition, returnSpeed * Time.deltaTime);
            yield return null;
        }

        // Na wszelki wypadek przyklejamy dokładnie do pozycji startowej
        transform.position = startPosition;
        isReturning = false;
    }
}
