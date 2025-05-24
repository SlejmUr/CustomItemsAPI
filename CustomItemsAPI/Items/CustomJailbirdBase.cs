using CustomItemsAPI.Classes;
using CustomItemsAPI.Helpers;
using CustomItemsAPI.Interfaces;
using LabApi.Features.Wrappers;

namespace CustomItemsAPI.Items;

/// <summary>
/// Custom <see cref="JailbirdItem"/> base.
/// </summary>
// TODO: Implement this right.
internal abstract class CustomJailbirdBase : CustomItemBase, IModuleChangable
{
    /// <inheritdoc/>
    public virtual Dictionary<ModuleChanger, Type> ReplaceModules { get; } = [];
    /// <inheritdoc/>
    public virtual List<ModuleChanger> AddModules { get; } = [];

    /// <summary>
    /// The <see cref="CustomItemBase.ItemBase"/> as <see cref="JailbirdItem"/>.
    /// </summary>
    public LabApi.Features.Wrappers.JailbirdItem Jailbird => ItemBase as LabApi.Features.Wrappers.JailbirdItem;

    /// <inheritdoc/>
    public override void Parse(Item item)
    {
        base.Parse(item);
        if (item.Type != ItemType.Jailbird)
            throw new ArgumentOutOfRangeException("Type", item.Type, "Invalid Jailbird type.");
        if (ItemBase is not LabApi.Features.Wrappers.JailbirdItem jailbird)
            throw new ArgumentException("JailbirdItem must not be null!");

        JailbirdHitreg.Apply(jailbird.Base._hitreg);
        JailbirdItem.Apply(jailbird.Base);

    }

    public JailbirdHitregClass JailbirdHitreg = new();

    public JailbirdItemClass JailbirdItem = new();

    public int TotalCharges
    {
        get => Jailbird.Base.TotalChargesPerformed;
        set => Jailbird.Base.TotalChargesPerformed = value;
    }

    public float TotalDamageDealt
    {
        get => Jailbird.Base._hitreg.TotalMeleeDamageDealt;
        set => Jailbird.Base._hitreg.TotalMeleeDamageDealt = value;
    }

}
