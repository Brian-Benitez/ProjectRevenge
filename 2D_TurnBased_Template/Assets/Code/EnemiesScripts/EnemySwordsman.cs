using UnityEngine;

public class EnemySwordsman : BaseEnemy
{
    KnockBackFeedBack _knockBackFeedBack;
    public Rigidbody2D Rigidbody2D;
    private void Start()
    {
         EnemyType = TypeOfEnemy.Swordsman;
        _knockBackFeedBack = GetComponent<KnockBackFeedBack>();
    }

    private void Update()
    {
        if(IsHit)
        {
            _knockBackFeedBack.PlayFeedBack(PlayerController.Instance.Player.gameObject);
            IsHit = false;
            Debug.Log("KNOCKED BACK");
        }
            
    }

    public void TurnOffIsKinimatic() => Rigidbody2D.bodyType = RigidbodyType2D.Dynamic;

    public void TurnOnIsKinimatic() => Rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
}
