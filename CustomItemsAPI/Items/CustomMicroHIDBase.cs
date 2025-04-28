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

    /// <summary>
    /// The <see cref="CustomItemBase.ItemBase"/> as <see cref="MicroHIDItem"/>.
    /// </summary>
    public MicroHIDItem MicroItem => ItemBase as MicroHIDItem;

    /// <inheritdoc/>
    public override void Parse(Item item)
    {
        base.Parse(item);
        if (item.Type != ItemType.MicroHID)
            throw new ArgumentOutOfRangeException("Type", item.Type, "Invalid MicroHID type.");
        if (ItemBase is not MicroHIDItem)
            throw new ArgumentException("MicroHIDItem must not be null!");
    }

    /// Gets or sets the <see cref="MicroHIDItem"/>'s Energy.
    public float Energy 
    { 
        get
        {
            return MicroItem.Energy;
        }
        set
        {
            MicroItem.Energy = value;
        }
    }

    /// Gets or sets the <see cref="MicroHIDItem"/>'s Broken state.
    public bool Broken
    {
        get
        {
            return MicroItem.IsBroken;
        }
        set
        {
            MicroItem.IsBroken = value;
        }
    }

    /// <summary>
    /// Gets the <see cref="MicroHIDItem"/>'s <see cref="CycleSyncModule"/>.
    /// </summary>
    public CycleController BaseCycleController
    {
        get
        {
            return MicroItem.BaseCycleController;
        }
    }

    /// <summary>
    /// Gets the <see cref="MicroHIDItem"/>'s <see cref="AudioController"/>.
    /// </summary>
    public AudioController BaseAudioController
    {
        get
        {
            return AudioManagerModule.GetController(Serial);
        }
    }

    /// <summary>
    /// Gets the <see cref="MicroHIDItem"/>'s last <see cref="FiringModeControllerModule"/>.
    /// </summary>
    public FiringModeControllerModule? FiringModeController
    {
        get
        {
            BaseCycleController.TryGetLastFiringController(out FiringModeControllerModule ret);
            return ret;
        }
    }

    /// <summary>
    /// Get or Set the current <see cref="MicroHidFiringMode"/>
    /// </summary>
    public MicroHidFiringMode FiringMode
    {
        get
        {
            return BaseCycleController.LastFiringMode;
        }
        set
        {
            BaseCycleController.LastFiringMode = value;
        }
    }

    /// <summary>
    /// Get or Set the current <see cref="MicroHidPhase"/>
    /// </summary>
    /// <remarks>
    /// Set will result calling <see cref="OnPhaseChanged"/>!
    /// </remarks>
    public MicroHidPhase Phase
    {
        get
        {
            return BaseCycleController.Phase;
        }
        set
        {
            BaseCycleController.Phase = value;
        }
    }

    /// <summary>
    /// Called when this <see cref="MicroItem"/>'s <see cref="MicroHidPhase"/> changed.
    /// </summary>
    /// <param name="phase"></param>
    public virtual void OnPhaseChanged(MicroHidPhase phase)
    {
        CL.Debug($"OnPhaseChanged {phase}", Main.Instance.Config.Debug);
    }
}
