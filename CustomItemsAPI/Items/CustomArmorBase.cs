using LabApi.Features.Wrappers;
using CustomItemsAPI.Extensions;
using InventorySystem.Items.Armor;
using System.ComponentModel;
using LabApiExtensions.Configs;
using LabApiExtensions.Managers;

namespace CustomItemsAPI.Items;

/// <summary>
/// Custom Armor Base for <see cref="ItemCategory.Armor"/>
/// </summary>
public abstract class CustomArmorBase : CustomItemBase
{
    /// <summary>
    /// Currently not used ingame.
    /// </summary>
    public virtual MathValueInt HelmetEfficacy { get; } = new();

    /// <summary>
    /// Used to alter efficacy for 939 Claw and Explosion Damage
    /// </summary>
    public virtual MathValueInt VestEfficacy { get; } = new();

    /// <summary>
    /// Use to alter stamina usage.
    /// </summary>
    public virtual MathValueFloat StaminaUseMultiplier { get; } = new();

    /// <summary>
    /// Use to alter movement speed.
    /// </summary>
    public virtual MathValueFloat MovementSpeedMultiplier { get; } = new();

    /// <summary>
    /// List of Ammo limits this item changes/provide.
    /// </summary>
    [Description("If null do not change any limit. Otherwise changes limits to it. Make sure you only select Ammo otherwise will be skipped")]
    public virtual List<BodyArmor.ArmorAmmoLimit> AmmoLimits { get; } = null;

    /// <summary>
    /// List of <see cref="ItemCategory"/> limits this item changes/provide.
    /// </summary>
    [Description("If null do not change any limit. Otherwise changes limits to it")]
    public virtual List<BodyArmor.ArmorCategoryLimitModifier> CategoryLimits { get; } = null;

    /// <inheritdoc/>
    public override void Parse(Item item)
    {
        base.Parse(item);
        if (item.Category != ItemCategory.Armor)
            throw new ArgumentOutOfRangeException("Type", item.Type, "Invalid Armor type.");
        if (item is not BodyArmorItem body)
            throw new ArgumentException("Body must not be null!");
        HelmetEfficacy.MathCalculation(ref body.Base.HelmetEfficacy);
        VestEfficacy.MathCalculation(ref body.Base.VestEfficacy);
        StaminaUseMultiplier.MathCalculation(ref body.Base._staminaUseMultiplier);
        MovementSpeedMultiplier.MathCalculation(ref body.Base._movementSpeedMultiplier);
        if (AmmoLimits != null)
        {
            List<BodyArmor.ArmorAmmoLimit> ValidLimits = new(AmmoLimits.Count);
            foreach (var limiter in AmmoLimits)
            {
                if (!limiter.AmmoType.IsAmmo())
                    continue;
                ValidLimits.Add(limiter);
            }
            body.Base.AmmoLimits = [.. ValidLimits];
        }
        if (CategoryLimits != null)
            body.Base.CategoryLimits = [.. CategoryLimits];
    }
}
