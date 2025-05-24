using CustomItemsAPI.Helpers;
using InventorySystem.Items.Jailbird;

namespace CustomItemsAPI.Classes;

internal class JailbirdItemClass
{
    public MathValueFloat MeleeDelay = new();
    public MathValueFloat MeleeCooldown = new();
    public MathValueFloat ChargeDuration = new();
    public MathValueFloat ChargeReadyTime = new();
    public MathValueFloat ChargeMovementSpeedMultiplier = new();
    public MathValueFloat ChargeMovementSpeedLimiter = new();
    public MathValueFloat ChargeCancelVelocitySqr = new();
    public MathValueFloat ChargeAutoengageTime = new();
    public MathValueFloat ChargeDetectionDelay = new();
    public MathValueFloat BrokenRemoveTime = new();

    public void Apply(JailbirdItem jailbirdItem)
    {
        MeleeDelay.MathWithValue(ref jailbirdItem._meleeDelay);
        MeleeCooldown.MathWithValue(ref jailbirdItem._meleeCooldown);
        ChargeDuration.MathWithValue(ref jailbirdItem._chargeDuration);
        ChargeReadyTime.MathWithValue(ref jailbirdItem._chargeReadyTime);
        ChargeMovementSpeedMultiplier.MathWithValue(ref jailbirdItem._chargeMovementSpeedMultiplier);
        ChargeMovementSpeedLimiter.MathWithValue(ref jailbirdItem._chargeMovementSpeedLimiter);
        ChargeCancelVelocitySqr.MathWithValue(ref jailbirdItem._chargeCancelVelocitySqr);
        ChargeAutoengageTime.MathWithValue(ref jailbirdItem._chargeAutoengageTime);
        ChargeDetectionDelay.MathWithValue(ref jailbirdItem._chargeDetectionDelay);
        BrokenRemoveTime.MathWithValue(ref jailbirdItem._brokenRemoveTime);
    }
}
