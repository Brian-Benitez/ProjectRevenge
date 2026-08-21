using System.Collections;
using UnityEngine;

public class UltBarUI : MonoBehaviour
{
    public static UltBarUI Instance;
    public float UltAmount, MaxUltAmount, Width, Height;

    public RectTransform UltBar;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void SetUIMaxUlt(float maxHealth)
    {
        MaxUltAmount = maxHealth;
    }

    public void SetUIUltAmount(float amount)
    {
        UltAmount += amount;
        if (UltAmount > MaxUltAmount)
            UltAmount = MaxUltAmount;
            

        float newWidth = (UltAmount / MaxUltAmount) * Width;
        UltBar.sizeDelta = new Vector2(newWidth, Height);
    }

    public void DrainUltUI()
    {
        UltAmount = MaxUltAmount;
        SetUIUltAmount(UltAmount);
    }
}
