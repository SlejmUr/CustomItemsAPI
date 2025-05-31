using CustomItemsAPI.Helpers;
using CustomItemsAPI.Items;
using LabApi.Events.Arguments.Scp914Events;
using LabApi.Events.CustomHandlers;
using Scp914;
using UnityEngine;

namespace CustomItemsAPI.EventHandlers;

internal sealed class Scp914Handler : CustomEventsHandler
{
    public override void OnScp914ProcessingInventoryItem(Scp914ProcessingInventoryItemEventArgs ev)
    {
        TypeWrapper<bool> isAllowed = new(ev.IsAllowed);
        TypeWrapper<Scp914KnobSetting> KnobSetting = new(ev.KnobSetting);
        var cur_item = CustomItems.GetCustomItem<CustomItemBase>(ev.Item);
        cur_item?.OnProcessingItem(ev.Player, ev.Item, KnobSetting, isAllowed);
        ev.IsAllowed = isAllowed.Value;
        ev.KnobSetting = KnobSetting.Value;
    }

    public override void OnScp914ProcessingPickup(Scp914ProcessingPickupEventArgs ev)
    {
        TypeWrapper<bool> isAllowed = new(ev.IsAllowed);
        TypeWrapper<Scp914KnobSetting> KnobSetting = new(ev.KnobSetting);
        TypeWrapper<Vector3> NewPosition = new(ev.NewPosition);
        var cur_item = CustomItems.GetCustomItem<CustomItemBase>(ev.Pickup);
        cur_item?.OnProcessingPickup(ev.Pickup, KnobSetting, isAllowed, NewPosition);
        ev.IsAllowed = isAllowed.Value;
        ev.KnobSetting = KnobSetting.Value;
        ev.NewPosition = NewPosition.Value;
    }
}
