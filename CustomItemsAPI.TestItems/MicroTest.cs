using CustomItemsAPI.Helpers;
using CustomItemsAPI.Items;
using CustomItemsAPI.TestItems.Modules.MicroHID;
using InventorySystem.Items.Autosync;
using InventorySystem.Items.MicroHID.Modules;
using LabApi.Features.Wrappers;

namespace CustomItemsAPI.TestItems;

public class MicroTest : CustomMicroHIDBase
{
    public override Dictionary<ModuleChanger, Type> ReplaceModules => new()
    {
        { new(typeof(ChargeFireModeModule),0, "Firing Modes"), typeof(CustomCharge) }
    };
    public override string CustomItemName => nameof(MicroTest); 

    public override string Description => "Testing micro";

    public override ItemType Type => ItemType.MicroHID;

    private int firedTimes; 
    /*
    public override void Parse(Item item)
    {
        base.Parse(item);
        foreach (var subcomponent in MicroItem.Base.AllSubcomponents)
        {
            CL.Info("MicroTest.subcomponent: " + subcomponent);
        }
        List<SubcomponentBase> Bases = [];
        foreach (var subcomponent in MicroItem.Base.AllSubcomponents)
        {
            if (subcomponent is ChargeFireModeModule _)
            {
                try
                {
                    Bases.Add(MicroItem.Base.gameObject.AddComponent(typeof(CustomCharge)) as SubcomponentBase);
                    continue;
                }
                catch (Exception ex)
                {
                    CL.Error(ex);
                }
            }
            Bases.Add(subcomponent);
        }
        MicroItem.Base.AllSubcomponents = [.. Bases];
        foreach (var subcomponent in MicroItem.Base.AllSubcomponents)
        {
            CL.Info("MicroTest.subcomponent2: " + subcomponent);
        }
        MicroItem.Base.OnAdded(null);
    }
    */

    public override void OnChanged(Player player, bool changedToThisItem)
    {
        if (!changedToThisItem)
            return;
        firedTimes = 0;
        
        BaseCycleController.RecacheFiringModes(MicroItem.Base);
    }

    public override void OnPhaseChanged(MicroHidPhase newPhase)
    {
        Energy = 100;
        if (BaseAudioController._windupSource != null)
            BaseAudioController._windupSource.maxDistance *= 2;

        if (FiringModeController is CustomCharge module)
        {
            CL.Info(module);
        }

        if (newPhase == MicroHidPhase.Firing)
        {
            if (BaseAudioController._firingSource != null)
                BaseAudioController._firingSource.maxDistance *= 5;

            firedTimes++;
        }

        if (firedTimes > 5 && !Broken)
        {
            Broken = true;
        }
    }
}
