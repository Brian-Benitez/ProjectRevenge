using UnityEngine;

public class EnemySwordsman : BaseEnemy
{
    //NOTE: EVERYTHING HERE BUT THE ENEMYTYPE IS JUST PROOF IT CAN WORK. WE CAN CLEAN THIS ALL LATER. MAKE SURE GAME IS FUN FIRST.
    KnockBackFeedBack _knockBackFeedBack;
    private void Start()
    {
         EnemyType = TypeOfEnemy.Swordsman;
        _knockBackFeedBack = GetComponent<KnockBackFeedBack>();
    }

    private void Update()
    {
        if(IsHit && IsStunned)
        {
            _knockBackFeedBack.PlayFeedBack(PlayerController.Instance.Player.gameObject);
            IsHit = false;
            Debug.Log("KNOCKED BACK");
        } 
    }
}
