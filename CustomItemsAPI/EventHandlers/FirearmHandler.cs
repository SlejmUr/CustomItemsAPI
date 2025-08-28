using CustomItemsAPI.Items;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.CustomHandlers;

namespace CustomItemsAPI.EventHandlers;

internal sealed class FirearmHandler : CustomEventsHandler
{
    #region DryFire
    public override void OnPlayerDryFiringWeapon(PlayerDryFiringWeaponEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.FirearmItem, out CustomFirearmBase cur_item))
            return;
        TypeWrapper<bool> isAllowedHelper = new(ev.IsAllowed);
        cur_item.OnDryFiring(ev.Player, ev.FirearmItem, isAllowedHelper);
        ev.IsAllowed = isAllowedHelper.Value;
    }
    public override void OnPlayerDryFiredWeapon(PlayerDryFiredWeaponEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.FirearmItem, out CustomFirearmBase cur_item))
            return;
        cur_item.OnDryFired(ev.Player, ev.FirearmItem);
    }
    #endregion
    #region Aim
    public override void OnPlayerAimedWeapon(PlayerAimedWeaponEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.FirearmItem, out CustomFirearmBase cur_item))
            return;
        cur_item.OnAim(ev.Player, ev.FirearmItem, ev.Aiming);
    }
    #endregion
    #region Reload
    public override void OnPlayerReloadingWeapon(PlayerReloadingWeaponEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.FirearmItem, out CustomFirearmBase cur_item))
            return;
        TypeWrapper<bool> isAllowedHelper = new(ev.IsAllowed);
        cur_item.OnReloading(ev.Player, ev.FirearmItem, isAllowedHelper);
        ev.IsAllowed = isAllowedHelper.Value;
    }
    public override void OnPlayerReloadedWeapon(PlayerReloadedWeaponEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.FirearmItem, out CustomFirearmBase cur_item))
            return;
        cur_item.OnReloaded(ev.Player, ev.FirearmItem);
    }
    #endregion
    #region Shoot
    public override void OnPlayerShootingWeapon(PlayerShootingWeaponEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.FirearmItem, out CustomFirearmBase cur_item))
            return;
        TypeWrapper<bool> isAllowedHelper = new(ev.IsAllowed);
        cur_item.OnShooting(ev.Player, ev.FirearmItem, isAllowedHelper);
        ev.IsAllowed = isAllowedHelper.Value;
    }
    public override void OnPlayerShotWeapon(PlayerShotWeaponEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.FirearmItem, out CustomFirearmBase cur_item))
            return;
        cur_item.OnShot(ev.Player, ev.FirearmItem);
    }
    #endregion
    #region Unload
    public override void OnPlayerUnloadingWeapon(PlayerUnloadingWeaponEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.FirearmItem, out CustomFirearmBase cur_item))
            return;
        TypeWrapper<bool> isAllowedHelper = new(ev.IsAllowed);
        cur_item.OnUnloading(ev.Player, ev.FirearmItem, isAllowedHelper);
        ev.IsAllowed = isAllowedHelper.Value;
    }
    public override void OnPlayerUnloadedWeapon(PlayerUnloadedWeaponEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.FirearmItem, out CustomFirearmBase cur_item))
            return;
        cur_item.OnUnloaded(ev.Player, ev.FirearmItem);
    }
    #endregion
    #region Toggle Flashlight
    public override void OnPlayerTogglingWeaponFlashlight(PlayerTogglingWeaponFlashlightEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.FirearmItem, out CustomFirearmBase cur_item))
            return;
        TypeWrapper<bool> isAllowedHelper = new(ev.IsAllowed);
        TypeWrapper<bool> newState = new(ev.NewState);
        cur_item.OnTogglingFlashlight(ev.Player, ev.FirearmItem, newState, isAllowedHelper);
        ev.IsAllowed = isAllowedHelper.Value;
        ev.NewState = newState.Value;
    }
    public override void OnPlayerToggledWeaponFlashlight(PlayerToggledWeaponFlashlightEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.FirearmItem, out CustomFirearmBase cur_item))
            return;
        cur_item.OnToggledFlashlight(ev.Player, ev.FirearmItem, ev.NewState);
    }
    #endregion
    #region Attachments
    public override void OnPlayerChangingAttachments(PlayerChangingAttachmentsEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.FirearmItem, out CustomFirearmBase cur_item))
            return;
        TypeWrapper<bool> isAllowedHelper = new(ev.IsAllowed);
        TypeWrapper<uint> newState = new(ev.NewAttachments);
        cur_item.OnChangingAttachments(ev.Player, ev.FirearmItem, ev.OldAttachments, newState, isAllowedHelper);
        ev.IsAllowed = isAllowedHelper.Value;
        ev.NewAttachments = newState.Value;
    }

    public override void OnPlayerChangedAttachments(PlayerChangedAttachmentsEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.FirearmItem, out CustomFirearmBase cur_item))
            return;
        cur_item.OnChangedAttachments(ev.Player, ev.FirearmItem, ev.OldAttachments, ev.NewAttachments);
    }
    #endregion
}
