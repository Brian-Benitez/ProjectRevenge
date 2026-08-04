using UnityEngine;

public class StartingGameController : MonoBehaviour
{
    public KeyCode StartRoundKey;
    [Header("UI Start GameObject")]
    public GameObject EKeyGameObject;
    public GameObject UIStartGameObject;
    [Header("Scripts")]
    public RoundController RoundControllerRef;
    void Update()
    {
        if (Input.GetKeyDown(StartRoundKey) && !RoundControllerRef.IsRoundStarted && XPController.Instance.IsUpgrading == false)
        {
            Debug.Log("start new round");
            RoundControllerRef.IsRoundStarted = true;
            RoundControllerRef.IsRoundEnd = false;
            UIStartGameObject.SetActive(false);
            RoundControllerRef.IsStartedEvent = false;
            EnemiesSpawner.Instance.IsAllEnemiesDead = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            EKeyGameObject.SetActive(true);
            UIStartGameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            EKeyGameObject.SetActive(false);
            UIStartGameObject.SetActive(false);
        }
    }
}
