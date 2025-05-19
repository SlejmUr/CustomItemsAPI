using InventorySystem.Items.Jailbird;

namespace CustomItemsAPI.Structs;

internal struct JailbirdItemStruct
{
    public float MeleeDelay = float.NaN;
    public float MeleeCooldown = float.NaN;
    public float ChargeDuration = float.NaN;
    public float ChargeReadyTime = float.NaN;
    public float ChargeMovementSpeedMultiplier = float.NaN;
    public float ChargeMovementSpeedLimiter = float.NaN;
    public float ChargeCancelVelocitySqr = float.NaN;
    public float ChargeAutoengageTime = float.NaN;
    public float ChargeDetectionDelay = float.NaN;
    public float BrokenRemoveTime = float.NaN;
    public JailbirdItemStruct()
    {

    }

    public readonly void Apply(JailbirdItem jailbirdItem)
    {
        if (!float.IsNaN(MeleeDelay))
            jailbirdItem._meleeDelay = MeleeDelay;
        if (!float.IsNaN(MeleeCooldown))
            jailbirdItem._meleeCooldown = MeleeCooldown;
        if (!float.IsNaN(ChargeDuration))
            jailbirdItem._chargeDuration = ChargeDuration;
        if (!float.IsNaN(ChargeReadyTime))
            jailbirdItem._chargeReadyTime = ChargeReadyTime;
        if (!float.IsNaN(ChargeMovementSpeedMultiplier))
            jailbirdItem._chargeMovementSpeedMultiplier = ChargeMovementSpeedMultiplier;
        if (!float.IsNaN(ChargeMovementSpeedLimiter))
            jailbirdItem._chargeMovementSpeedLimiter = ChargeMovementSpeedLimiter;
        if (!float.IsNaN(ChargeCancelVelocitySqr))
            jailbirdItem._chargeCancelVelocitySqr = ChargeCancelVelocitySqr;
        if (!float.IsNaN(ChargeAutoengageTime))
            jailbirdItem._chargeAutoengageTime = ChargeAutoengageTime;
        if (!float.IsNaN(ChargeDetectionDelay))
            jailbirdItem._chargeDetectionDelay = ChargeDetectionDelay;
        if (!float.IsNaN(BrokenRemoveTime))
            jailbirdItem._brokenRemoveTime = BrokenRemoveTime;
    }
}
