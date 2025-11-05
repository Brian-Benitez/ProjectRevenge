using UnityEngine;

public class SoulsBankController : MonoBehaviour
{
    public static SoulsBankController instance;
    [Header("Souls Bank")]
    public int SoulsBank;

    public GameObject PlayerGO;
    PlayerInfo _playerInfo;

    private void Awake()
    {
        if(instance == null)
            instance = this;
    }

    private void Start()
    {
        _playerInfo = PlayerGO.GetComponent<PlayerInfo>();  
    }

    public void PayoutToPlayer() => _playerInfo.Souls += SoulsBank;
}
