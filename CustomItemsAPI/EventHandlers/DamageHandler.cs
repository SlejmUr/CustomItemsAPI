using CustomItemsAPI.Events;
using CustomItemsAPI.Extensions;
using CustomItemsAPI.Items;
using InventorySystem.Items.Armor;
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
        if (ev.Attacker == null)
            return;
        if (ev.Attacker == ev.Player)
            return;
        if (ev.DamageHandler is not FirearmDamageHandler firearmDamageHandler)
            return;
        if (firearmDamageHandler == null)
            return;
        if (firearmDamageHandler.Firearm == null)
            return;

        if (CustomItems.TryGetCustomItem(firearmDamageHandler.Firearm.ItemSerial, out CustomFirearmBase cur_item))
        {
            TypeWrapper<bool> isAllowedHelper = new(ev.IsAllowed);
            CustomFirearmEvents.OnHurting(cur_item, ev.Player, ev.Attacker, firearmDamageHandler, isAllowedHelper);
            cur_item.OnHurting(ev.Player, ev.Attacker, firearmDamageHandler, isAllowedHelper);
            ev.IsAllowed = isAllowedHelper.Value;
            return;
        }

        if (!ev.Player.Inventory.TryGetBodyArmor(out _))
            return;

        CL.Debug($"OnPlayerHurting {ev.Player.DisplayName} ARMOUR");
        if (CustomItems.TryGetCustomItem(item: ev.Player.Items.Where(x => x.Type.IsArmor()).FirstOrDefault(), out CustomArmorBase cur_armor))
        {
            CL.Debug($"OnPlayerHurting {ev.Player.DisplayName} CUSTOM ITEM {cur_armor}");
            CustomItemEvents.OnTakingDamage(cur_armor, ev.Player, ev.Attacker, ev.DamageHandler);
            cur_armor.OnTakingDamage(ev.Player, ev.Attacker, firearmDamageHandler);
            return;
        }
    }

    public override void OnPlayerHurt(PlayerHurtEventArgs ev)
    {
        if (ev.Player == null)
            return;
        if (ev.Attacker == null)
            return;
        if (ev.Attacker == ev.Player)
            return;
        if (ev.DamageHandler is not FirearmDamageHandler firearmDamageHandler)
            return;
        if (firearmDamageHandler == null)
            return;
        if (firearmDamageHandler.Firearm == null)
            return;
        if (!CustomItems.TryGetCustomItem(firearmDamageHandler.Firearm.ItemSerial, out CustomFirearmBase cur_item))
            return;
        CustomFirearmEvents.OnHurt(cur_item, ev.Player, ev.Attacker, firearmDamageHandler);
        cur_item.OnHurt(ev.Player, ev.Attacker, firearmDamageHandler);
    }
}
