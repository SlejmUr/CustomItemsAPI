using CustomItemsAPI.Helpers;
using InventorySystem.Items.ThrowableProjectiles;
using LabApi.Features.Wrappers;
using PSettings = InventorySystem.Items.ThrowableProjectiles.ThrowableItem.ProjectileSettings;

namespace CustomItemsAPI.Items;

public abstract class CustomThrowableBase : CustomItemBase
{

    public virtual void OnThrowingProjectile(Player player, LabApi.Features.Wrappers.ThrowableItem throwableItem, TypeWrapper<PSettings> settings, TypeWrapper<bool> isFullForce, TypeWrapper<bool> isAllowed)
    {

    }

    public virtual void OnThrewProjectile(Player player, LabApi.Features.Wrappers.ThrowableItem throwableItem, PSettings settings, bool fullForce)
    {

    }

    public virtual void OnProjectileSpawned(ThrownProjectile projectile)
    {

    }
}
