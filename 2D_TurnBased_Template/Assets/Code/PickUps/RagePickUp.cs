using UnityEngine;

public class RagePickUp : BasePickUp
{
    [Header("Rage Info")]
    public int RageGain;

    public PlayerInfo PlayerInfoRef;

    public void AddRagePoint()
    {
        PlayersUltController.Instance.AddUltPoint(RageGain);
        
    }
}
