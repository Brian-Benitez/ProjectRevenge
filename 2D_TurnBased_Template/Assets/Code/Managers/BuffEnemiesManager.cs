using UnityEngine;
using UnityEngine.Events;

public class BuffEnemiesManager : MonoBehaviour
{
    public static BuffEnemiesManager Instance;
    public UnityEvent BossDefeatedEvent;
    public UnityEvent RestartEnemiesShieldEvent;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        StartRestartEnemiesShieldEvent();
    }
    public void StartBossDefeatedEvent() => BossDefeatedEvent.Invoke();
    public void StartRestartEnemiesShieldEvent() => RestartEnemiesShieldEvent.Invoke();
}
