using UnityEngine;

public class TrapTriggerZone : MonoBehaviour
{
    [SerializeField] private FallingTrapNew trap;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            trap.Activate();
        }
    }
}
