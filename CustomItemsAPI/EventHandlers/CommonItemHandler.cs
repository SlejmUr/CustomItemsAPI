using CustomItemsAPI.Helpers;
using CustomItemsAPI.Items;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.CustomHandlers;

namespace CustomItemsAPI.EventHandlers;

internal sealed class CommonItemHandler : CustomEventsHandler
{
    #region Change
    public override void OnPlayerChangingItem(PlayerChangingItemEventArgs ev)
    {
        TypeWrapper<bool> isAllowedHelper = new(ev.IsAllowed);
        if (CustomItems.TryGetCustomItem(ev.Item, out CustomItemBase prev_Item))
            prev_Item.OnChanging(ev.Player, ev.OldItem, ev.NewItem, false, isAllowedHelper);
        if (CustomItems.TryGetCustomItem(ev.Item, out CustomItemBase cur_item))
            cur_item.OnChanging(ev.Player, ev.OldItem, ev.NewItem, true, isAllowedHelper);
        ev.IsAllowed = isAllowedHelper.Value;
    }
    public override void OnPlayerChangedItem(PlayerChangedItemEventArgs ev)
    {
        if (CustomItems.TryGetCustomItem(ev.Item, out CustomItemBase prev_Item))
            prev_Item.OnChanged(ev.Player, ev.OldItem, ev.NewItem, false);
        if (CustomItems.TryGetCustomItem(ev.Item, out CustomItemBase cur_item))
            cur_item.OnChanged(ev.Player, ev.OldItem, ev.NewItem, true);
    }
    #endregion
    #region Drop
    public override void OnPlayerDroppingItem(PlayerDroppingItemEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.Item, out CustomItemBase cur_item))
            return;
        TypeWrapper<bool> isAllowedHelper = new(ev.IsAllowed);
        cur_item.OnDropping(ev.Player, ev.Item, isAllowedHelper);
        ev.IsAllowed = isAllowedHelper.Value;
    }
    public override void OnPlayerDroppedItem(PlayerDroppedItemEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.Pickup, out CustomItemBase cur_item))
            return;
        cur_item.OnDropped(ev.Player, ev.Pickup);
    }
    #endregion
    #region Pick
    public override void OnPlayerPickingUpItem(PlayerPickingUpItemEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.Pickup, out CustomItemBase cur_item))
            return;
        TypeWrapper<bool> isAllowedHelper = new(ev.IsAllowed);
        cur_item.OnPicking(ev.Player, ev.Pickup, isAllowedHelper);
        ev.IsAllowed = isAllowedHelper.Value;
    }
    public override void OnPlayerPickedUpItem(PlayerPickedUpItemEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.Item, out CustomItemBase cur_item))
            return;
        cur_item.OnPicked(ev.Player, ev.Item);
    }
    #endregion
    #region Throw
    public override void OnPlayerThrowingItem(PlayerThrowingItemEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.Pickup, out CustomItemBase cur_item))
            return;
        TypeWrapper<bool> isAllowedHelper = new(ev.IsAllowed);
        cur_item.OnThrowing(ev.Player, ev.Pickup, ev.Rigidbody, isAllowedHelper);
        ev.IsAllowed = isAllowedHelper.Value;
    }

    public override void OnPlayerThrewItem(PlayerThrewItemEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.Pickup, out CustomItemBase cur_item))
            return;
        cur_item.OnThrew(ev.Player, ev.Pickup, ev.Rigidbody);
    }
    #endregion
    public override void OnPlayerSearchingPickup(PlayerSearchingPickupEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.Pickup, out CustomItemBase cur_item))
            return;
        TypeWrapper<bool> isAllowedHelper = new(ev.IsAllowed);
        cur_item.OnSearching(ev.Player, ev.Pickup, isAllowedHelper);
        ev.IsAllowed = isAllowedHelper.Value;
    }
    public override void OnPlayerSearchedPickup(PlayerSearchedPickupEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.Pickup, out CustomItemBase cur_item))
            return;
        cur_item.OnSearched(ev.Player, ev.Pickup);
    }
}
