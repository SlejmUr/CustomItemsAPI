using CustomItemsAPI.Helpers;
using CustomItemsAPI.Items;
using LabApi.Events.Arguments.Scp914Events;
using LabApi.Events.CustomHandlers;

namespace CustomItemsAPI.EventHandlers;

internal sealed class Scp914Handler : CustomEventsHandler
{
    public override void OnScp914ProcessingInventoryItem(Scp914ProcessingInventoryItemEventArgs ev)
    {
        TypeWrapper<bool> isAllowed = new(ev.IsAllowed);
        var cur_item = CustomItems.GetCustomItem<CustomItemBase>(ev.Item);
        cur_item?.OnProcessingItem(ev.Player, ev.Item, ev.KnobSetting, isAllowed);
    }

    public override void OnScp914ProcessingPickup(Scp914ProcessingPickupEventArgs ev)
    {
        TypeWrapper<bool> isAllowed = new(ev.IsAllowed);
        var cur_item = CustomItems.GetCustomItem<CustomItemBase>(ev.Pickup);
        cur_item?.OnProcessingPickup(ev.Pickup, ev.KnobSetting, isAllowed);
    }
}
