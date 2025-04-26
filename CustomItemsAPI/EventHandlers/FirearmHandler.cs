using CustomItemsAPI.Helpers;
using CustomItemsAPI.Items;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.CustomHandlers;

namespace CustomItemsAPI.EventHandlers;

internal sealed class FirearmHandler : CustomEventsHandler
{
    #region DryFire
    public override void OnPlayerDryFiringWeapon(PlayerDryFiringWeaponEventArgs ev)
    {
        TypeWrapper<bool> isAllowedHelper = new(ev.IsAllowed);
        var cur_item = CustomItems.GetCustomItem<CustomFirearmBase>(ev.FirearmItem);
        cur_item?.OnDryFiring(ev.Player, ev.FirearmItem, isAllowedHelper);
        ev.IsAllowed = isAllowedHelper.Value;
    }
    public override void OnPlayerDryFiredWeapon(PlayerDryFiredWeaponEventArgs ev)
    {
        var cur_item = CustomItems.GetCustomItem<CustomFirearmBase>(ev.FirearmItem);
        cur_item?.OnDryFired(ev.Player, ev.FirearmItem);
    }
    #endregion
    #region Aim
    public override void OnPlayerAimedWeapon(PlayerAimedWeaponEventArgs ev)
    {
        var cur_item = CustomItems.GetCustomItem<CustomFirearmBase>(ev.FirearmItem);
        cur_item?.OnAim(ev.Player, ev.FirearmItem, ev.Aiming);
    }
    #endregion
    #region Reload
    public override void OnPlayerReloadingWeapon(PlayerReloadingWeaponEventArgs ev)
    {
        TypeWrapper<bool> isAllowedHelper = new(ev.IsAllowed);
        var cur_item = CustomItems.GetCustomItem<CustomFirearmBase>(ev.FirearmItem);
        cur_item?.OnReloading(ev.Player, ev.FirearmItem, isAllowedHelper);
        ev.IsAllowed = isAllowedHelper.Value;
    }
    public override void OnPlayerReloadedWeapon(PlayerReloadedWeaponEventArgs ev)
    {
        var cur_item = CustomItems.GetCustomItem<CustomFirearmBase>(ev.FirearmItem);
        cur_item?.OnReloaded(ev.Player, ev.FirearmItem);
    }
    #endregion
    #region Shoot
    public override void OnPlayerShootingWeapon(PlayerShootingWeaponEventArgs ev)
    {
        TypeWrapper<bool> isAllowedHelper = new(ev.IsAllowed);
        var cur_item = CustomItems.GetCustomItem<CustomFirearmBase>(ev.FirearmItem);
        cur_item?.OnShooting(ev.Player, ev.FirearmItem, isAllowedHelper);
        ev.IsAllowed = isAllowedHelper.Value;
    }
    public override void OnPlayerShotWeapon(PlayerShotWeaponEventArgs ev)
    {
        var cur_item = CustomItems.GetCustomItem<CustomFirearmBase>(ev.FirearmItem);
        cur_item?.OnShot(ev.Player, ev.FirearmItem);
    }
    #endregion
    #region Unload
    public override void OnPlayerUnloadingWeapon(PlayerUnloadingWeaponEventArgs ev)
    {
        TypeWrapper<bool> isAllowedHelper = new(ev.IsAllowed);
        var cur_item = CustomItems.GetCustomItem<CustomFirearmBase>(ev.FirearmItem);
        cur_item?.OnUnloading(ev.Player, ev.FirearmItem, isAllowedHelper);
        ev.IsAllowed = isAllowedHelper.Value;
    }
    public override void OnPlayerUnloadedWeapon(PlayerUnloadedWeaponEventArgs ev)
    {
        var cur_item = CustomItems.GetCustomItem<CustomFirearmBase>(ev.FirearmItem);
        cur_item?.OnUnloaded(ev.Player, ev.FirearmItem);
    }
    #endregion
    #region Toggle Flashlight
    public override void OnPlayerTogglingWeaponFlashlight(PlayerTogglingWeaponFlashlightEventArgs ev)
    {
        TypeWrapper<bool> isAllowedHelper = new(ev.IsAllowed);
        TypeWrapper<bool> newState = new(ev.NewState);
        var cur_item = CustomItems.GetCustomItem<CustomFirearmBase>(ev.FirearmItem);
        cur_item?.OnTogglingFlashlight(ev.Player, ev.FirearmItem, newState, isAllowedHelper);
        ev.IsAllowed = isAllowedHelper.Value;
        ev.NewState = newState.Value;
    }
    public override void OnPlayerToggledWeaponFlashlight(PlayerToggledWeaponFlashlightEventArgs ev)
    {
        var cur_item = CustomItems.GetCustomItem<CustomFirearmBase>(ev.FirearmItem);
        cur_item?.OnToggledFlashlight(ev.Player, ev.FirearmItem, ev.NewState);
    }
    #endregion
}
