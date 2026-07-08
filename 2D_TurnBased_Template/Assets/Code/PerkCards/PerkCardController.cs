using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class PerkCardController : MonoBehaviour
{
    public RectTransform BackroundCanvas;
    public List<RectTransform> PlayersActivePerks;
    public List<RectTransform> PerkCardsChoices;
    public List<RectTransform> PerkCards;

    public List<Vector2> AnchorsForCards;
    public Vector2 PickedCardPos;
    public Vector2 PlayerCardsPilePos;
    public Vector2 WaitForRemovingPos;
    public Vector2 RestartCardsPos;
    public Vector2 RestartBackroundPos;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            RandomlyPickingThreeCards();
            MoveBackroundOnScreen();
            StartPlaceCardsOnScreenCoroutine();
        }
    }

    public void MoveBackroundOnScreen() => BackroundCanvas.DOAnchorPos(PickedCardPos, 1f);
    public void RestartBackroundOnScreen() => BackroundCanvas.DOAnchorPos(RestartBackroundPos, .5f);
    public void StartPlaceCardsOnScreenCoroutine() => StartCoroutine(PlaceCardsOnScreen());
    private IEnumerator PlaceCardsOnScreen()
    {
        TurnOffButtons(PerkCardsChoices);
        yield return new WaitForSecondsRealtime(1f);
        PerkCardsChoices[0].DOAnchorPos(AnchorsForCards[0], .5f);
        yield return new WaitForSecondsRealtime(0.4f);
        PerkCardsChoices[1].DOAnchorPos(AnchorsForCards[1], .5f);
        yield return new WaitForSecondsRealtime(0.4f);
        PerkCardsChoices[2].DOAnchorPos(AnchorsForCards[2], .5f);
        yield return new WaitForSecondsRealtime(1f);
        TurnOnButtons(PerkCardsChoices);
    }

    public void StartPickedACardCoroutine() => StartCoroutine(PickedACard());
    private IEnumerator PickedACard()
    {
        for (int i = 0; i < PerkCardsChoices.Count; i++)
        {
            if (PerkCardsChoices[i].GetComponent<PerkCardBehaviour>().IsPickedOnChoice)
            {
                PerkCardsChoices[i].DOAnchorPos(PickedCardPos, 1f);
                PlayersActivePerks.Add(PerkCardsChoices[i]);
            }
            else
            {
                PerkCardsChoices[i].DOAnchorPos(RestartCardsPos, .5f);
            }
        }

        yield return new WaitForSecondsRealtime(3f);

        for (int i = 0; i < PerkCardsChoices.Count; i++)
        {
            if (PerkCardsChoices[i].GetComponent<PerkCardBehaviour>().IsPickedOnChoice)
            {
                PerkCardsChoices[i].DOAnchorPos(PlayerCardsPilePos, .5f);
            }
        }
        RestartBackroundOnScreen();
    }

    public void StartDiscardACardCorutine() => StartCoroutine(DiscardACard());
    private IEnumerator DiscardACard()
    {
        for (int i = 0; i < PerkCardsChoices.Count; i++)//adding choosen card
        {
            if (PerkCardsChoices[i].GetComponent<PerkCardBehaviour>().IsPickedOnChoice)
            {
                PlayersActivePerks.Add(PerkCardsChoices[i]);
            }
        }

        for (int i = 0; i < PlayersActivePerks.Count; i++)//animation of moving cards
        {
            if (PlayersActivePerks[i].GetComponent<PerkCardBehaviour>().IsBeingRemoved == true)
            {
                PlayersActivePerks[i].DOAnchorPos(RestartCardsPos, .5f);
            }
            else
            {
                PlayersActivePerks[i].DOAnchorPos(PlayerCardsPilePos, .5f);
            }
        }

        for (int i = 0; i < PlayersActivePerks.Count; i++)//remove perk from list
        {
            if (PlayersActivePerks[i].GetComponent<PerkCardBehaviour>().IsBeingRemoved == true)
            {
                PlayersActivePerks.Remove(PlayersActivePerks[i]);
            }
        }

        yield return new WaitForSecondsRealtime(2f);

        RestartBackroundOnScreen();
    }
    public void RandomlyPickingThreeCards()//sometimes its only two.. we will see if it happens again more
    {
        for (int i = 0; i < 10; i++)
        {
            if(PerkCardsChoices.Count == 3)
            {
                Debug.Log("Max perks has been picked");
            }
            else
            {
                int index = Random.Range(0, PerkCards.Count);
                if (PerkCardsChoices.Contains(PerkCards[index]))
                {
                    Debug.Log("added this card already...restarting");
                }
                else
                {
                    PerkCardsChoices.Add(PerkCards[index]);
                }
            }
        }
    }

    public void CheckIfTheresRoomForAPerk()
    {
        if(PlayersActivePerks.Count >= 3)//change this to a var later
        {
            Debug.Log("player is picking a perk card with maxxed out slots, making them pick...");
            ReadyCardsForOneDiscard();  
        }
        else
        {
            StartPickedACardCoroutine();
        }
    }

    private void ReadyCardsForOneDiscard()
    {
        for (int i = 0; i < PerkCardsChoices.Count; i++)//removing choice cards 
        {
            if (PerkCardsChoices[i].GetComponent<PerkCardBehaviour>().IsPickedOnChoice)
            {
                PerkCardsChoices[i].DOAnchorPos(WaitForRemovingPos, 1f);
            }
            else
            {
                PerkCardsChoices[i].DOAnchorPos(RestartCardsPos, .5f);
            }
        }

        for (int J = 0; J < PlayersActivePerks.Count; J++)//putting active perks on screen and making them have the disable button on
        {
            PlayersActivePerks[J].GetComponent<PerkCardBehaviour>().TurnOffEnableButton();//gotta turn it on again here
            PlayersActivePerks[J].DOAnchorPos(AnchorsForCards[J], .5f);
        }
    }

    private void TurnOffButtons(List<RectTransform> aList)
    {
        for (int i = 0; i < aList.Count; i++)
        {
            aList[i].GetComponent<PerkCardBehaviour>().TurnOffAllButtons();
        }
    }

    private void TurnOnButtons(List<RectTransform> aList)
    {
        for (int i = 0; i < aList.Count; i++)
        {
            aList[i].GetComponent<PerkCardBehaviour>().TurnOnEnableButton();
        }
    }


    public void RemoveAllPerkCardsFromList() => PerkCardsChoices.Clear();
}
