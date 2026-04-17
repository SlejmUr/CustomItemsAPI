using CustomItemsAPI.Events;
using CustomItemsAPI.Items;
using InventorySystem.Items.Scp1509;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.CustomHandlers;
using LabApi.Features.Wrappers;
using PlayerRoles;

namespace CustomItemsAPI.EventHandlers;

internal sealed class Scp1509Handler : CustomEventsHandler
{
    public override void OnPlayerProcessingScp1509Message(PlayerProcessingScp1509MessageEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.Scp1509Item, out CustomScp1509Base cur_item))
            return;
        TypeWrapper<bool> isAllowedHelper = new(ev.IsAllowed);
        TypeWrapper<Scp1509MessageType> message = new(ev.Message);
        TypeWrapper<bool> allowInspectHelper = new(ev.AllowInspect);
        TypeWrapper<bool> allowAttackHelper = new(ev.AllowAttack);
        CustomScp1509Events.OnProcessingScp1509Message(cur_item, ev.Player, ev.Scp1509Item, message, allowInspectHelper, allowAttackHelper, isAllowedHelper);
        cur_item.OnProcessingScp1509Message(ev.Player, ev.Scp1509Item, message, allowInspectHelper, allowAttackHelper, isAllowedHelper);
        ev.IsAllowed = isAllowedHelper.Value;
        ev.Message = message.Value;
        ev.AllowAttack = allowAttackHelper.Value;
        ev.AllowInspect = allowInspectHelper.Value;
    }

    public override void OnPlayerProcessedScp1509Message(PlayerProcessedScp1509MessageEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.Scp1509Item, out CustomScp1509Base cur_item))
            return;
        CustomScp1509Events.OnProcessedScp1509Message(cur_item, ev.Player, ev.Scp1509Item, ev.Message);
        cur_item.OnProcessedScp1509Message(ev.Player, ev.Scp1509Item, ev.Message);
    }

    public override void OnPlayerScp1509Resurrecting(PlayerScp1509ResurrectingEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.Item, out CustomScp1509Base cur_item))
            return;

        TypeWrapper<bool> isAllowedHelper = new(ev.IsAllowed);
        TypeWrapper<RoleTypeId> RespawnRoleHelper = new(ev.RespawnRole);
        TypeWrapper<Player?> RevivedPlayerHelper = new(ev.RevivedPlayer);
        CustomScp1509Events.OnResurrecting(cur_item, ev.Player, ev.Item, ev.KilledPlayer, RevivedPlayerHelper, RespawnRoleHelper, isAllowedHelper);
        cur_item.OnResurrecting(ev.Player, ev.Item, ev.KilledPlayer, RevivedPlayerHelper, RespawnRoleHelper, isAllowedHelper);
        ev.IsAllowed = isAllowedHelper.Value;
        ev.RespawnRole = RespawnRoleHelper.Value;
        ev.RevivedPlayer = RevivedPlayerHelper.Value;
    }

    public override void OnPlayerScp1509Resurrected(PlayerScp1509ResurrectedEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.Item, out CustomScp1509Base cur_item))
            return;
        CustomScp1509Events.OnResurrected(cur_item, ev.Player, ev.Item, ev.KilledPlayer, ev.RevivedPlayer, ev.RespawnRole);
        cur_item.OnResurrected(ev.Player, ev.Item, ev.KilledPlayer, ev.RevivedPlayer, ev.RespawnRole);
    }
}
