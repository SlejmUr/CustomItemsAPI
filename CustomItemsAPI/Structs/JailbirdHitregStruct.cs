using InventorySystem.Items.Jailbird;

namespace CustomItemsAPI.Structs;

/// <summary>
/// Changable struct for <see cref="JailbirdHitreg"/>
/// </summary>
internal struct JailbirdHitregStruct
{
    /// <summary>
    /// Hitreg offset
    /// </summary>
    /// <remarks>
    /// <see cref="float.NaN"/> means do not change any value.
    /// </remarks>
    public float HitregOffset = float.NaN;
    /// <summary>
    /// Hitreg radius
    /// </summary>
    /// <remarks>
    /// <see cref="float.NaN"/> means do not change any value.
    /// </remarks>
    public float HitregRadius = float.NaN;
    /// <summary>
    /// How much damage should the melee attack deal
    /// </summary>
    /// <remarks>
    /// <see cref="float.NaN"/> means do not change any value.
    /// </remarks>
    public float DamageMelee = float.NaN;
    /// <summary>
    /// How much damage should the charge attack deal
    /// </summary>
    /// <remarks>
    /// <see cref="float.NaN"/> means do not change any value.
    /// </remarks>
    public float DamageCharge = float.NaN;
    /// <summary>
    /// How long in seconds the 'concussed' effect is applied for on attacked targets
    /// </summary>
    /// <remarks>
    /// <see cref="float.NaN"/> means do not change any value.
    /// </remarks>
    public float ConcussionDuration = float.NaN;
    /// <summary>
    /// How long in seconds the 'flashed' effect is applied for on attacked targets
    /// </summary>
    /// <remarks>
    /// <see cref="float.NaN"/> means do not change any value.
    /// </remarks>
    public float FlashedDuration = float.NaN;

    /// <summary>
    /// Create a new Empty <see cref="JailbirdHitregStruct"/>
    /// </summary>
    public JailbirdHitregStruct()
    {

    }

    /// <summary>
    /// Applying values to <paramref name="jailbirdHitreg"/>
    /// </summary>
    /// <param name="jailbirdHitreg"></param>
    public readonly void Apply(JailbirdHitreg jailbirdHitreg)
    {
        if (!float.IsNaN(HitregOffset))
            jailbirdHitreg._hitregOffset = HitregOffset;
        if (!float.IsNaN(HitregRadius))
            jailbirdHitreg._hitregRadius = HitregRadius;
        if (!float.IsNaN(DamageMelee))
            jailbirdHitreg._damageMelee = DamageMelee;
        if (!float.IsNaN(DamageCharge))
            jailbirdHitreg._damageCharge = DamageCharge;
        if (!float.IsNaN(ConcussionDuration))
            jailbirdHitreg._concussionDuration = ConcussionDuration;
        if (!float.IsNaN(FlashedDuration))
            jailbirdHitreg._flashedDuration = FlashedDuration;
    }
}
