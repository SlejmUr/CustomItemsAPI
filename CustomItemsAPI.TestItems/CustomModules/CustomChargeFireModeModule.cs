using InventorySystem.Items.MicroHID.Modules;

namespace CustomItemsAPI.TestItems.CustomModules;

public class CustomChargeFireModeModule : ChargeFireModeModule
{
    public float firingRange = 150;
    public override float FiringRange => firingRange;
    public float backtrackerDot = 10;
    public override float BacktrackerDot => backtrackerDot;
    public CustomChargeFireModeModule()
    {

    }

    public CustomChargeFireModeModule(ChargeFireModeModule chargeFireModeModule)
    {
        base.UniqueComponentId = chargeFireModeModule.UniqueComponentId;
        base.Item = chargeFireModeModule.Item;
        base.Viewmodel = chargeFireModeModule.Viewmodel;
    }

    public override string ToString()
    {
        return "CustomChargeFireModeModule";
    }
}
