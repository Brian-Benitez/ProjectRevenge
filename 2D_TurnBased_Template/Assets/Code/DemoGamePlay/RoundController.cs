using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class RoundController : MonoBehaviour
{
    [Header("Round Info")]
    public int RoundsCounter;
    public int TotalAmountOfRoundsWon;
    public int MaxAmountOfRounds;
    public TextMeshProUGUI RoundsText;

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

    public bool IsRoundEnd = false;
    public UnityEvent StartEndRoundEvent;

    public UnityEvent BossDefeatedEvent;

    private void Update()
    {
        if(Input.GetKeyDown(StartRoundKey) && !IsRoundStarted)
        {
            Debug.Log("start new round");
            IsRoundStarted = true;
            IsRoundEnd = false;
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
            if(!IsRoundEnd)
            {
                IsRoundStarted = false;
                UpgradePrefab.SetActive(true);
                UIStartGameObject.SetActive(true);
                IsRoundEnd = true;
                StartEndRoundEvent.Invoke();
            }
        }
    }

    public void IncreaseRoundCounter()
    {
        if (RoundsCounter == MaxAmountOfRounds)
            RoundsCounter = 0;
        else
            RoundsCounter += Mathf.Clamp(1, 0, MaxAmountOfRounds);
        TotalAmountOfRoundsWon++;
        RoundsText.text = "" + TotalAmountOfRoundsWon;
    }
    /// <summary>
    /// Only when boss is defeated
    /// </summary>
    public void RestartRoundCounter() => RoundsCounter = 0;
}
