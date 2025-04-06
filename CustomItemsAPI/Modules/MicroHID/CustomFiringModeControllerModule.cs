using InventorySystem.Items.MicroHID.Modules;

namespace CustomItemsAPI.Modules.MicroHID;

public class CustomFiringModeControllerModule(MicroHidFiringMode mode) : FiringModeControllerModule
{
    public float firingRange = 20f;
    public float backtrackerDot = 0.9f;
    public float windUpRate = 1f / 7f;
    public float windDownRate = 0.2f;
    public float drainRateWindUp = 0.01f;
    public float drainRateSustain = 0.005f;
    public float drainRateFiring = 0.1f;
    public override MicroHidFiringMode AssignedMode => mode;
    public override float FiringRange => firingRange;
    public override float BacktrackerDot => backtrackerDot;
    public override float WindUpRate => windUpRate;
    public override float WindDownRate => windDownRate;
    public override float DrainRateWindUp => drainRateWindUp;
    public override float DrainRateSustain => drainRateSustain;
    public override float DrainRateFiring => drainRateFiring;
    public override bool ValidateStart => validateStart();
    public override bool ValidateEnterFire => validateEnterFire();
    public override bool ValidateUpdate => validateUpdate();

    public virtual bool validateStart()
    {
        return false;
    }

    public virtual bool validateEnterFire()
    {
        return false;
    }

    public virtual bool validateUpdate()
    {
        return false;
    }
}
