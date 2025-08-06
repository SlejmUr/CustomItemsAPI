using CustomItemsAPI.Classes;
using CustomItemsAPI.Helpers;
using CustomItemsAPI.Interfaces;
using InventorySystem.Items.Firearms;
using InventorySystem.Items.Firearms.Modules;
using LabApi.Features.Wrappers;
using LabApiExtensions.Configs;
using LabApiExtensions.Managers;
using PlayerStatsSystem;

namespace CustomItemsAPI.Items;

/// <summary>
/// Custom <see cref="RevolverFirearm"/> base.
/// </summary>
public abstract class CustomRevolverBase : CustomFirearmBase
{
    /// <inheritdoc/>
    public override void Parse(Item item)
    {
        base.Parse(item);
        if (item is not RevolverFirearm revolverFirearm)
            throw new ArgumentException("revolverFirearm must not be null!");
    }

    public virtual void OnSpinning(Player player, RevolverFirearm fierarm, TypeWrapper<bool> isAllowed)
    {

    }

    public virtual void OnSpinned(Player player, RevolverFirearm fierarm)
    {

    }
}
