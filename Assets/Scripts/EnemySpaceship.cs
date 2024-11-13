using UnityEngine;

public class EnemySpaceship : MonoBehaviour
{
    [SerializeField] protected float speed = 2f;

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(0, -speed * Time.fixedDeltaTime);
        transform.Translate(movement);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Enemy colisionó con Player");
            GameManager.Instance.RestartGame(); 
        }
        else if (collision.collider.CompareTag("Laser"))
        {
            Debug.Log("Enemy colisionó con Laser");
            GameManager.Instance.AddScore(1); 
            gameObject.SetActive(false); 
        }
    }
}
