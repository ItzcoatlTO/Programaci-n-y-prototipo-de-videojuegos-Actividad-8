using UnityEngine;

public class ZigZagEnemy : EnemySpaceship
{
    [SerializeField] private float zigzagFrequency = 2f;
    [SerializeField] private float zigzagAmplitude = 2f;
    private float elapsedTime = 0f;

    private void FixedUpdate()
    {
        elapsedTime += Time.fixedDeltaTime;
        float xOffset = Mathf.Sin(elapsedTime * zigzagFrequency) * zigzagAmplitude;
        Vector2 movement = new Vector2(xOffset, -speed * Time.fixedDeltaTime);
        transform.Translate(movement);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("ZigZagEnemy colisionó con Player");
            GameManager.Instance.RestartGame(); 
        }
        else if (collision.collider.CompareTag("Laser"))
        {
            Debug.Log("ZigZagEnemy colisionó con Laser");
            GameManager.Instance.AddScore(1);
            GameManager.Instance.RemoveEnemy(gameObject);
        }
    }
}
