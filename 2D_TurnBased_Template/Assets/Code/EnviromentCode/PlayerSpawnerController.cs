using UnityEngine;

public class PlayerSpawnerController : MonoBehaviour
{
    public static PlayerSpawnerController Instance;

    public GameObject StartSpawner;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void SpawnPlayer()
    {
        PlayerController.Instance.Player.position = StartSpawner.transform.position;
    }

}
