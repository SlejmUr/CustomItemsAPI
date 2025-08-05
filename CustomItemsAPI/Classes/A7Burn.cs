using InventorySystem.Items.Firearms.Modules;
using LabApiExtensions.Configs;
using LabApiExtensions.Managers;

namespace CustomItemsAPI.Classes;

/// <summary>
/// Helper for <see cref="A7BurnEffectModule"/>.
/// </summary>
public class A7Burn
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

    /// <summary>
    /// Apply values to <paramref name="burnEffectModule"/>.
    /// </summary>
    /// <param name="burnEffectModule"></param>
    public void Apply(ref A7BurnEffectModule burnEffectModule)
    {
        MaxDuration.MathCalculation(ref burnEffectModule._maxDuration);
        PerShotDuration.MathCalculation(ref burnEffectModule._perShotDuration);
        ForwardOffset.MathCalculation(ref burnEffectModule._forwardOffset);
        Radius.MathCalculation(ref burnEffectModule._radius);
    }
}
