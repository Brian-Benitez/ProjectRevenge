using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using DG.Tweening;


public class PerkCardController : MonoBehaviour
{
    public List<RectTransform> PerkCardsChoices;
    public List<RectTransform> PerkCards;

    public List<Vector2> AnchorsForCards;
    public Vector2 PickedCardPos;
    public Vector2 PlayerCardsPilePos;
    public Vector2 RestartCardsPos;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            StartCoroutine(PickedACard());

        if(Input.GetKeyDown(KeyCode.DownArrow))
                StartCoroutine(PlaceCardsOnScreen());
    }


    public IEnumerator PlaceCardsOnScreen()
    {
        PerkCardsChoices[0].DOAnchorPos(AnchorsForCards[0], .5f);
        yield return new WaitForSecondsRealtime(0.4f);
        PerkCardsChoices[1].DOAnchorPos(AnchorsForCards[1], .5f);
        yield return new WaitForSecondsRealtime(0.4f);
        PerkCardsChoices[2].DOAnchorPos(AnchorsForCards[2], .5f);
    }

    public IEnumerator PickedACard()
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
                PerkCardsChoices[i].DOAnchorPos(PlayerCardsPilePos, 1f);
            }
        }
    }
    void RandomlyPickingThreeCards()
    {
        for (int i = 0; i < 5; i++)
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
}
