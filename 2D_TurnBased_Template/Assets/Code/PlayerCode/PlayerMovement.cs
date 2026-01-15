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
    public float DashSpeed;
    public float DashDuration;
    public float DashCoolDown;
    public bool IsDashing;
    public bool CanDash = true;
    public bool IsDashPaused = false;

    Vector2 moveDirection;
    Vector2 mousePosition;
    float Horizontal;
    [Header("Animator info")]
    public PlayerAnimationController PlayerAnimationControllerRef;
    public bool isFacingRight = true;


    private void Update()
    {

        if (Input.GetKey(KeyCode.Mouse1) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            Rb.linearVelocity = new Vector2(0, 0);
            moveDirection = Vector2.zero;
        }

        if (IsDashing)
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
        if (moveDirection == Vector2.zero)
            PlayerAnimationControllerRef.IsNotMoving();
        else
        {
            PlayerAnimationControllerRef.IsMoving();
        }

        if (Input.GetKeyDown(DashInputKey) && CanDash && !IsDashPaused)
        {
            Debug.Log("dash");
            StartCoroutine(Dash());
        }
        Horizontal = Input.GetAxisRaw("Horizontal");//Litertty to rotate the sprite if it works
        Flip();
    }

    private void FixedUpdate()
    {
        if (IsDashing)
            return;

        Rb.linearVelocity = new Vector2(moveDirection.x * PlayerSpeed, moveDirection.y * PlayerSpeed);
    }

    public IEnumerator Dash()
    {
        CanDash = false;
        IsDashing = true;
        Rb.linearVelocity = new Vector2(moveDirection.x * DashSpeed, moveDirection.y * DashSpeed);
        yield return new WaitForSeconds(DashDuration);
        IsDashing = false;
        yield return new WaitForSeconds(DashCoolDown);
        Debug.Log("long we waited " + DashCoolDown);
        CanDash = true;
    }
    /// <summary>
    /// Slows player down and cannot dash
    /// </summary>
    public void SlowPlayer()
    {
        PlayerSpeed = HalfSpeed;
        IsDashPaused = true;
    }
    /// <summary>
    /// unslows player and can dash
    /// </summary>
    public void UnSlowPlayer()
    {
        PlayerSpeed = FullSpeed;
        IsDashPaused = false;
    }

    /// <summary>
    /// Stops player from moving and dashing
    /// </summary>
    public void TurnOnStopPlayerMovement()
    {
        StopPlayerMovement = true;
        IsDashPaused = true;
    }
    /// <summary>
    /// Lets players move and dash again.
    /// </summary>
    public void TurnOffStopPlayerMovement()
    {
        StopPlayerMovement = false;
        IsDashPaused = false;
    }

    private void Flip()
    {
        if (isFacingRight && Horizontal < 0f || !isFacingRight && Horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = PlayerAnimationControllerRef.gameObject.transform.localScale;
            localScale.x *= -1f;
            PlayerAnimationControllerRef.gameObject.transform.localScale = localScale;
        }

    }
}
