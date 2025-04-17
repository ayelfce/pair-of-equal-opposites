using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextLevel()
    {
        int current = SceneManager.GetActiveScene().buildIndex;
        int next = current + 1;

        if (next < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(next);
        else
            Debug.Log("Tüm seviyeler tamamlandı.");
    }
}