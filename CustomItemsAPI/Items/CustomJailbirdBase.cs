using CustomItemsAPI.Classes;
using CustomItemsAPI.Helpers;
using CustomItemsAPI.Interfaces;
using LabApi.Features.Wrappers;

namespace CustomItemsAPI.Items;

/// <summary>
/// Custom <see cref="JailbirdItem"/> base.
/// </summary>
public abstract class CustomJailbirdBase : CustomItemBase, IModuleChangable
{
    /// <inheritdoc/>
    public virtual Dictionary<ModuleChanger, Type> ReplaceModules { get; } = [];
    /// <inheritdoc/>
    public virtual List<ModuleChanger> AddModules { get; } = [];

    /// <summary>
    /// Changable values for <see cref="InventorySystem.Items.Jailbird.JailbirdHitreg"/>
    /// </summary>
    public JailbirdHitregClass JailbirdHitregClass = new();

    /// <summary>
    /// Changable values for <see cref="InventorySystem.Items.Jailbird.JailbirdItem"/>
    /// </summary>
    public JailbirdItemClass JailbirdItemClass = new();

    /// <inheritdoc/>
    public override void Parse(Item item)
    {
        base.Parse(item);
        if (item.Type != ItemType.Jailbird)
            throw new ArgumentOutOfRangeException("Type", item.Type, "Invalid Jailbird type.");
        if (item is not JailbirdItem jailbird)
            throw new ArgumentException("JailbirdItem must not be null!");

        JailbirdHitregClass.Apply(jailbird.Base._hitreg);
        JailbirdItemClass.Apply(jailbird.Base);
    }

    /// <summary>
    /// Called Server Receives a <paramref name="jailbirdMessageType"/> from <paramref name="jailbird"/>.
    /// </summary>
    /// <param name="jailbird"></param>
    /// <param name="jailbirdMessageType"></param>
    public virtual void OnReceived(JailbirdItem jailbird, InventorySystem.Items.Jailbird.JailbirdMessageType jailbirdMessageType)
    {

    }
}
