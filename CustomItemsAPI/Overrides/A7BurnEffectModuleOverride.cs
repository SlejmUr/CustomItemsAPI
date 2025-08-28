using InventorySystem.Items.Firearms.Modules;

namespace CustomItemsAPI.Overrides;

/// <summary>
/// Override class for <see cref="A7BurnEffectModule"/>.
/// </summary>
public class A7BurnEffectModuleOverride : IOverride<A7BurnEffectModule>
{
    /// <summary>
    /// Max duration for the Burned effect.
    /// </summary>
    public MathValueInt MaxDuration = new();

    /// <summary>
    /// Per shot duration.
    /// </summary>
    public MathValueInt PerShotDuration = new();

    /// <summary>
    /// Forward offset for checking the range.
    /// </summary>
    public MathValueFloat ForwardOffset = new();

    /// <summary>
    /// Radius for checking the hit range.
    /// </summary>
    public MathValueFloat Radius = new();

    /// <inheritdoc/>
    public Type OverrideType => typeof(A7BurnEffectModule);


    /// <inheritdoc/>
    public void Apply(ref A7BurnEffectModule burnEffectModule)
    {
        MaxDuration.MathCalculation(ref burnEffectModule._maxDuration);
        PerShotDuration.MathCalculation(ref burnEffectModule._perShotDuration);
        ForwardOffset.MathCalculation(ref burnEffectModule._forwardOffset);
        Radius.MathCalculation(ref burnEffectModule._radius);
    }

    /// <inheritdoc/>
    public void Apply(ref object classToOverride)
    {
        if (classToOverride is not A7BurnEffectModule)
            return;
        A7BurnEffectModule overrides = (A7BurnEffectModule)classToOverride;
        Apply(ref overrides);
    }
}
