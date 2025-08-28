using InventorySystem.Items.ThrowableProjectiles;

namespace CustomItemsAPI.Overrides;

/// <summary>
/// Override class for <see cref="TimeGrenade"/>.
/// </summary>
public class TimeGrenadeOverride : IOverride<TimeGrenade>
{
    /// <summary>
    /// Changes <see cref="TimeGrenade._fuseTime"/>.
    /// </summary>
    public MathValueFloat FuseTime = new();

    /// <inheritdoc/>
    public virtual Type OverrideType => typeof(TimeGrenade);

    /// <inheritdoc/>
    public virtual void Apply(ref TimeGrenade classToOverride)
    {
        FuseTime.MathCalculation(ref classToOverride._fuseTime);
    }

    /// <inheritdoc/>
    public virtual void Apply(ref object classToOverride)
    {
        if (classToOverride.GetType() != OverrideType)
            return;
        TimeGrenade overrides = (TimeGrenade)classToOverride;
        Apply(ref overrides);
    }
}
