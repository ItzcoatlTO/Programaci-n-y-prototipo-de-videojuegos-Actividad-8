using UnityEngine;

public class EnemyDespawner : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            GameManager.Instance.RemoveEnemy(collision.gameObject);
        }
    }
}
