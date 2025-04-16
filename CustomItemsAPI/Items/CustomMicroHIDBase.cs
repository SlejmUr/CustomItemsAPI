using CustomItemsAPI.Helpers;
using CustomItemsAPI.Interfaces;
using InventorySystem.Items.MicroHID.Modules;
using LabApi.Features.Wrappers;

namespace CustomItemsAPI.Items;

public abstract class CustomMicroHIDBase : CustomItemBase, IModuleChangable
{
    public virtual Dictionary<ModuleChanger, Type> ReplaceModules { get; } = [];
    public virtual List<ModuleChanger> AddModules { get; } = [];
    public MicroHIDItem MicroItem => Item as MicroHIDItem;
    public override void Parse(Item item)
    {
        base.Parse(item);
        if (item.Type != ItemType.MicroHID)
            throw new ArgumentOutOfRangeException("Type", item.Type, "Invalid MicroHID type.");
        if (Item is not MicroHIDItem)
            throw new ArgumentException("MicroHIDItem must not be null!");
    }
    public float Energy 
    { 
        get
        {
            return MicroItem.Base.EnergyManager.Energy;
        }
        set
        {
            MicroItem.Base.EnergyManager.ServerSetEnergy(Serial, value);
        }
    }

    public bool Broken
    {
        get
        {
            return MicroItem.Base.BrokenSync.Broken;
        }
        set
        {
            MicroItem.Base.BrokenSync.ServerSetBroken(Serial, value);
        }
    }

    public CycleController CycleController
    {
        get
        {
            return MicroItem.Base.CycleController;
        }
    }

    public AudioController AudioController
    {
        get
        {
            return AudioManagerModule.GetController(Serial);
        }
    }

    public FiringModeControllerModule? FiringModeController
    {
        get
        {
            FiringModeControllerModule ret = null;
            CycleController.TryGetLastFiringController(out ret);
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
            return CycleController.LastFiringMode;
        }
        set
        {
            CycleController.LastFiringMode = value;
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
            return CycleController.Phase;
        }
        set
        {
            CycleController.Phase = value;
        }
    }

    public virtual void OnPhaseChanged(MicroHidPhase phase)
    {

    }
}
