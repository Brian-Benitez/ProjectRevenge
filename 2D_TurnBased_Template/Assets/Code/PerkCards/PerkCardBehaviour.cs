using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PerkCardBehaviour : MonoBehaviour
{
    public RectTransform MovablePartOfCard;
    public float SpeedOfMovement;
    public float AmountOfDistance;
    public bool IsPickedOnChoice = false;
    public bool IsBeingRemoved = false;
    public GameObject EnablePerkButton;
    public GameObject DisablePerkButton;
    public Vector2 ToRestartArea;
 
    public void PickThisCard()
    {
        Debug.Log("is clicked on");
        IsPickedOnChoice = true;
        //MovablePartOfCard.DOAnchorPosY(AmountOfDistance, SpeedOfMovement);
    }

    public void RemoveThisCard()
    {
        Debug.Log("remove this card..");
        IsBeingRemoved = true;
    }
    public void TurnOffAllButtons()
    {
        EnablePerkButton.SetActive(false);
        DisablePerkButton.SetActive(false);
    }
    public void TurnOnEnableButton()
    {
        EnablePerkButton.SetActive(true);
        DisablePerkButton.SetActive(false);
    }
    public void TurnOffEnableButton()
    {
        EnablePerkButton.SetActive(false);
        DisablePerkButton.SetActive(true);
    }
}
