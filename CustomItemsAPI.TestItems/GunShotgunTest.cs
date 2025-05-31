using CustomItemsAPI.Helpers;
using CustomItemsAPI.Items;
using LabApi.Features.Wrappers;
using PlayerStatsSystem;

namespace CustomItemsAPI.TestItems;

public class GunShotgunTest : CustomFirearmBase
{
    public override string CustomItemName { get; set; } = nameof(GunShotgunTest);

    public override string Description { get; set; } = nameof(GunShotgunTest);

    public override ItemType Type =>  ItemType.GunShotgun;

    public override MathValueFloat Damage => new(MathOption.Set, 20); // Damage in here is PER PELLET!!

    public override void OnHurt(Player player, Player attacker, FirearmDamageHandler firearmDamageHandler)
    {
        player.SendHint($"You got hit by {attacker.DisplayName}!");
        attacker.SendHint($"You attacked {player.DisplayName}!");
    }
}
