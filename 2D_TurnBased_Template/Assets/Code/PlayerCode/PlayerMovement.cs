using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float PlayerSpeed;
    public float FullSpeed;
    public float HalfSpeed;
    public GameObject PlayerObject;
    public Rigidbody2D Rb;

    public bool StopPlayerMovement = false;

    [Header("Dash Settings")]
    public KeyCode DashInputKey;
    public float DashSpeed = 10f;
    public float DashDuration = 1f;
    public float DashCoolDown = 1f;
    public bool IsDashing;
    public bool CanDash = true;

    Vector2 moveDirection;
    Vector2 mousePosition;


    private void Update()
    {

        if(Input.GetKey(KeyCode.Mouse1) ||Input.GetKeyDown(KeyCode.Mouse0))
        {
            Rb.linearVelocity = new Vector2(0, 0);
            moveDirection = Vector2.zero;
        }
            
        if(IsDashing)
            return;

        if (StopPlayerMovement)
        {
            moveDirection = Vector2.zero;
            Rb.linearVelocity = new Vector2(0, 0);
            return;
        }
        else
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");

            moveDirection = new Vector2(moveX, moveY).normalized;
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetKeyDown(DashInputKey) && CanDash)
        {
            Debug.Log("dash");
            StartCoroutine(Dash());
        }
    }

    private void FixedUpdate()
    {
        if (IsDashing)
            return;

        Rb.linearVelocity  = new Vector2(moveDirection.x * PlayerSpeed, moveDirection.y * PlayerSpeed);
    }

    public IEnumerator Dash()
    {
        CanDash = false;
        IsDashing = true;
        Rb.linearVelocity = new Vector2(moveDirection.x * DashSpeed, moveDirection.y * DashSpeed);
        yield return new WaitForSeconds(DashDuration);
        IsDashing = false;  
        yield return new WaitForSeconds(DashCoolDown);
        CanDash = true;
    }
    /// <summary>
    /// Slows player down and cannot dash
    /// </summary>
    public void SlowPlayer()
    { 
        PlayerSpeed = HalfSpeed;
        CanDash = false;
    }
    /// <summary>
    /// unslows player and can dash
    /// </summary>
    public void UnSlowPlayer()
    {
        PlayerSpeed = FullSpeed;
        CanDash = true;    
    }

    /// <summary>
    /// Stops player from moving and dashing
    /// </summary>
    public void TurnOnStopPlayerMovement()
    {
        StopPlayerMovement = true;
        CanDash = false;
    }
    /// <summary>
    /// Lets players move and dash again.
    /// </summary>
    public void TurnOffStopPlayerMovement()
    {
        StopPlayerMovement = false;
        CanDash = true;
    }
}
