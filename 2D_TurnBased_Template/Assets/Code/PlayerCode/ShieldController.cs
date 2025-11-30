using UnityEngine;

public class ShieldController : MonoBehaviour
{
    [Header("Shield Object")]
    public GameObject ShieldObject;

    public KeyCode ShieldKey;

    [Header("Booleans")]
    public bool IsShieldActive = false;

    private PlayerMovement _playerMovement;

    private void Start()
    {
        _playerMovement = GetComponentInParent<PlayerMovement>();   
    }

    void Update()
    {

        if(_playerMovement.IsDashing)
            return;

        if(Input.GetKey(ShieldKey))
        {
            _playerMovement.SlowPlayer();
            ShieldObject.SetActive(true);
            TurnOnShieldObject();
        }
        else
        {
            _playerMovement.UnSlowPlayer();
            ShieldObject.SetActive(false);
            TurnOffIsShieldActive();
        }
            
    }

    void TurnOnShieldObject() => IsShieldActive = true;
    void TurnOffIsShieldActive() => IsShieldActive = false;
}
