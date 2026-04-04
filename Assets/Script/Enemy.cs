using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 3;

    // warna musuh (optional dulu)
    public string requiredColor = "ANY";

    public void TakeDamage(string attackColor)
    {
        if (requiredColor != "ANY" && attackColor != requiredColor)
        {
            Debug.Log("Wrong color!");
            return;
        }

        health--;

        Debug.Log("Enemy Hit! HP: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}