using LabApi.Features.Wrappers;
using PSettings = InventorySystem.Items.ThrowableProjectiles.ThrowableItem.ProjectileSettings;

namespace CustomItemsAPI.Items;

/// <summary>
/// Custom <see cref="ThrowableItem"/> base.
/// </summary>
public abstract class CustomThrowableBase : CustomItemBase
{
    /// <summary>
    /// This <paramref name="player"/> who threw this projectile.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="throwableItem">The Custom Throwable Item</param>
    /// <param name="projectile">The new projectile object created.</param>
    /// <param name="settings">The projectile Settings</param>
    /// <param name="fullForce">Is used full force to throw</param>
    public virtual void OnThrewProjectile(Player player, ThrowableItem throwableItem, Projectile projectile, PSettings settings, bool fullForce)
    {
        CL.Debug($"OnThrewProjectile {player.PlayerId} {throwableItem.Serial} {projectile.Serial} {settings} {fullForce}", Main.Instance.Config.Debug);
    }

    /// <summary>
    /// This <paramref name="player"/> who throwing this projectile.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="throwableItem">The Custom Throwable Item</param>
    /// <param name="settings">The projectile Settings</param>
    /// <param name="isFullForce">Is using full force to throw</param>
    /// <param name="isAllowed">Can allow this action.</param>
    public virtual void OnThrowingProjectile(Player player, ThrowableItem throwableItem, TypeWrapper<PSettings> settings, TypeWrapper<bool> isFullForce, TypeWrapper<bool> isAllowed)
    {
        CL.Debug($"OnThrowingProjectile {player.PlayerId} {throwableItem.Serial} {settings.Value} {isFullForce.Value}", Main.Instance.Config.Debug);
    }

    /// <summary>
    /// Called when a new <paramref name="projectile"/> spawned.
    /// </summary>
    /// <param name="projectile"></param>
    public virtual void OnProjectileSpawned(Projectile projectile)
    {
        CL.Debug($"OnProjectileSpawned {projectile}", Main.Instance.Config.Debug);
    }
}
