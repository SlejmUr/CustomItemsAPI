﻿using CustomItemsAPI.Helpers;
using CustomItemsAPI.Items;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.CustomHandlers;
using LabApi.Features.Wrappers;

namespace CustomItemsAPI.EventHandlers;

internal sealed class UsableItemHandler : CustomEventsHandler
{
    #region Cancel
    public override void OnPlayerCancellingUsingItem(PlayerCancellingUsingItemEventArgs ev)
    {
        TypeWrapper<bool> isAllowed = new(ev.IsAllowed);
        var cur_item = CustomItems.GetCustomItem<CustomUsableBase>(Item.Get(ev.Item));
        cur_item?.OnCancelling(ev.Player, isAllowed);
        ev.IsAllowed = isAllowed.Value;
    }
    public override void OnPlayerCancelledUsingItem(PlayerCancelledUsingItemEventArgs ev)
    {
        var cur_item = CustomItems.GetCustomItem<CustomUsableBase>(Item.Get(ev.Item));
        cur_item?.OnCancelled(ev.Player);
    }
    #endregion
    #region Use
    public override void OnPlayerUsingItem(PlayerUsingItemEventArgs ev)
    {
        TypeWrapper<bool> isAllowed = new(ev.IsAllowed);
        var cur_item = CustomItems.GetCustomItem<CustomUsableBase>(ev.Item);
        cur_item?.OnUsing(ev.Player, isAllowed);
        ev.IsAllowed = isAllowed.Value;
    }
    public override void OnPlayerUsedItem(PlayerUsedItemEventArgs ev)
    {
        var cur_item = CustomItems.GetCustomItem<CustomUsableBase>(ev.Item);
        cur_item?.OnUsed(ev.Player);
    }
    #endregion
}
