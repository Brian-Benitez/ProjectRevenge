using UnityEngine;

public class PlayersUltController : MonoBehaviour
{
    public static PlayersUltController Instance;

    public bool IsUlted;
    public int UltPoints;
    public int MaxUltPoints;
    public float UltDuration;
    public KeyCode UltActivationKey;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }


    private void Update()
    {
        if(Input.GetKeyDown(UltActivationKey))
        {
            if (!IsUlted && UltPoints == MaxUltPoints)
            {
                IsUlted = true;
            }
        }
      
    }
    /// <summary>
    /// Made it like this so i can add objs that will max it or just give one. Only place to add it.
    /// </summary>
    /// <param name="amount"></param>
    public void AddUltPoint(int amount) => UltPoints += amount;
    /// <summary>
    /// Remove all ult points after using ult.
    /// </summary>
    public void RemoveAllUltPoints() => UltPoints = 0;
}
