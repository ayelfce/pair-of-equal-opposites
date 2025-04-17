using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Engelle çarpışma - seviye yeniden başlatılıyor.");
            GameManager.Instance.RestartLevel();
        }
    }
}