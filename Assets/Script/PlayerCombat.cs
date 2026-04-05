using UnityEngine;

public enum AttackColor { Red, Blue, Yellow }

public class PlayerCombat : MonoBehaviour
{
    public Transform parryPoint;
    public float parryRadius = 1f;
    public MPManager mpManager;
    public LayerMask attackLayer;
    public float perfectParryDistance = 0.5f;

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
        Collider2D[] hits = Physics2D.OverlapCircleAll(parryPoint.position, parryRadius, attackLayer);

        foreach (var hit in hits)
        {
            EnemyAttack attack = hit.GetComponent<EnemyAttack>();

            if (attack.color == inputColor)
            {
                float distance = Vector2.Distance(parryPoint.position, hit.transform.position);

                if (distance <= perfectParryDistance)
                {
                    Debug.Log("PERFECT PARRY!");
                    mpManager.AddMP(15);
                }
                else
                {
                    Debug.Log("GOOD PARRY");
                    mpManager.AddMP(8);
                }

                Projectile proj = hit.GetComponent<Projectile>();
                if (proj != null)
                {
                    proj.Parried();
                }
                else
                {
                    Destroy(hit.gameObject);
                }

                return;
            }
        }

        Debug.Log("Miss Parry");
    }
    public interface IParryable
    {
        void OnParried();
        AttackColor GetColor();
    }
    void OnDrawGizmosSelected()
    {
        if (parryPoint == null) return;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(parryPoint.position, parryRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, perfectParryDistance);
    }
}