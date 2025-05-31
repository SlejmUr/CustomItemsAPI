using CustomItemsAPI.Helpers;
using InventorySystem.Items.Jailbird;

namespace CustomItemsAPI.Classes;

/// <summary>
/// Changable values for <see cref="JailbirdItem"/>
/// </summary>
public class JailbirdItemClass
{
    /// <summary>
    /// Changes <see cref="JailbirdItem._meleeDelay"/>.
    /// </summary>
    public MathValueFloat MeleeDelay = new();
    /// <summary>
    /// Changes <see cref="JailbirdItem._meleeCooldown"/>.
    /// </summary>
    public MathValueFloat MeleeCooldown = new();
    /// <summary>
    /// Changes <see cref="JailbirdItem._chargeDuration"/>.
    /// </summary>
    public MathValueFloat ChargeDuration = new();
    /// <summary>
    /// Changes <see cref="JailbirdItem._chargeReadyTime"/>.
    /// </summary>
    public MathValueFloat ChargeReadyTime = new();
    /// <summary>
    /// Changes <see cref="JailbirdItem._chargeMovementSpeedMultiplier"/>.
    /// </summary>
    public MathValueFloat ChargeMovementSpeedMultiplier = new();
    /// <summary>
    /// Changes <see cref="JailbirdItem._chargeMovementSpeedLimiter"/>.
    /// </summary>
    public MathValueFloat ChargeMovementSpeedLimiter = new();
    /// <summary>
    /// Changes <see cref="JailbirdItem._chargeCancelVelocitySqr"/>.
    /// </summary>
    public MathValueFloat ChargeCancelVelocitySqr = new();
    /// <summary>
    /// Changes <see cref="JailbirdItem._chargeAutoengageTime"/>.
    /// </summary>
    public MathValueFloat ChargeAutoengageTime = new();
    /// <summary>
    /// Changes <see cref="JailbirdItem._chargeDetectionDelay"/>.
    /// </summary>
    public MathValueFloat ChargeDetectionDelay = new();
    /// <summary>
    /// Changes <see cref="JailbirdItem._brokenRemoveTime"/>.
    /// </summary>
    public MathValueFloat BrokenRemoveTime = new();

    /// <summary>
    /// Applying values to <paramref name="jailbirdItem"/>
    /// </summary>
    /// <param name="jailbirdItem"></param>
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
