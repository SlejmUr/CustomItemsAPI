using CustomItemsAPI.Helpers;
using CustomItemsAPI.Items;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.CustomHandlers;
using LabApi.Features.Wrappers;

namespace CustomItemsAPI.EventHandlers;

internal sealed class KeyCardItemHandler : CustomEventsHandler
{
    #region Interact Door
    public override void OnPlayerInteractingDoor(PlayerInteractingDoorEventArgs ev)
    {
        Item? item = ev.Player.CurrentItem;
        if (item == null)
            return;
        if (!CustomItems.TryGetCustomItem(item, out CustomKeyCardBase customKeyCardBase))
            return;
        TypeWrapper<bool> isAllowedHelper = new(ev.IsAllowed);
        TypeWrapper<bool> canOpenHelper = new(ev.CanOpen);
        customKeyCardBase.OnInteractingDoor(ev.Player, item, ev.Door, canOpenHelper, isAllowedHelper);
        ev.IsAllowed = isAllowedHelper.Value;
        ev.CanOpen = canOpenHelper.Value;
    }

    public override void OnPlayerInteractedDoor(PlayerInteractedDoorEventArgs ev)
    {
        Item? item = ev.Player.CurrentItem;
        if (item == null)
            return;
        if (!CustomItems.TryGetCustomItem(item, out CustomKeyCardBase customKeyCardBase))
            return;
        customKeyCardBase.OnInteractedDoor(ev.Player, item, ev.Door, ev.CanOpen);
    }
    #endregion
    #region Interact Generator
    public override void OnPlayerInteractingGenerator(PlayerInteractingGeneratorEventArgs ev)
    {
        Item? item = ev.Player.CurrentItem;
        if (item == null)
            return;
        if (!CustomItems.TryGetCustomItem(item, out CustomKeyCardBase customKeyCardBase))
            return;
        TypeWrapper<bool> isAllowedHelper = new(ev.IsAllowed);
        customKeyCardBase.OnInteractingGenerator(ev.Player, item, ev.Generator, isAllowedHelper);
        ev.IsAllowed = isAllowedHelper.Value;
    }

    public override void OnPlayerInteractedGenerator(PlayerInteractedGeneratorEventArgs ev)
    {
        Item? item = ev.Player.CurrentItem;
        if (item == null)
            return;
        if (!CustomItems.TryGetCustomItem(item, out CustomKeyCardBase customKeyCardBase))
            return;
        customKeyCardBase.OnInteractedGenerator(ev.Player, item, ev.Generator);
    }
    #endregion
    #region Interact Locker
    public override void OnPlayerInteractingLocker(PlayerInteractingLockerEventArgs ev)
    {
        Item? item = ev.Player.CurrentItem;
        if (item == null)
            return;
        if (!CustomItems.TryGetCustomItem(item, out CustomKeyCardBase customKeyCardBase))
            return;
        TypeWrapper<bool> isAllowedHelper = new(ev.IsAllowed);
        TypeWrapper<bool> canOpenHelper = new(ev.CanOpen);
        customKeyCardBase.OnInteractingLocker(ev.Player, item, ev.Locker, ev.Chamber, canOpenHelper, isAllowedHelper);
        ev.IsAllowed = isAllowedHelper.Value;
        ev.CanOpen = canOpenHelper.Value;
    }

    public override void OnPlayerInteractedLocker(PlayerInteractedLockerEventArgs ev)
    {
        Item? item = ev.Player.CurrentItem;
        if (item == null)
            return;
        if (!CustomItems.TryGetCustomItem(item, out CustomKeyCardBase customKeyCardBase))
            return;
        customKeyCardBase?.OnInteractedLocker(ev.Player, item, ev.Locker, ev.Chamber, ev.CanOpen);
    }
    #endregion
    #region Inspect Keycard
    public override void OnPlayerInspectingKeycard(PlayerInspectingKeycardEventArgs ev)
    {
        TypeWrapper<bool> isAllowedHelper = new(ev.IsAllowed);
        var cur_item = CustomItems.GetCustomItem<CustomKeyCardBase>(ev.KeycardItem);
        cur_item?.OnInspectingKeycard(ev.Player, ev.KeycardItem, isAllowedHelper);
        ev.IsAllowed = isAllowedHelper.Value;
    }

    public override void OnPlayerInspectedKeycard(PlayerInspectedKeycardEventArgs ev)
    {
        var cur_item = CustomItems.GetCustomItem<CustomKeyCardBase>(ev.KeycardItem);
        cur_item?.OnInspectedKeycard(ev.Player, ev.KeycardItem);
    }
    #endregion
}
