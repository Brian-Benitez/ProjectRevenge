using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public Animator PlayerAnimator;

    public void IsMoving() => PlayerAnimator.SetBool("IsMoving", true);
    public void IsNotMoving() => PlayerAnimator.SetBool("IsMoving", false);
}
