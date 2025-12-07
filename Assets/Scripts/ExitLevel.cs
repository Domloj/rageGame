using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour
{
    [SerializeField] public LevelLoader levelLoader;

    void OnTriggerEnter2D(Collider2D collision)
    {
        levelLoader.LoadNextScene();
    }
}
