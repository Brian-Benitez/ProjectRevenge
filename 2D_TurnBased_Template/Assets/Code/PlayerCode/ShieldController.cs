using UnityEngine;

public class ShieldController : MonoBehaviour
{
    [Header("Shield Object")]
    public GameObject ShieldObject;

    [Header("Shield Info")]
    public int ShieldHealth;
    public int MaxShieldHealth;//Use this to upgrade

    public bool IsShieldActive = false;

    [Header("Cooldown")]
    public bool IsShieldBroken = false;
    public float ShieldCoolDownTimer = 0;
    public float ShieldBreakDuration;

    [Header("Shield key")]
    public KeyCode ShieldKey;


    private PlayerMovement _playerMovement;

    private void Start()
    {
        _playerMovement = GetComponentInParent<PlayerMovement>();
        
    }

    void Update()
    {
        if(_playerMovement.IsDashing)
            return;

        if(Input.GetKey(ShieldKey) && !IsShieldBroken)
        {
            _playerMovement.SlowPlayer();
            ShieldObject.SetActive(true);
            TurnOnShieldObject();
            ChangePlayerLayerName();
        }
        else
        {
            _playerMovement.UnSlowPlayer();
            ShieldObject.SetActive(false);
            TurnOffIsShieldActive();
            ChangeBackPlayerLayerName();
        }

        if(ShieldHealth <= 0)
            IsShieldBroken = true;

        if(IsShieldBroken)
        {
            ShieldCoolDownTimer += Time.deltaTime;

            if(ShieldCoolDownTimer >= ShieldBreakDuration)
            {
                IsShieldBroken = false;
                ShieldHealth = MaxShieldHealth;
            }
        }
            
    }
    void ChangePlayerLayerName() => PlayerController.Instance.Player.gameObject.tag = "Shield";
    void ChangeBackPlayerLayerName() => PlayerController.Instance.Player.gameObject.tag = "Player";
    void TurnOnShieldObject() => IsShieldActive = true;
    void TurnOffIsShieldActive() => IsShieldActive = false;
}
