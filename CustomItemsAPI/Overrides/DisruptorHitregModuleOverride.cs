using InventorySystem.Items.Firearms.Modules;

namespace CustomItemsAPI.Overrides;

/// <summary>
/// Override class for <see cref="DisruptorHitregModule"/>
/// </summary>
public class DisruptorHitregModuleOverride : IOverride<DisruptorHitregModule>
{
    /// <summary>
    /// Changes <see cref="DisruptorHitregModule._singleShotBaseDamage"/>.
    /// </summary>
    public MathValueFloat SingleShotBaseDamage = new();

    /// <summary>
    /// Changes <see cref="DisruptorHitregModule._singleShotFalloffDistance"/>.
    /// </summary>
    public MathValueFloat SingleShotFalloffDistance = new();

    /// <summary>
    /// Changes <see cref="DisruptorHitregModule._singleShotDivisionPerTarget"/>.
    /// </summary>
    public MathValueFloat SingleShotDivisionPerTarget = new();

    /// <summary>
    /// Changes <see cref="DisruptorHitregModule._singleShotThickness"/>.
    /// </summary>
    public MathValueFloat SingleShotThickness = new();

    /// <summary>
    /// Changes <see cref="DisruptorHitregModule._singleShotExplosionSettings"/>.
    /// </summary>
    public ExplosionGrenadeOverride SingleShotExplosionSettings = new();

    /// <summary>
    /// Changes <see cref="DisruptorHitregModule._rapidFireBaseDamage"/>.
    /// </summary>
    public MathValueFloat RapidFireBaseDamage = new();

    /// <summary>
    /// Changes <see cref="DisruptorHitregModule._rapidFireFalloffDistance"/>.
    /// </summary>
    public MathValueFloat RapidFireFalloffDistance = new();

    /// <inheritdoc/>
    public Type OverrideType => typeof(DisruptorHitregModule);

    /// <inheritdoc/>
    public void Apply(ref DisruptorHitregModule disruptorHitregModule)
    {
        SingleShotBaseDamage.MathCalculation(ref disruptorHitregModule._singleShotBaseDamage);
        SingleShotFalloffDistance.MathCalculation(ref disruptorHitregModule._singleShotFalloffDistance);
        SingleShotDivisionPerTarget.MathCalculation(ref disruptorHitregModule._singleShotDivisionPerTarget);
        SingleShotThickness.MathCalculation(ref disruptorHitregModule._singleShotThickness);
        SingleShotExplosionSettings.Apply(ref disruptorHitregModule._singleShotExplosionSettings);
        RapidFireBaseDamage.MathCalculation(ref disruptorHitregModule._rapidFireBaseDamage);
        RapidFireFalloffDistance.MathCalculation(ref disruptorHitregModule._rapidFireFalloffDistance);
    }

    /// <inheritdoc/>
    public void Apply(ref object classToOverride)
    {
        if (classToOverride is not DisruptorHitregModule)
            return;
        DisruptorHitregModule overrides = (DisruptorHitregModule)classToOverride;
        Apply(ref overrides);
    }
}
