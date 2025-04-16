using CustomItemsAPI.Items;
using LabApi.Features.Wrappers;
using PlayerStatsSystem;

namespace CustomItemsAPI.TestItems;

public class GunShotgunTest : CustomFirearmBase
{
    public override string CustomItemName => nameof(GunShotgunTest);

    public override string Description => nameof(GunShotgunTest);

    public override ItemType ItemType =>  ItemType.GunShotgun;

    public override float Damage => 50;

    public override void OnHurt(Player target, Player attacker, FirearmDamageHandler firearmDamageHandler)
    {
        target.SendHint($"You got hit by {attacker.DisplayName}!");
    }
}
