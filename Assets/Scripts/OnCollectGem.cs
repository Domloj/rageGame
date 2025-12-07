using UnityEngine;

public class OnCollectGem : MonoBehaviour
{
    [SerializeField] private GameObject platformToActivate;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (platformToActivate != null)
            {
                Debug.Log("blip");
                platformToActivate.SetActive(true);
            }
            
            Destroy(gameObject);
        }
    }
}
