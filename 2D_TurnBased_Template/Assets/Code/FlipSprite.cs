using UnityEngine;

public class FlipSprite : MonoBehaviour
{
    [Header("Animator info")]
    public PlayerAnimationController PlayerAnimationControllerRef;
    public bool isFacingRight = true;
    //public bool IsMeleeing = false;
    float Horizontal;


    private void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");//Litertty to rotate the sprite if it works
        Flip();
        if (Input.GetMouseButton(1) || Input.GetMouseButtonDown(0))
            PlayerLookAtMouse();
    }
    private void Flip()//BUG WHERE IF U MOVE AND MELEE IT IS WRONG LOOKING
    {
        if (isFacingRight && Horizontal < 0f || !isFacingRight && Horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = PlayerAnimationControllerRef.gameObject.transform.localScale;
            localScale.x *= -1f;
            PlayerAnimationControllerRef.gameObject.transform.localScale = localScale;
        }
    }

    public void PlayerLookAtMouse()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();

        if (difference.x >= 0 && !isFacingRight)
        { // mouse is on right side of player
            transform.localScale = new Vector3(1, 1, 1); // or activate look right some other way
            isFacingRight = true;
        }
        if (difference.x < 0 && isFacingRight)
        { // mouse is on left side
            transform.localScale = new Vector3(-1, 1, 1); // activate looking left
            isFacingRight = false;
        }
    }
}
