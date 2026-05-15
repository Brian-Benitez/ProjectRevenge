using UnityEngine;
using UnityEngine.Events;

public class RoundController : MonoBehaviour
{
    [Header("Round Info")]
    public int RoundsCounter;
    public int BossEncounterThershold;
    [Header("Timer info")]
    public bool IsRoundStarted = false;
    public float CountdownToNewRound;
    public float MaxTimeTillNewRound;

    [Header("Upgrade GameObject")]
    public GameObject UpgradePrefab;

    [Header("Round Start Events")]
    public bool IsStartedEvent = false;
    public UnityEvent StartRoundEvent;

    private void Update()
    {
        if(CountdownToNewRound >= MaxTimeTillNewRound)
        {
            IsRoundStarted = true;
            IsStartedEvent = false;
            EnemiesSpawner.Instance.IsAllEnemiesDead = false;
            CountdownToNewRound = 0;
        }
        if (EnemiesSpawner.Instance.IsAllEnemiesDead)
        {
            IsRoundStarted = false;
            UpgradePrefab.SetActive(true);
            CountdownToNewRound += Time.deltaTime;
        }
        if (IsRoundStarted)
        {
            if(!IsStartedEvent)
            {
                UpgradePrefab.SetActive(false);
                //start round
                StartRoundEvent.Invoke();
                IsStartedEvent = true;
            }
        }
        
    }

    public void IncrementRoundCounter() => RoundsCounter++; 
}
