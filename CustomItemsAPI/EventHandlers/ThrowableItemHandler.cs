using CustomItemsAPI.Helpers;
using CustomItemsAPI.Items;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.CustomHandlers;

namespace CustomItemsAPI.EventHandlers;

internal class ThrowableItemHandler : CustomEventsHandler
{
    public override void OnPlayerThrowingProjectile(PlayerThrowingProjectileEventArgs ev)
    {
        TypeWrapper<bool> isAllowed = new(ev.IsAllowed);
        TypeWrapper<bool> fullForce = new(ev.FullForce);
        TypeWrapper<InventorySystem.Items.ThrowableProjectiles.ThrowableItem.ProjectileSettings> settings = new(ev.ProjectileSettings);
        var cur_item = CustomItems.GetCustomItem<CustomThrowableBase>(ev.ThrowableItem);
        cur_item?.OnThrowingProjectile(ev.Player, ev.ThrowableItem, settings, fullForce, isAllowed);
        ev.IsAllowed = isAllowed.Value;
        ev.FullForce = fullForce.Value;
        ev.ProjectileSettings = settings.Value;
    }

    public override void OnPlayerThrewProjectile(PlayerThrewProjectileEventArgs ev)
    {
        var cur_item = CustomItems.GetCustomItem<CustomThrowableBase>(ev.ThrowableItem);
        cur_item?.OnThrewProjectile(ev.Player, ev.ThrowableItem, ev.Projectile, ev.ProjectileSettings, ev.FullForce);
    }
}
