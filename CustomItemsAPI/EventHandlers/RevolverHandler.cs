using CustomItemsAPI.Items;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.CustomHandlers;

namespace CustomItemsAPI.EventHandlers;

internal sealed class RevolverHandler : CustomEventsHandler
{
    public override void OnPlayerSpinningRevolver(PlayerSpinningRevolverEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.Revolver, out CustomRevolverBase cur_item))
            return;
        TypeWrapper<bool> isAllowed = new(ev.IsAllowed);
        cur_item.OnSpinning(ev.Player, ev.Revolver, isAllowed);
        ev.IsAllowed = isAllowed.Value;
    }

    public override void OnPlayerSpinnedRevolver(PlayerSpinnedRevolverEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.Revolver, out CustomRevolverBase cur_item))
            return;
        cur_item.OnSpinned(ev.Player, ev.Revolver);
    }
}