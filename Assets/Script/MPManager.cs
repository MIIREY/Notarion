using UnityEngine;

public class MPManager : MonoBehaviour
{
    public int currentMP = 0;
    public int maxMP = 100;

    public void AddMP(int amount)
    {
        currentMP += amount;
        currentMP = Mathf.Clamp(currentMP, 0, maxMP);

        Debug.Log("MP: " + currentMP);
    }
}
