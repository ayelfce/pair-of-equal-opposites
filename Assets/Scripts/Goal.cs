using UnityEngine;

public class Goal : MonoBehaviour
{
    public enum GoalType { Left, Right }
    public GoalType goalType;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (goalType == GoalType.Left && other.CompareTag("PlayerLeft"))
        {
            GameManager.Instance.leftReached = true;
            CheckCompletion();
        }
        else if (goalType == GoalType.Right && other.CompareTag("PlayerRight"))
        {
            GameManager.Instance.rightReached = true;
            CheckCompletion();
        }
    }

    void CheckCompletion()
    {
        if (GameManager.Instance.leftReached && GameManager.Instance.rightReached)
        {
            GameManager.Instance.LevelComplete();
        }
    }
}