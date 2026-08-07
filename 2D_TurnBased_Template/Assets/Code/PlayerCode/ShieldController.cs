using System.Collections;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    public static ShieldController instance;//For every singlton we have, make sure everything works then start making things private that we dont need

    [Header("Shield Object")]
    public GameObject ShieldObject;
    public GameObject ParryShieldObject;
    public bool IsParrying = false;
    public float ParryDuration;
    public int InputAmountForParry;

    [Header("Shield Info")]
    public float ShieldHealth;
    public float MaxShieldHealth;//Use this to upgrade

    public bool IsShieldActive = false;

    [Header("Cooldown")]
    public bool IsShieldBroken = false;
    private float ShieldCoolDownTimer = 0;
    public float ShieldBreakDuration;

    [Header("Shield key")]
    public KeyCode ShieldKey;

    private PlayerMovement _playerMovement;


    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        _playerMovement = GetComponentInParent<PlayerMovement>();
        
    }

    void Update()
    {
        if(_playerMovement.IsDashing) //PlayerStunnedStateRef.IsPlayerStuuned)
            return;

        if (Input.GetKeyDown(ShieldKey))
            InputAmountForParry++;

        if (InputAmountForParry >= 2)
        {
            _playerMovement.SlowPlayer();
            ShieldObject.SetActive(false);
            StartCorutineActivateParry();
            InputAmountForParry = 0;
        }
     
        if (Input.GetKey(ShieldKey) && !IsShieldBroken && !IsParrying)
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
            //ChangeBackPlayerLayerName();
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
    public void UpgradeShield(float increment)
    {
        MaxShieldHealth += increment;
        ShieldHealth = MaxShieldHealth;
    }

    public void StartCorutineActivateParry() => StartCoroutine(ActivateParry());
    IEnumerator ActivateParry()
    {
        IsParrying = true;
        ParryShieldObject.SetActive(true);
        ParryShieldObject.gameObject.tag = "Parry";
        ChangePlayerLayerToParry();
        yield return new WaitForSecondsRealtime(ParryDuration);
        ParryShieldObject.SetActive(false);
        ChangeBackPlayerLayerName();
        IsParrying = false;
        ParryShieldObject.gameObject.tag = "Untagged";
    }
    void ChangePlayerLayerToParry() => PlayerController.Instance.Player.gameObject.tag = "Parry";
    void ChangePlayerLayerName() => PlayerController.Instance.Player.gameObject.tag = "Shield";
    void ChangeBackPlayerLayerName() => PlayerController.Instance.Player.gameObject.tag = "Player";
    void TurnOnShieldObject() => IsShieldActive = true;
    void TurnOffIsShieldActive() => IsShieldActive = false;
}
