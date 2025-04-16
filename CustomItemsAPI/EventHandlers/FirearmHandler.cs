using CustomItemsAPI.Helpers;
using CustomItemsAPI.Items;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.CustomHandlers;
using LabApi.Features.Wrappers;

namespace CustomItemsAPI.EventHandlers;

internal sealed class FirearmHandler : CustomEventsHandler
{
    #region DryFire
    public override void OnPlayerDryFiringWeapon(PlayerDryFiringWeaponEventArgs ev)
    {
        TypeWrapper<bool> isAllowedHelper = new(ev.IsAllowed);
        var cur_item = CustomItems.GetCustomItem<CustomFirearmBase>(ev.Weapon);
        cur_item?.OnDryFiring(ev.Player, (FirearmItem)ev.Weapon, isAllowedHelper);
        ev.IsAllowed = isAllowedHelper.Value;
    }
    public override void OnPlayerDryFiredWeapon(PlayerDryFiredWeaponEventArgs ev)
    {
        var cur_item = CustomItems.GetCustomItem<CustomFirearmBase>(ev.Weapon);
        cur_item?.OnDryFired(ev.Player, (FirearmItem)ev.Weapon);
    }
    #endregion
    #region Aim
    public override void OnPlayerAimedWeapon(PlayerAimedWeaponEventArgs ev)
    {
        var cur_item = CustomItems.GetCustomItem<CustomFirearmBase>(ev.Weapon);
        cur_item?.OnAim(ev.Player, (FirearmItem)ev.Weapon, ev.Aiming);
    }
    #endregion
    #region Reload
    public override void OnPlayerReloadingWeapon(PlayerReloadingWeaponEventArgs ev)
    {
        TypeWrapper<bool> isAllowedHelper = new(ev.IsAllowed);
        var cur_item = CustomItems.GetCustomItem<CustomFirearmBase>(ev.Weapon);
        cur_item?.OnReloading(ev.Player, (FirearmItem)ev.Weapon, isAllowedHelper);
        ev.IsAllowed = isAllowedHelper.Value;
    }
    public override void OnPlayerReloadedWeapon(PlayerReloadedWeaponEventArgs ev)
    {
        var cur_item = CustomItems.GetCustomItem<CustomFirearmBase>(ev.Weapon);
        cur_item?.OnReloaded(ev.Player, (FirearmItem)ev.Weapon);
    }
    #endregion
    #region Shoot
    public override void OnPlayerShootingWeapon(PlayerShootingWeaponEventArgs ev)
    {
        TypeWrapper<bool> isAllowedHelper = new(ev.IsAllowed);
        var cur_item = CustomItems.GetCustomItem<CustomFirearmBase>(ev.Weapon);
        cur_item?.OnShooting(ev.Player, (FirearmItem)ev.Weapon, isAllowedHelper);
        ev.IsAllowed = isAllowedHelper.Value;
    }
    public override void OnPlayerShotWeapon(PlayerShotWeaponEventArgs ev)
    {
        var cur_item = CustomItems.GetCustomItem<CustomFirearmBase>(ev.Weapon);
        cur_item?.OnShot(ev.Player, (FirearmItem)ev.Weapon);
    }
    #endregion
    #region Unload
    public override void OnPlayerUnloadingWeapon(PlayerUnloadingWeaponEventArgs ev)
    {
        TypeWrapper<bool> isAllowedHelper = new(ev.IsAllowed);
        var cur_item = CustomItems.GetCustomItem<CustomFirearmBase>(ev.Weapon);
        cur_item?.OnUnloading(ev.Player, (FirearmItem)ev.Weapon, isAllowedHelper);
        ev.IsAllowed = isAllowedHelper.Value;
    }
    public override void OnPlayerUnloadedWeapon(PlayerUnloadedWeaponEventArgs ev)
    {
        var cur_item = CustomItems.GetCustomItem<CustomFirearmBase>(ev.Weapon);
        cur_item?.OnUnloaded(ev.Player, (FirearmItem)ev.Weapon);
    }
    #endregion
    #region Toggle Flashlight
    public override void OnPlayerTogglingWeaponFlashlight(PlayerTogglingWeaponFlashlightEventArgs ev)
    {
        TypeWrapper<bool> isAllowedHelper = new(ev.IsAllowed);
        TypeWrapper<bool> newState = new(ev.NewState);
        var cur_item = CustomItems.GetCustomItem<CustomFirearmBase>(ev.Item);
        cur_item?.OnTogglingFlashlight(ev.Player, (FirearmItem)ev.Item, newState, isAllowedHelper);
        ev.IsAllowed = isAllowedHelper.Value;
        ev.NewState = newState.Value;
    }
    public override void OnPlayerToggledWeaponFlashlight(PlayerToggledWeaponFlashlightEventArgs ev)
    {
        var cur_item = CustomItems.GetCustomItem<CustomFirearmBase>(ev.Item);
        cur_item?.OnToggledFlashlight(ev.Player, (FirearmItem)ev.Item, ev.NewState);
    }
    #endregion
}
