using UnityEngine;

public class PlayerSpawnerController : MonoBehaviour
{
    public static PlayerSpawnerController Instance;

    public GameObject StartSpawner;
    public GameObject StatueSpawner;

    public InteractingWithUpgradeSystem InteractingWithUpgradeSystemRef;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void SpawnPlayer()
    {
        if(InteractingWithUpgradeSystemRef.CheckpointReached)
        {
            PlayerController.Instance.Player.position = StatueSpawner.transform.position;
        }
        else
            PlayerController.Instance.Player.position = StartSpawner.transform.position;
    }

}
