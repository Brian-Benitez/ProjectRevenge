using UnityEngine;

public class MovingPlayerController : MonoBehaviour
{
    public bool IsInTutorial = true;
    public GameObject PlayerPos;

    [Header("Desinations")]
    public GameObject TutorialPos;
    public GameObject FirstLevelPos;


    private void Start()
    {
        PlayerPos.transform.position = TutorialPos.transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(IsInTutorial)
        {
            IsInTutorial = false;
            PlayerPos.transform.position = FirstLevelPos.transform.position;
        }
    }

    public void PlacePlayerInTutorialLevel() => PlayerPos.transform.position = TutorialPos.transform.position;
}
