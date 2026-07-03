using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using DG.Tweening;


public class PerkCardController : MonoBehaviour
{
    public List<RectTransform> PerkCardsChoices;
    public List<RectTransform> PerkCards;

    public List<Vector2> AnchorsForCards;
    public Vector2 RestartCardsPos;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            RestartCards();

        if(Input.GetKeyDown(KeyCode.DownArrow))
                StartCoroutine(PlaceCardsOnScreen());
    }


    public IEnumerator PlaceCardsOnScreen()
    {
        
        PerkCardsChoices[0].DOAnchorPos(AnchorsForCards[0], .5f);
        yield return new WaitForSecondsRealtime(0.3f);
        PerkCardsChoices[1].DOAnchorPos(AnchorsForCards[1], .5f);
        yield return new WaitForSecondsRealtime(0.3f);
        PerkCardsChoices[2].DOAnchorPos(AnchorsForCards[2], .5f);
    }

    public void RestartCards()
    {
        PerkCardsChoices[0].DOAnchorPos(RestartCardsPos, .5f);
        PerkCardsChoices[1].DOAnchorPos(RestartCardsPos, .5f);
        PerkCardsChoices[2].DOAnchorPos(RestartCardsPos, .5f);
    }
    void PickThreeCards()
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
