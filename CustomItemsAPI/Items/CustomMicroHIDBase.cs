using InventorySystem.Items.MicroHID.Modules;
using LabApi.Features.Wrappers;

namespace CustomItemsAPI.Items;

public abstract class CustomMicroHIDBase : CustomItemBase
{
    public MicroHIDItem MicroItem => Item as MicroHIDItem;
    public float Energy 
    { 
        get
        {
            if (MicroItem == null)
                return 0;
            return MicroItem.Base.EnergyManager.Energy;
        }
        set
        {
            if (MicroItem == null)
                return;
            MicroItem.Base.EnergyManager.ServerSetEnergy(Serial, value);
        }
    }

    public bool Broken
    {
        get
        {
            if (MicroItem == null)
                return false;
            return MicroItem.Base.BrokenSync.Broken;
        }
        set
        {
            if (MicroItem == null)
                return;
            MicroItem.Base.BrokenSync.ServerSetBroken(Serial, value);
        }
    }

    public CycleController CycleController
    {
        get
        {
            if (MicroItem == null)
                return null;
            return MicroItem.Base.CycleController;
        }
    }

    public AudioController AudioController
    {
        get
        {
            if (MicroItem == null)
                return null;
            return AudioManagerModule.GetController(Serial);
        }
    }

    public FiringModeControllerModule FiringModeController
    {
        get
        {
            if (MicroItem == null)
                return null;
            if (CycleController == null)
                return null;
            FiringModeControllerModule ret = null;
            CycleController.TryGetLastFiringController(out ret);
            return ret;
        }
    }

    public MicroHidFiringMode FiringMode
    {
        get
        {
            if (MicroItem == null)
                return MicroHidFiringMode.PrimaryFire;
            if (CycleController == null)
                return MicroHidFiringMode.PrimaryFire;
            return CycleController.LastFiringMode;
        }
        set
        {
            if (MicroItem == null)
                return;
            if (CycleController == null)
                return;
            CycleController.LastFiringMode = value;
        }
    }

    public MicroHidPhase Phase
    {
        get
        {
            if (MicroItem == null)
                return MicroHidPhase.Standby;
            if (CycleController == null)
                return MicroHidPhase.Standby;
            return CycleController.Phase;
        }
        set
        {
            if (MicroItem == null)
                return;
            if (CycleController == null)
                return;
            CycleController.Phase = value;
        }
    }

    public virtual void OnPhaseChanged(MicroHidPhase newPhase)
    {

    }
}
