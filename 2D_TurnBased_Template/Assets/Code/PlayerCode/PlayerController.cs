using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }

    public Transform Player;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

}
