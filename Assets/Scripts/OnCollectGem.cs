using UnityEngine;

public class OnCollectGem : MonoBehaviour
{
    [SerializeField] private GameObject platformToActivate;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (platformToActivate != null)
            {
                Debug.Log("blip");
                platformToActivate.SetActive(true);

                NotificationManager.Instance.ShowMessage("Hura! Zdoby³eœ punkt!");
            }

            Destroy(gameObject);
        }
    }
}