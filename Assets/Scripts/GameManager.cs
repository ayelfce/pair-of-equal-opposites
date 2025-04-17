using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool leftReached = false;
    public bool rightReached = false;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void ResetGoals()
    {
        leftReached = false;
        rightReached = false;
    }

    public void LevelComplete()
    {
        Debug.Log("Level Completed!");
        LevelManager.Instance.LoadNextLevel();
    }

    public void RestartLevel()
    {
        LevelManager.Instance.RestartLevel();
    }
}