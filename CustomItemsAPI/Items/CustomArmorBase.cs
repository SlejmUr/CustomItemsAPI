using LabApi.Features.Wrappers;
using CustomItemsAPI.Extensions;
using InventorySystem.Items.Armor;

namespace CustomItemsAPI.Items;

public abstract class CustomArmorBase : CustomItemBase
{
    /// <summary>
    /// 
    /// </summary>
    [Description("Value must be between 0 and 100. -1 means do not change.")]
    public virtual int HelmetEfficacy { get; } = -1;

    /// <summary>
    /// 
    /// </summary>
    [Description("Value must be between 0 and 100. -1 means do not change.")]
    public virtual int VestEfficacy { get; } = -1;

    [Description("Value must be between 1f and 2f. NaN means do not change.")]
    public virtual float StaminaUseMultiplier { get; } = float.NaN;

    [Description("Value must be between 0f and 1f. NaN means do not change.")]
    public virtual float MovementSpeedMultiplier { get; } = float.NaN;

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


    [Description("Should not drop the excess items.")]
    public virtual bool DontRemoveExcessOnDrop { get; } = false;

    public override void Parse(Item item)
    {
        base.Parse(item);
        if (item.Category != ItemCategory.Armor)
            throw new ArgumentOutOfRangeException("Type", item.Type, "Invalid Armor type.");
        if (item is not BodyArmorItem body)
            throw new ArgumentException("Body must not be null!");
        if (HelmetEfficacy != -1)
            body.Base.HelmetEfficacy = HelmetEfficacy;
        if (VestEfficacy != -1)
            body.Base.VestEfficacy = VestEfficacy;
        if (StaminaUseMultiplier != float.NaN)
            body.Base._staminaUseMultiplier = StaminaUseMultiplier;
        if (MovementSpeedMultiplier != float.NaN)
            body.Base._movementSpeedMultiplier = MovementSpeedMultiplier;
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
        body.Base.DontRemoveExcessOnDrop = DontRemoveExcessOnDrop;
    }

    // TOOD: add picking/picked up armor.
}
