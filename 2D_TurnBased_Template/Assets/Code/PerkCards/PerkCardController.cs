using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class PerkCardController : MonoBehaviour
{
    public RectTransform BackroundCanvas;
    public List<RectTransform> PerkCardsChoices;
    public List<RectTransform> PerkCards;

    public List<Vector2> AnchorsForCards;
    public Vector2 PickedCardPos;
    public Vector2 PlayerCardsPilePos;
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
        TurnOffButtons();
        yield return new WaitForSecondsRealtime(1f);
        PerkCardsChoices[0].DOAnchorPos(AnchorsForCards[0], .5f);
        yield return new WaitForSecondsRealtime(0.4f);
        PerkCardsChoices[1].DOAnchorPos(AnchorsForCards[1], .5f);
        yield return new WaitForSecondsRealtime(0.4f);
        PerkCardsChoices[2].DOAnchorPos(AnchorsForCards[2], .5f);
        yield return new WaitForSecondsRealtime(1f);
        TurnOnButtons();
    }

    public void StartPickedACardCoroutine() => StartCoroutine(PickedACard());
    private IEnumerator PickedACard()
    {
        for (int i = 0; i < PerkCardsChoices.Count; i++)
        {
            if (PerkCardsChoices[i].GetComponent<PerkCardBehaviour>().IsPickedOnChoice)
            {
                PerkCardsChoices[i].DOAnchorPos(PickedCardPos, 1f);
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
                    //restart randomrange
                }
                else
                {
                    PerkCardsChoices.Add(PerkCards[index]);
                }
            }
        }
    }

    public void TurnOffButtons()
    {
        for (int i = 0; i < PerkCardsChoices.Count; i++)
        {
            PerkCardsChoices[i].GetComponentInChildren<Button>().interactable = false;
        }
    }

    public void TurnOnButtons()
    {
        for (int i = 0; i < PerkCardsChoices.Count; i++)
        {
            PerkCardsChoices[i].GetComponentInChildren<Button>().interactable = true;
        }
    }


    public void RemoveAllPerkCardsFromList() => PerkCardsChoices.Clear();
}
