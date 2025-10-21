using CustomItemsAPI.Helpers;
using CustomItemsAPI.Interfaces;
using InventorySystem.Items.MicroHID.Modules;
using LabApi.Features.Wrappers;

namespace CustomItemsAPI.Items;

/// <summary>
/// Custom <see cref="MicroHIDItem"/> base.
/// </summary>
public abstract class CustomMicroHIDBase : CustomItemBase, IModuleChangable
{
    /// <inheritdoc/>
    public virtual Dictionary<ModuleChanger, Type> ReplaceModules { get; } = [];
    /// <inheritdoc/>
    public virtual List<ModuleChanger> AddModules { get; } = [];

    /// <inheritdoc/>
    public override void Parse(Item item)
    {
        base.Parse(item);
        if (item.Type != ItemType.MicroHID)
            throw new ArgumentOutOfRangeException("Type", item.Type, "Invalid MicroHID type.");
        if (item is not MicroHIDItem)
            throw new ArgumentException("MicroHIDItem must not be null!");
    }

    /// <summary>
    /// Called when this <paramref name="microHIDItem"/>'s <see cref="MicroHidPhase"/> changed.
    /// </summary>
    /// <param name="microHIDItem"></param>
    /// <param name="phase"></param>
    public virtual void OnPhaseChanged(MicroHIDItem microHIDItem, MicroHidPhase phase)
    {
        CL.Debug($"OnPhaseChanged {phase}", Main.Instance.Config.Debug);
    }

    /// <summary>
    /// Called when this <paramref name="microHIDItem"/> is broken by <see cref="BrokenSyncModule"/>.
    /// </summary>
    /// <param name="microHIDItem"></param>
    public virtual void OnBroken(MicroHIDItem microHIDItem)
    {
        CL.Debug($"OnBroken {microHIDItem.Serial}", Main.Instance.Config.Debug);
    }
}
