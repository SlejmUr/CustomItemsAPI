using CustomItemsAPI.Events;
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
        if (!CustomItems.TryGetCustomItem(ev.Item, out CustomItemBase cur_item))
            return;
        TypeWrapper<bool> isAllowed = new(ev.IsAllowed);
        TypeWrapper<Scp914KnobSetting> KnobSetting = new(ev.KnobSetting);
        CustomItemEvents.OnProcessingItem(cur_item, ev.Player, ev.Item, KnobSetting, isAllowed);
        cur_item.OnProcessingItem(ev.Player, ev.Item, KnobSetting, isAllowed);
        ev.IsAllowed = isAllowed.Value;
        ev.KnobSetting = KnobSetting.Value;
    }

    public override void OnScp914ProcessingPickup(Scp914ProcessingPickupEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.Pickup, out CustomItemBase cur_item))
            return;
        TypeWrapper<bool> isAllowed = new(ev.IsAllowed);
        TypeWrapper<Scp914KnobSetting> KnobSetting = new(ev.KnobSetting);
        TypeWrapper<Vector3> NewPosition = new(ev.NewPosition);
        CustomItemEvents.OnProcessingPickup(cur_item, ev.Pickup, KnobSetting, NewPosition, isAllowed);
        cur_item.OnProcessingPickup(ev.Pickup, KnobSetting, NewPosition, isAllowed);
        ev.IsAllowed = isAllowed.Value;
        ev.KnobSetting = KnobSetting.Value;
        ev.NewPosition = NewPosition.Value;
    }
}
