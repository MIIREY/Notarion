using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHP = 100;
    public int currentHP;

    void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int amount)
    {
        currentHP -= amount;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);

        Debug.Log("HP: " + currentHP);

        if (currentHP <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("PLAYER MATI");

        // sementara: hilangin player
        Destroy(gameObject);
    }
}
