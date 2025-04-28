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
        var prev_Item = CustomItems.GetCustomItem<CustomItemBase>(ev.OldItem);
        var cur_item = CustomItems.GetCustomItem<CustomItemBase>(ev.NewItem);
        prev_Item?.OnChanging(ev.Player, ev.OldItem, ev.NewItem, false, isAllowedHelper);
        cur_item?.OnChanging(ev.Player, ev.OldItem, ev.NewItem, true, isAllowedHelper);
        ev.IsAllowed = isAllowedHelper.Value;
    }
    public override void OnPlayerChangedItem(PlayerChangedItemEventArgs ev)
    {
        var prev_Item = CustomItems.GetCustomItem<CustomItemBase>(ev.OldItem);
        var cur_item = CustomItems.GetCustomItem<CustomItemBase>(ev.NewItem);
        prev_Item?.OnChanged(ev.Player, ev.OldItem, ev.NewItem, false);
        cur_item?.OnChanged(ev.Player, ev.OldItem, ev.NewItem, true);
    }
    #endregion
    #region Drop
    public override void OnPlayerDroppingItem(PlayerDroppingItemEventArgs ev)
    {
        TypeWrapper<bool> isAllowedHelper = new(ev.IsAllowed);
        var cur_item = CustomItems.GetCustomItem<CustomItemBase>(ev.Item);
        cur_item?.OnDropping(ev.Player, ev.Item, isAllowedHelper);
        ev.IsAllowed = isAllowedHelper.Value;
    }
    public override void OnPlayerDroppedItem(PlayerDroppedItemEventArgs ev)
    {
        var cur_item = CustomItems.GetCustomItem<CustomItemBase>(ev.Pickup);
        cur_item?.OnDropped(ev.Player, ev.Pickup);
    }
    #endregion
    #region Pick
    public override void OnPlayerPickingUpItem(PlayerPickingUpItemEventArgs ev)
    {
        TypeWrapper<bool> isAllowedHelper = new(ev.IsAllowed);
        var cur_item = CustomItems.GetCustomItem<CustomItemBase>(ev.Pickup);
        cur_item?.OnPicking(ev.Player, ev.Pickup, isAllowedHelper);
        ev.IsAllowed = isAllowedHelper.Value;
    }
    public override void OnPlayerPickedUpItem(PlayerPickedUpItemEventArgs ev)
    {
        var cur_item = CustomItems.GetCustomItem<CustomItemBase>(ev.Item);
        cur_item?.OnPicked(ev.Player, ev.Item);
    }
    #endregion
    #region Throw
    public override void OnPlayerThrowingItem(PlayerThrowingItemEventArgs ev)
    {
        TypeWrapper<bool> isAllowedHelper = new(ev.IsAllowed);
        var cur_item = CustomItems.GetCustomItem<CustomItemBase>(ev.Pickup);
        cur_item?.OnThrowing(ev.Player, ev.Pickup, ev.Rigidbody, isAllowedHelper);
        ev.IsAllowed = isAllowedHelper.Value;
    }

    public override void OnPlayerThrewItem(PlayerThrewItemEventArgs ev)
    {
        var cur_item = CustomItems.GetCustomItem<CustomItemBase>(ev.Pickup);
        cur_item?.OnThrew(ev.Player, ev.Pickup, ev.Rigidbody);
    }
    #endregion
    public override void OnPlayerSearchingPickup(PlayerSearchingPickupEventArgs ev)
    {
        TypeWrapper<bool> isAllowedHelper = new(ev.IsAllowed);
        var cur_item = CustomItems.GetCustomItem<CustomItemBase>(ev.Pickup);
        cur_item?.OnSearching(ev.Player, ev.Pickup, isAllowedHelper);
        ev.IsAllowed = isAllowedHelper.Value;
    }
    public override void OnPlayerSearchedPickup(PlayerSearchedPickupEventArgs ev)
    {
        var cur_item = CustomItems.GetCustomItem<CustomItemBase>(ev.Pickup);
        cur_item?.OnSearched(ev.Player, ev.Pickup);
    }
}
