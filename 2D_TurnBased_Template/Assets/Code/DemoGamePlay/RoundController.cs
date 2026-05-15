using UnityEngine;
using UnityEngine.Events;

public class RoundController : MonoBehaviour
{
    [Header("Round Info")]
    public int RoundsCounter;
    public int BossEncounterThershold;

    [Header("Starting round info")]
    public bool IsRoundStarted = false;
    public KeyCode StartRoundKey;

    [Header("Upgrade GameObject")]
    public GameObject UpgradePrefab;

    [Header("UI Start GameObject")]
    public GameObject UIStartGameObject;

    [Header("Round Start Events")]
    public bool IsStartedEvent = false;
    public UnityEvent StartRoundEvent;

    private void Update()
    {
        if(Input.GetKeyDown(StartRoundKey) && !IsRoundStarted)
        {
            Debug.Log("start new round");
            IsRoundStarted = true;
            UIStartGameObject.SetActive(false);
            IsStartedEvent = false;
        }
        if (IsRoundStarted)
        {
            if (!IsStartedEvent)
            {
                EnemiesSpawner.Instance.IsAllEnemiesDead = false;
                UpgradePrefab.SetActive(false);
                IsStartedEvent = true;
                StartRoundEvent.Invoke();
            }
        }
        if (EnemiesSpawner.Instance.IsAllEnemiesDead)
        {
            IsRoundStarted = false;
            UpgradePrefab.SetActive(true);
            UIStartGameObject.SetActive(true);
        }
    }

    public void IncrementRoundCounter() => RoundsCounter++; 
}
