using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class PerkCardBehaviour : MonoBehaviour
{
    public RectTransform MovablePartOfCard;
    public bool IsUp = false;
    public bool IsNotPicked = false;
    public Vector2 ToRestartArea;
    int UILayer;

    private void Start()
    {
        UILayer = LayerMask.NameToLayer("PerkUI");
    }

    private void Update()
    {
        if(IsNotPicked)
        {
            MovablePartOfCard.DOAnchorPos(ToRestartArea, .5f);
        }
        if(IsPointerOverUIElement() && IsUp == false)
        {
            MovablePartOfCard.DOAnchorPosY(15f, .7f);
            IsUp = true;
        }
        else if(!IsPointerOverUIElement() && IsUp)
        {
            MovablePartOfCard.DOAnchorPosY(-15f, .7f);
            IsUp = false;
        }
    }


    //Returns 'true' if we touched or hovering on Unity UI element.
    public bool IsPointerOverUIElement()
    {
        return IsPointerOverUIElement(GetEventSystemRaycastResults());
    }


    //Returns 'true' if we touched or hovering on Unity UI element.
    private bool IsPointerOverUIElement(List<RaycastResult> eventSystemRaysastResults)
    {
        for (int index = 0; index < eventSystemRaysastResults.Count; index++)
        {
            RaycastResult curRaysastResult = eventSystemRaysastResults[index];
            if (curRaysastResult.gameObject.layer == UILayer)
                return true;
        }
        return false;
    }


    //Gets all event system raycast results of current mouse or touch position.
    static List<RaycastResult> GetEventSystemRaycastResults()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> raysastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raysastResults);
        return raysastResults;
    }
}
