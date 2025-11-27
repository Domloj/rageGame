using UnityEngine;

public class Health : MonoBehaviour
{
    private int startingHealth = 1;
    public int currentHealth; //{ get; private set; }
    [SerializeField] private AudioClip deathSound;
    private UIManager uIManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = startingHealth;
        uIManager = FindFirstObjectByType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int _damage)
    {
        currentHealth -= _damage;

        if (currentHealth == 0)
        {
            if (deathSound != null && SoundManager.instance != null)
            {
                SoundManager.instance.PlaySound(deathSound);
            }
            GetComponent<PlayerController>().enabled = false;
            uIManager.GameOver();
        }
    }
}
