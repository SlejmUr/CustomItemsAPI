using CustomItemsAPI.Items;
using InventorySystem.Items.Jailbird;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.CustomHandlers;

namespace CustomItemsAPI.EventHandlers;

internal sealed class JailbirdHandler : CustomEventsHandler
{
    public override void OnPlayerProcessingJailbirdMessage(PlayerProcessingJailbirdMessageEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.JailbirdItem, out CustomJailbirdBase cur_item))
            return;
        TypeWrapper<bool> isAllowedHelper = new(ev.IsAllowed);
        TypeWrapper<JailbirdMessageType> message = new(ev.Message);
        TypeWrapper<bool> allowInspectHelper = new(ev.AllowInspect);
        TypeWrapper<bool> allowAttackHelper = new(ev.AllowAttack);
        cur_item.ProcessingJailbirdMessage(ev.Player, ev.JailbirdItem, message, allowInspectHelper, allowAttackHelper, isAllowedHelper);
        ev.IsAllowed = isAllowedHelper.Value;
        ev.Message = message.Value;
        ev.AllowAttack = allowAttackHelper.Value;
        ev.AllowInspect = allowInspectHelper.Value;
    }

    public override void OnPlayerProcessedJailbirdMessage(PlayerProcessedJailbirdMessageEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.JailbirdItem, out CustomJailbirdBase cur_item))
            return;
        cur_item.ProcessedJailbirdMessage(ev.Player, ev.JailbirdItem, ev.Message);
    }
}
