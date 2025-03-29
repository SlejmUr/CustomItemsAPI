using CustomItemsAPI.Helpers;
using CustomItemsAPI.Items;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.CustomHandlers;

namespace CustomItemsAPI.EventHandlers;

internal sealed class KeyCardItemHandler : CustomEventsHandler
{
    #region Interact Door
    public override void OnPlayerInteractingDoor(PlayerInteractingDoorEventArgs ev)
    {
        TypeWrapper<bool> isAllowedHelper = new(ev.IsAllowed);
        TypeWrapper<bool> canOpenHelper = new(ev.CanOpen);
        var cur_item = CustomItems.GetCustomItem<CustomKeyCardBase>(ev.Player);
        cur_item?.OnInteractingDoor(ev.Player, ev.Door, canOpenHelper, isAllowedHelper);
        ev.IsAllowed = isAllowedHelper.Value;
        ev.CanOpen = canOpenHelper.Value;
    }

    public override void OnPlayerInteractedDoor(PlayerInteractedDoorEventArgs ev)
    {
        var cur_item = CustomItems.GetCustomItem<CustomKeyCardBase>(ev.Player);
        cur_item?.OnInteractedDoor(ev.Player, ev.Door, ev.CanOpen);
    }
    #endregion
    #region Interact Generator
    public override void OnPlayerInteractingGenerator(PlayerInteractingGeneratorEventArgs ev)
    {
        TypeWrapper<bool> isAllowedHelper = new(ev.IsAllowed);
        var cur_item = CustomItems.GetCustomItem<CustomKeyCardBase>(ev.Player);
        cur_item?.OnInteractingGenerator(ev.Player, ev.Generator, isAllowedHelper);
    }

    public override void OnPlayerInteractedGenerator(PlayerInteractedGeneratorEventArgs ev)
    {
        var cur_item = CustomItems.GetCustomItem<CustomKeyCardBase>(ev.Player);
        cur_item?.OnInteractedGenerator(ev.Player, ev.Generator);
    }
    #endregion
    #region Interact Locker
    public override void OnPlayerInteractingLocker(PlayerInteractingLockerEventArgs ev)
    {
        TypeWrapper<bool> isAllowedHelper = new(ev.IsAllowed);
        TypeWrapper<bool> canOpenHelper = new(ev.CanOpen);
        var cur_item = CustomItems.GetCustomItem<CustomKeyCardBase>(ev.Player);
        cur_item?.OnInteractingLocker(ev.Player, ev.Locker, ev.Chamber, canOpenHelper, isAllowedHelper);
        ev.IsAllowed = isAllowedHelper.Value;
        ev.CanOpen = canOpenHelper.Value;
    }

    public override void OnPlayerInteractedLocker(PlayerInteractedLockerEventArgs ev)
    {
        var cur_item = CustomItems.GetCustomItem<CustomKeyCardBase>(ev.Player);
        cur_item?.OnInteractedLocker(ev.Player, ev.Locker, ev.Chamber, ev.CanOpen);
    }
    #endregion
}
