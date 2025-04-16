using CustomItemsAPI.Helpers;
using CustomItemsAPI.Items;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.CustomHandlers;
using PlayerStatsSystem;

namespace CustomItemsAPI.EventHandlers;

internal sealed class DamageHandler : CustomEventsHandler
{
    public override void OnPlayerHurting(PlayerHurtingEventArgs ev)
    {
        if (ev.Player == null)
            return;
        if (ev.Target == null)
            return;
        if (ev.Target == ev.Player)
            return;
        if (ev.DamageHandler is not FirearmDamageHandler firearmDamageHandler)
            return;
        if (firearmDamageHandler == null)
            return;
        if (firearmDamageHandler.Firearm == null)
            return;
        TypeWrapper<bool> isAllowedHelper = new(ev.IsAllowed);
        var citem = CustomItems.GetCustomItem<CustomFirearmBase>(firearmDamageHandler.Firearm.ItemSerial);
        citem?.OnHurting(ev.Target, ev.Player, firearmDamageHandler, isAllowedHelper);
        ev.IsAllowed = isAllowedHelper.Value;
    }

    public override void OnPlayerHurt(PlayerHurtEventArgs ev)
    {
        if (ev.Player == null)
            return;
        if (ev.Target == null)
            return;
        if (ev.Target == ev.Player)
            return;
        if (ev.DamageHandler is not FirearmDamageHandler firearmDamageHandler)
            return;
        if (firearmDamageHandler == null)
            return;
        if (firearmDamageHandler.Firearm == null)
            return;
        var citem = CustomItems.GetCustomItem<CustomFirearmBase>(firearmDamageHandler.Firearm.ItemSerial);
        citem?.OnHurt(ev.Target, ev.Player, firearmDamageHandler);
    }
}
