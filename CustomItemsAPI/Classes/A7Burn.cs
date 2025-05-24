using CustomItemsAPI.Helpers;
using InventorySystem.Items.Firearms.Modules;

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
        MaxDuration.MathWithValue(ref burnEffectModule._maxDuration);
        PerShotDuration.MathWithValue(ref burnEffectModule._perShotDuration);
        ForwardOffset.MathWithValue(ref burnEffectModule._forwardOffset);
        Radius.MathWithValue(ref burnEffectModule._radius);
    }
}
