using CustomItemsAPI.Helpers;
using CustomItemsAPI.Items;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.CustomHandlers;

namespace CustomItemsAPI.EventHandlers;

internal sealed class ArmorHandler : CustomEventsHandler
{
    public override void OnPlayerPickingUpArmor(PlayerPickingUpArmorEventArgs ev)
    {
        TypeWrapper<bool> isAllowedHelper = new(ev.IsAllowed);
        var cur_item = CustomItems.GetCustomItem<CustomItemBase>(ev.BodyArmorPickup);
        cur_item?.OnPicking(ev.Player, ev.BodyArmorPickup, isAllowedHelper);
        ev.IsAllowed = isAllowedHelper.Value;
    }

    public override void OnPlayerPickedUpArmor(PlayerPickedUpArmorEventArgs ev)
    {
        var cur_item = CustomItems.GetCustomItem<CustomItemBase>(ev.BodyArmorItem);
        cur_item?.OnPicked(ev.Player, ev.BodyArmorItem);
    }

    public override void OnPlayerSearchingArmor(PlayerSearchingArmorEventArgs ev)
    {
        TypeWrapper<bool> isAllowedHelper = new(ev.IsAllowed);
        var cur_item = CustomItems.GetCustomItem<CustomItemBase>(ev.BodyArmorPickup);
        cur_item?.OnSearching(ev.Player, ev.BodyArmorPickup, isAllowedHelper);
        ev.IsAllowed = isAllowedHelper.Value;
    }

    public override void OnPlayerSearchedArmor(PlayerSearchedArmorEventArgs ev)
    {
        var cur_item = CustomItems.GetCustomItem<CustomItemBase>(ev.BodyArmorPickup);
        cur_item?.OnSearched(ev.Player);
    }
}
