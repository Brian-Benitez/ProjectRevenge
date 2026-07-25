using UnityEngine;
using UnityEngine.Events;

public class BuffEnemiesManager : MonoBehaviour
{
    public static BuffEnemiesManager Instance;
    public UnityEvent BossDefeatedEvent;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void StartBossDefeatedEvent() => BossDefeatedEvent.Invoke();
}
