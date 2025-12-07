using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public bool triggered;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        triggered = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Weszło w trigger: " + collision.name);
        if (collision.CompareTag("Player"))
        {
            triggered = true;
        }
    }
}
