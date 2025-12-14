using InventorySystem.Items.Jailbird;

namespace CustomItemsAPI.Overrides;

/// <summary>
/// Override class for <see cref="JailbirdItem"/>
/// </summary>
public class JailbirdItemOverride : IOverride<JailbirdItem>
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
    /// How much damage should the melee attack deal
    /// </summary>
    public MathValueFloat DamageMelee = new();

    /// <summary>
    /// How much damage should the charge attack deal
    /// </summary>
    public MathValueFloat DamageCharge = new();

    /// <summary>
    /// How long in seconds the 'concussed' effect is applied for on attacked targets
    /// </summary>
    public MathValueFloat ConcussionDuration = new();

    /// <summary>
    /// How long in seconds the 'flashed' effect is applied for on attacked targets
    /// </summary>
    public MathValueFloat FlashedDuration = new();

    /// <inheritdoc/>
    public Type OverrideType => typeof(JailbirdItem);

    /// <inheritdoc/>
    public void Apply(ref JailbirdItem jailbirdItem)
    {
        DamageMelee.MathCalculation(ref jailbirdItem.MeleeDamage);
        DamageCharge.MathCalculation(ref jailbirdItem._chargeDamage);
        ConcussionDuration.MathCalculation(ref jailbirdItem._concussionDuration);
        FlashedDuration.MathCalculation(ref jailbirdItem._flashedDuration);
        MeleeDelay.MathCalculation(ref jailbirdItem._meleeDelay);
        MeleeCooldown.MathCalculation(ref jailbirdItem._meleeCooldown);
        ChargeDuration.MathCalculation(ref jailbirdItem._chargeDuration);
        ChargeReadyTime.MathCalculation(ref jailbirdItem._chargeReadyTime);
        ChargeMovementSpeedMultiplier.MathCalculation(ref jailbirdItem._chargeMovementSpeedMultiplier);
        ChargeMovementSpeedLimiter.MathCalculation(ref jailbirdItem._chargeMovementSpeedLimiter);
        ChargeCancelVelocitySqr.MathCalculation(ref jailbirdItem._chargeCancelVelocitySqr);
        ChargeAutoengageTime.MathCalculation(ref jailbirdItem._chargeAutoengageTime);
        ChargeDetectionDelay.MathCalculation(ref jailbirdItem._chargeDetectionDelay);
        BrokenRemoveTime.MathCalculation(ref jailbirdItem._brokenRemoveTime);
    }

    /// <inheritdoc/>
    public void Apply(ref object classToOverride)
    {
        if (classToOverride is not JailbirdItem)
            return;
        JailbirdItem overrides = (JailbirdItem)classToOverride;
        Apply(ref overrides);
    }
}
