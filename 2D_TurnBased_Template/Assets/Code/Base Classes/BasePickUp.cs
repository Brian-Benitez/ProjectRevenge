using UnityEngine;

public class BasePickUp : MonoBehaviour//My idea being, theres other pickups imma have in the game, i can make all functions here and inherit them later for when I need it
{
    [Header("Health Info")]
    public int HealthGain;

    public void HealPlayer() => PlayerController.Instance.Player.GetComponent<BaseCharacter>().CharacterHealthAmount += HealthGain;
}
