﻿using CustomItemsAPI.Helpers;
using CustomItemsAPI.Items;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.CustomHandlers;

namespace CustomItemsAPI.EventHandlers;

internal sealed class ThrowableItemHandler : CustomEventsHandler
{
    public override void OnPlayerThrowingProjectile(PlayerThrowingProjectileEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.ThrowableItem, out CustomThrowableBase cur_item))
            return;
        TypeWrapper<bool> isAllowed = new(ev.IsAllowed);
        TypeWrapper<bool> fullForce = new(ev.FullForce);
        TypeWrapper<InventorySystem.Items.ThrowableProjectiles.ThrowableItem.ProjectileSettings> settings = new(ev.ProjectileSettings);
        cur_item.OnThrowingProjectile(ev.Player, ev.ThrowableItem, settings, fullForce, isAllowed);
        ev.IsAllowed = isAllowed.Value;
        ev.FullForce = fullForce.Value;
        ev.ProjectileSettings = settings.Value;
    }

    public override void OnPlayerThrewProjectile(PlayerThrewProjectileEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.ThrowableItem, out CustomThrowableBase cur_item))
            return;
        cur_item.OnThrewProjectile(ev.Player, ev.ThrowableItem, ev.Projectile, ev.ProjectileSettings, ev.FullForce);
    }
}
