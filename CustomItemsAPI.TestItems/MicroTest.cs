using CustomItemsAPI.Items;
using CustomItemsAPI.TestItems.CustomModules;
using InventorySystem.Items;
using InventorySystem.Items.Autosync;
using InventorySystem.Items.MicroHID.Modules;
using LabApi.Features.Wrappers;

namespace CustomItemsAPI.TestItems;

class MicroTest : CustomMicroHIDBase
{
    public override string CustomItemName => "MicroTest"; 

    public override string Description => "Testing micro";

    public override ItemType ItemType => ItemType.MicroHID;

    private int firedTimes;

    public override void Parse(Item item)
    {
        base.Parse(item);
        List<SubcomponentBase> Bases = [];
        foreach (var subcomponent in MicroItem.Base.AllSubcomponents)
        {
            if (subcomponent is ChargeFireModeModule chargeFireModeModule)
            {
                try
                {
                    var custom = new CustomChargeFireModeModule(chargeFireModeModule);
                    var custom_base = (ChargeFireModeModule)custom;
                    custom_base = chargeFireModeModule;
                    Bases.Add(custom);
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
        MicroItem.Base.OnAdded(null);
    }

    public override void OnChanged(Player player, bool changedToThisItem)
    {
        if (!changedToThisItem)
            return;
        firedTimes = 0;
        
        CycleController.RecacheFiringModes(MicroItem.Base);
    }

    public override void OnPicked(Player player, Item item)
    {
        Parse(item);
    }

    public override void OnPhaseChanged(MicroHidPhase newPhase)
    {
        Energy = 100;
        if (AudioController._windupSource != null)
            AudioController._windupSource.maxDistance *= 2;

        if (newPhase == MicroHidPhase.Firing)
        {
            if (AudioController._firingSource != null)
                AudioController._firingSource.maxDistance *= 5;

            firedTimes++;
        }

        if (firedTimes > 5 && !Broken)
        {
            Broken = true;
        }
    }
}
