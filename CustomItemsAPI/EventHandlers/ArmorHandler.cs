using CustomItemsAPI.Helpers;
using CustomItemsAPI.Items;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.CustomHandlers;

namespace CustomItemsAPI.EventHandlers;

internal sealed class ArmorHandler : CustomEventsHandler
{
    public override void OnPlayerPickingUpArmor(PlayerPickingUpArmorEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.BodyArmorPickup, out CustomItemBase cur_item))
            return;
        TypeWrapper<bool> isAllowedHelper = new(ev.IsAllowed);
        cur_item.OnPicking(ev.Player, ev.BodyArmorPickup, isAllowedHelper);
        ev.IsAllowed = isAllowedHelper.Value;
    }

    public override void OnPlayerPickedUpArmor(PlayerPickedUpArmorEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.BodyArmorItem, out CustomItemBase cur_item))
            return;
        cur_item.OnPicked(ev.Player, ev.BodyArmorItem);
    }

    public override void OnPlayerSearchingArmor(PlayerSearchingArmorEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.BodyArmorPickup, out CustomItemBase cur_item))
            return;
        TypeWrapper<bool> isAllowedHelper = new(ev.IsAllowed);
        cur_item.OnSearching(ev.Player, ev.BodyArmorPickup, isAllowedHelper);
        ev.IsAllowed = isAllowedHelper.Value;
    }

    public override void OnPlayerSearchedArmor(PlayerSearchedArmorEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.BodyArmorPickup, out CustomItemBase cur_item))
            return;
        cur_item.OnSearched(ev.Player, ev.BodyArmorPickup);
    }
}
