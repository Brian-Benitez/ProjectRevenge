using UnityEngine;

public class HealthPickUp : BasePickUp
{
    [Header("Health Info")]
    public float HealthGain;

    private PlayerInfo _playerInfoRef;
    public GameObject Player;

    private void Awake()
    {
        _playerInfoRef = Player.GetComponent<PlayerInfo>();
    }
    //All pick up functions below
    public void HealPlayer()
    {
        if(_playerInfoRef.CharacterHealthAmount == _playerInfoRef.CharacterMaxHealth)
        {
            Debug.Log("health is full.");
        }
        else
        {
            _playerInfoRef.CharacterHealthAmount += HealthGain;
        }

        if(_playerInfoRef.CharacterHealthAmount > _playerInfoRef.CharacterMaxHealth)
        {
            _playerInfoRef.CharacterHealthAmount = _playerInfoRef.CharacterMaxHealth;
        }
        _playerInfoRef.UpdatePlayersStats();
    }
}
