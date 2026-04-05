using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    public void Parried()
    {
        // nanti bisa tambahin efek disini (particle / sound)
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Hit!");

            Health hp = other.GetComponent<Health>();

            if (hp != null)
            {
                hp.TakeDamage(10); // bebas atur damage
            }

            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}