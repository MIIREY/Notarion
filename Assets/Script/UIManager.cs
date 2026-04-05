using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider hpBar;
    public Slider mpBar;

    public Health playerHealth;
    public MPManager playerMP;

    void Update()
    {
        hpBar.value = playerHealth.currentHP;
        mpBar.value = playerMP.currentMP;
    }
}
