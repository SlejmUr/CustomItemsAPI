using CustomItemsAPI.Helpers;
using InventorySystem.Items.Jailbird;

namespace CustomItemsAPI.Classes;

/// <summary>
/// Changable struct for <see cref="JailbirdHitreg"/>
/// </summary>
public class JailbirdHitregClass
{
    /// <summary>
    /// Hitreg offset
    /// </summary>
    public MathValueFloat HitregOffset = new();

    /// <summary>
    /// Hitreg radius
    /// </summary>
    public MathValueFloat HitregRadius = new();

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

    /// <summary>
    /// Applying values to <paramref name="jailbirdHitreg"/>
    /// </summary>
    /// <param name="jailbirdHitreg"></param>
    public void Apply(JailbirdHitreg jailbirdHitreg)
    {
        HitregOffset.MathWithValue(ref jailbirdHitreg._hitregOffset);
        HitregRadius.MathWithValue(ref jailbirdHitreg._hitregRadius);
        DamageMelee.MathWithValue(ref jailbirdHitreg._damageMelee);
        DamageCharge.MathWithValue(ref jailbirdHitreg._damageCharge);
        ConcussionDuration.MathWithValue(ref jailbirdHitreg._concussionDuration);
        FlashedDuration.MathWithValue(ref jailbirdHitreg._flashedDuration);
    }
}
