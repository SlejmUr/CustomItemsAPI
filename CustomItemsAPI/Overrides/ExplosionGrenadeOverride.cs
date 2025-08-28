﻿using InventorySystem.Items.ThrowableProjectiles;
using UnityEngine;

namespace CustomItemsAPI.Overrides;

/// <summary>
/// Override class for <see cref="ExplosionGrenade"/>
/// </summary>
public class ExplosionGrenadeOverride : TimeGrenadeOverride, IOverride<ExplosionGrenade>
{
    /// <summary>
    /// Changes <see cref="ExplosionGrenade.DetectionMask"/>.
    /// </summary>
    public LayerMask? DetectionMask { get; } = null;

    /// <summary>
    /// Changes <see cref="ExplosionGrenade.MaxRadius"/>.
    /// </summary>
    public MathValueFloat MaxRadius { get; } = new();

    /// <summary>
    /// Changes <see cref="ExplosionGrenade.ScpDamageMultiplier"/>.
    /// </summary>
    public MathValueFloat ScpDamageMultiplier { get; } = new();

    /// <summary>
    /// Changes <see cref="ExplosionGrenade._playerDamageOverDistance"/>.
    /// </summary>
    public AnimationCurve? PlayerDamageOverDistance { get; } = null;

    /// <summary>
    /// Changes <see cref="ExplosionGrenade._effectDurationOverDistance"/>.
    /// </summary>
    public AnimationCurve? FffectDurationOverDistance { get; } = null;

    /// <summary>
    /// Changes <see cref="ExplosionGrenade._doorDamageOverDistance"/>.
    /// </summary>
    public AnimationCurve? DoorDamageOverDistance { get; } = null;

    /// <summary>
    /// Changes <see cref="ExplosionGrenade._shakeOverDistance"/>.
    /// </summary>
    public AnimationCurve? ShakeOverDistance { get; } = null;

    /// <summary>
    /// Changes <see cref="ExplosionGrenade._burnedDuration"/>.
    /// </summary>
    public MathValueFloat BurnedDuration { get; } = new();

    /// <summary>
    /// Changes <see cref="ExplosionGrenade._deafenedDuration"/>.
    /// </summary>
    public MathValueFloat DeafenedDuration { get; } = new();

    /// <summary>
    /// Changes <see cref="ExplosionGrenade._concussedDuration"/>.
    /// </summary>
    public MathValueFloat ConcussedDuration { get; } = new();

    /// <summary>
    /// Changes <see cref="ExplosionGrenade._minimalDuration"/>.
    /// </summary>
    public MathValueFloat MinimalDuration { get; } = new();

    /// <summary>
    /// Changes <see cref="ExplosionGrenade._rigidbodyBaseForce"/>.
    /// </summary>
    public MathValueFloat RigidbodyBaseForce { get; } = new();

    /// <summary>
    /// Changes <see cref="ExplosionGrenade._rigidbodyLiftForce"/>.
    /// </summary>
    public MathValueFloat RigidbodyLiftForce { get; } = new();

    /// <summary>
    /// Changes <see cref="ExplosionGrenade._humeShieldMultipler"/>.
    /// </summary>
    public MathValueFloat HumeShieldMultipler { get; } = new();


    /// <inheritdoc/>
    public override Type OverrideType => typeof(ExplosionGrenade);

    /// <inheritdoc/>
    public void Apply(ref ExplosionGrenade classToOverride)
    {
        if (DetectionMask.HasValue)
            classToOverride.DetectionMask = DetectionMask.Value;
        MaxRadius.MathCalculation(ref classToOverride.MaxRadius);
        ScpDamageMultiplier.MathCalculation(ref classToOverride.ScpDamageMultiplier);
        if (PlayerDamageOverDistance != null)
            classToOverride._playerDamageOverDistance = PlayerDamageOverDistance;
        if (FffectDurationOverDistance != null)
            classToOverride._playerDamageOverDistance = FffectDurationOverDistance;
        if (DoorDamageOverDistance != null)
            classToOverride._doorDamageOverDistance = DoorDamageOverDistance;
        if (ShakeOverDistance != null)
            classToOverride._shakeOverDistance = ShakeOverDistance;
        BurnedDuration.MathCalculation(ref classToOverride._burnedDuration);
        DeafenedDuration.MathCalculation(ref classToOverride._deafenedDuration);
        ConcussedDuration.MathCalculation(ref classToOverride._concussedDuration);
        MinimalDuration.MathCalculation(ref classToOverride._minimalDuration);
        RigidbodyBaseForce.MathCalculation(ref classToOverride._rigidbodyBaseForce);
        RigidbodyLiftForce.MathCalculation(ref classToOverride._rigidbodyLiftForce);
        HumeShieldMultipler.MathCalculation(ref classToOverride._humeShieldMultipler);
    }

    /// <inheritdoc/>
    public override void Apply(ref object classToOverride)
    {
        base.Apply(ref classToOverride);
        if (classToOverride is not ExplosionGrenade)
            return;
        ExplosionGrenade overrides = (ExplosionGrenade)classToOverride;
        Apply(ref overrides);
    }
}
