using UnityEngine;

public class LevelUpManager : MonoBehaviour
{
    [Header("Upgrade Amounts")]
    public int HealthUpgradeAmount;

    [Header("Cost per Upgrade")]
    public int CostAmountForHealthUpgrade;
    private PlayerInfo _playerInfo;

    private void Start()
    {
        _playerInfo = GetComponent<PlayerInfo>();
    }

    public void UpgradePlayerHealth()//used OnClick for UI.
    {
        if(_playerInfo.Souls >= CostAmountForHealthUpgrade)
        {
            Debug.Log("upgraded health + " + HealthUpgradeAmount);
            _playerInfo.CharacterMaxHealthLevel += HealthUpgradeAmount;
        }
        else
        {
            Debug.Log("Player does not have enough souls.");
        }
    }
}
