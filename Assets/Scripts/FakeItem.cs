using System;
using UnityEngine;

public class FakeItem : MonoBehaviour
{
    [SerializeField] private int damage;
    private Vector2 startPosition;

    public GameObject onCollect;
    public float upDownSpeed;
    public float height;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newY = startPosition.y + Mathf.Sin(Time.time * upDownSpeed) * height;
        transform.position = new Vector2(transform.position.x, newY);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
