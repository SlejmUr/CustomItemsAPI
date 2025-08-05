using InventorySystem.Items.Jailbird;
using LabApiExtensions.Configs;
using LabApiExtensions.Managers;

namespace CustomItemsAPI.Classes;

/// <summary>
/// Changable values for <see cref="JailbirdHitreg"/>
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
        HitregOffset.MathCalculation(ref jailbirdHitreg._hitregOffset);
        HitregRadius.MathCalculation(ref jailbirdHitreg._hitregRadius);
        DamageMelee.MathCalculation(ref jailbirdHitreg._damageMelee);
        DamageCharge.MathCalculation(ref jailbirdHitreg._damageCharge);
        ConcussionDuration.MathCalculation(ref jailbirdHitreg._concussionDuration);
        FlashedDuration.MathCalculation(ref jailbirdHitreg._flashedDuration);
    }
}
