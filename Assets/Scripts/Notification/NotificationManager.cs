using UnityEngine;
using TMPro;
using System.Collections;

public class NotificationManager : MonoBehaviour
{
    public static NotificationManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    [Header("UI Elements")]
    public GameObject notificationPanel;
    public TMP_Text messageText;

    void Start()
    {
        notificationPanel.SetActive(false);
    }

    public void ShowMessage(string message)
    {
        messageText.text = message;
        notificationPanel.SetActive(true);

        StopAllCoroutines();
        StartCoroutine(HideAfterDelay());
    }

    IEnumerator HideAfterDelay()
    {
        yield return new WaitForSeconds(10f);
        notificationPanel.SetActive(false);
    }
}