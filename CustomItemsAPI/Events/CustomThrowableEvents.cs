using CustomItemsAPI.Items;
using LabApi.Features.Wrappers;
using PSettings = InventorySystem.Items.ThrowableProjectiles.ThrowableItem.ProjectileSettings;

namespace CustomItemsAPI.Events;

public static class CustomThrowableEvents
{
    public static event Action<CustomThrowableBase, Player, ThrowableItem, Projectile, PSettings, bool>? ThrewProjectile;
    public static event Action<CustomThrowableBase, Player, ThrowableItem, TypeWrapper<PSettings>, TypeWrapper<bool>, TypeWrapper<bool>>? ThrowingProjectile;
    public static event Action<CustomThrowableBase, Projectile>? ProjectileSpawned;

    public static void OnThrewProjectile(CustomThrowableBase custom, Player player, ThrowableItem throwableItem, Projectile projectile, PSettings settings, bool fullForce)
        => ThrewProjectile?.Invoke(custom, player, throwableItem, projectile, settings, fullForce);

    public static void OnThrowingProjectile(CustomThrowableBase custom, Player player, ThrowableItem throwableItem, TypeWrapper<PSettings> settings, TypeWrapper<bool> isFullForce, TypeWrapper<bool> isAllowed)
        => ThrowingProjectile?.Invoke(custom, player, throwableItem, settings, isFullForce ,isAllowed);

    public static void OnProjectileSpawned(CustomThrowableBase cur_item, Projectile labProjectile)
        => ProjectileSpawned?.Invoke(cur_item, labProjectile);
}
