using CustomItemsAPI.Helpers;
using InventorySystem.Items.ThrowableProjectiles;
using LabApi.Features.Wrappers;
using PSettings = InventorySystem.Items.ThrowableProjectiles.ThrowableItem.ProjectileSettings;

namespace CustomItemsAPI.Items;

/// <summary>
/// Custom <see cref="LabApi.Features.Wrappers.ThrowableItem"/> base.
/// </summary>
public abstract class CustomThrowableBase : CustomItemBase
{
    /// <summary>
    /// This <paramref name="player"/> who throwing this projectile.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="throwableItem">The Custom Throwable Item</param>
    /// <param name="settings">The projectile Settings</param>
    /// <param name="isFullForce">Is using full force to throw</param>
    /// <param name="isAllowed">Can allow this action.</param>
    public virtual void OnThrowingProjectile(Player player, LabApi.Features.Wrappers.ThrowableItem throwableItem, TypeWrapper<PSettings> settings, TypeWrapper<bool> isFullForce, TypeWrapper<bool> isAllowed)
    {

    }

    /// <summary>
    /// This <paramref name="player"/> who threw this projectile.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="throwableItem">The Custom Throwable Item</param>
    /// <param name="settings">The projectile Settings</param>
    /// <param name="fullForce">Is used full force to throw</param>
    public virtual void OnThrewProjectile(Player player, LabApi.Features.Wrappers.ThrowableItem throwableItem, PSettings settings, bool fullForce)
    {

    }

    /// <summary>
    /// Called when a new <paramref name="projectile"/> spawned.
    /// </summary>
    /// <param name="projectile"></param>
    public virtual void OnProjectileSpawned(ThrownProjectile projectile)
    {

    }
}
