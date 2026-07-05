using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PerkCardBehaviour : MonoBehaviour
{
    public RectTransform MovablePartOfCard;
    public float SpeedOfMovement;
    public float AmountOfDistance;
    public bool IsPickedOnChoice = false;
    public Vector2 ToRestartArea;
 
    public void PickThisCard()
    {
        Debug.Log("is clicked on");
        IsPickedOnChoice = true;
        MovablePartOfCard.DOAnchorPosY(AmountOfDistance, SpeedOfMovement);
    }
}
