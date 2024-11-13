using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 10f;

    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        if (transform.position.y > 10f)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Debug.Log("Laser colisionó con Enemy");
            GameManager.Instance.RemoveEnemy(collision.gameObject);
            gameObject.SetActive(false);
            GameManager.Instance.AddScore(1);
        }
    }
}
