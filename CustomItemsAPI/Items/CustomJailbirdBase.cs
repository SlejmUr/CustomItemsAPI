using CustomItemsAPI.Overrides;
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
    public JailbirdHitregOverride JailbirdHitregOverride = new();

    /// <summary>
    /// Changable values for <see cref="InventorySystem.Items.Jailbird.JailbirdItem"/>
    /// </summary>
    public JailbirdItemOverride JailbirdItemOverride = new();

    /// <inheritdoc/>
    public override void Parse(Item item)
    {
        base.Parse(item);
        if (item.Type != ItemType.Jailbird)
            throw new ArgumentOutOfRangeException("Type", item.Type, "Invalid Jailbird type.");
        if (item is not JailbirdItem jailbird)
            throw new ArgumentException("JailbirdItem must not be null!");

        JailbirdHitregOverride.Apply(ref jailbird.Base._hitreg);
        var jailbirdItemBase = jailbird.Base;
        JailbirdItemOverride.Apply(ref jailbirdItemBase);
    }

    /// <summary>
    /// Called Server processed a <paramref name="message"/> from <paramref name="jailbirdItem"/>.
    /// </summary>
    /// <param name="player"></param>
    /// <param name="jailbirdItem"></param>
    /// <param name="message"></param>
    public virtual void OnProcessedJailbirdMessage(Player player, JailbirdItem jailbirdItem, InventorySystem.Items.Jailbird.JailbirdMessageType message)
    {
        CL.Debug($"ProcessedJailbirdMessage {player.PlayerId} {jailbirdItem.Serial} {message}", Main.Instance.Config.Debug);
    }

    /// <summary>
    /// Called Server processing a <paramref name="message"/> from <paramref name="jailbirdItem"/>.
    /// </summary>
    /// <param name="player"></param>
    /// <param name="jailbirdItem"></param>
    /// <param name="message"></param>
    /// <param name="allowInspectHelper"></param>
    /// <param name="allowAttackHelper"></param>
    /// <param name="isAllowedHelper"></param>
    public virtual void OnProcessingJailbirdMessage(Player player, JailbirdItem jailbirdItem, TypeWrapper<InventorySystem.Items.Jailbird.JailbirdMessageType> message, TypeWrapper<bool> allowInspectHelper, TypeWrapper<bool> allowAttackHelper, TypeWrapper<bool> isAllowedHelper)
    {
        CL.Debug($"ProcessingJailbirdMessage {player.PlayerId} {jailbirdItem.Serial} {message.Value} {allowAttackHelper.Value} {allowInspectHelper.Value}", Main.Instance.Config.Debug);
    }
}
