using CustomItemsAPI.Classes;
using CustomItemsAPI.Items;
using LabApi.Features.Wrappers;

namespace CustomItemsAPI.TestItems;

public class TestGun : CustomFirearmBase
{
    public override string CustomItemName { get; set; } = nameof(TestGun);

    public override string Description { get; set; } = nameof(TestGun);

    public override A7Burn A7Burn => new()
    {
        PerShotDuration = new(Helpers.MathOption.Multiply, 2),
    };

    public override ItemType Type =>  ItemType.GunA7;

    public override void OnAim(Player player, FirearmItem weapon, bool aiming)
    {
        base.OnAim(player, weapon, aiming);
    }
}
