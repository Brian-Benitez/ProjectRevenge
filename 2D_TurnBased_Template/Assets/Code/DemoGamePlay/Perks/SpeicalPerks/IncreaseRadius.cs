using UnityEngine;

public class IncreaseRadius : UpgradePerk
{
    [Header("Stats Info")]
    public float AddedRadiusForSpeical;
    public float AdditionalWaitTime;
    public PlayerMeleeAttack PlayerMeleeAttackRef;
    public override void EnablePerk()
    {
        PlayerMeleeAttackRef.SpeicalRange += Mathf.Clamp(AddedRadiusForSpeical, 0, 3.9f);
        PlayerMeleeAttackRef._maxwaitTimeForSpeical += AdditionalWaitTime;//increase wait time .16f
        PerksController.Instance.AddPerkToList(this.gameObject);
    }
}
