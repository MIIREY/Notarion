using UnityEngine;

public enum AttackColor { Red, Blue, Yellow }

public class PlayerCombat : MonoBehaviour
{
    public Transform parryPoint;
    public float parryRadius = 1f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
            TryParry(AttackColor.Red);

        if (Input.GetKeyDown(KeyCode.K))
            TryParry(AttackColor.Blue);

        if (Input.GetKeyDown(KeyCode.L))
            TryParry(AttackColor.Yellow);
    }

    void TryParry(AttackColor inputColor)
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(parryPoint.position, parryRadius);

        foreach (var hit in hits)
        {
            EnemyAttack attack = hit.GetComponent<EnemyAttack>();

            if (attack != null && attack.canBeParried)
            {
                if (attack.color == inputColor)
                {
                    Debug.Log("Perfect Parry!");

                    Projectile proj = hit.GetComponent<Projectile>();
                    if (proj != null)
                    {
                        proj.Reflect();
                    }
                    else
                    {
                        Destroy(hit.gameObject);
                    }

                    return;
                }
            }
        }

        Debug.Log("Miss Parry");
    }
}