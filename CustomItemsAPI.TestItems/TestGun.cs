using CustomItemsAPI.Items;
using CustomItemsAPI.Overrides;
using LabApi.Features.Wrappers;
using LabApiExtensions.Enums;

namespace CustomItemsAPI.TestItems;

public class TestGun : CustomFirearmBase
{
    public override string CustomItemName { get; set; } = nameof(TestGun);

    public override string Description { get; set; } = nameof(TestGun);

    public override List<IOverride> Overrides => 
    [
        new A7BurnEffectModuleOverride()
        {
            PerShotDuration = new(MathOption.Multiply, 2)
        }
    ];

    public override ItemType Type =>  ItemType.GunA7;

    public override void OnAim(Player player, FirearmItem weapon, bool aiming)
    {
        base.OnAim(player, weapon, aiming);
    }
}
