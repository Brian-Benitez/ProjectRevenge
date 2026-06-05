using UnityEngine;

public class ExtraSpecialDamage : UpgradePerk
{
    [Header("Stats Info")]
    public int AddedDamage;
    public float DecreaseRangeAmount;
    public PlayerMeleeAttack PlayerMeleeAttackRef;
    public override void EnablePerk()
    {
        PlayerMeleeAttackRef.PlayerSpecialDamg += AddedDamage;//1;
        PlayerMeleeAttackRef.SpeicalRange -= DecreaseRangeAmount;//0.6f;
        PerksController.Instance.AddPerkToList(this.gameObject);
    }
}
