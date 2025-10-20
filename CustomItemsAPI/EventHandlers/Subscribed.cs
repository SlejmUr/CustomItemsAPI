using CustomItemsAPI.Events;
using CustomItemsAPI.Items;
using InventorySystem.Items;
using InventorySystem.Items.MicroHID.Modules;
using InventorySystem.Items.Pickups;
using InventorySystem.Items.ThrowableProjectiles;
using LabApi.Features.Wrappers;

namespace CustomItemsAPI.EventHandlers;

internal sealed class Subscribed
{
    internal static void OnItemRemoved(ReferenceHub hub, ItemBase itemBase, ItemPickupBase itemPickupBase)
    {
        var customItem = CustomItems.GetCustomItem<CustomItemBase>(Item.Get(itemBase));
        var customItem2 = CustomItems.GetCustomItem<CustomItemBase>(Pickup.Get(itemPickupBase));
        Player player = Player.Get(hub);
        CustomItemEvents.OnRemoved(customItem, player, itemBase, itemPickupBase);
        customItem?.OnRemoved(player, itemBase, itemPickupBase);
        if (customItem != null && customItem != customItem2)
        {
            CustomItemEvents.OnRemoved(customItem2, player, itemBase, itemPickupBase);
            customItem2?.OnRemoved(player, itemBase, itemPickupBase);
        }
            
    }

    internal static void ProjectileSpawned(ThrownProjectile projectile)
    {
        if (!CustomItems.TryGetCustomItem(Pickup.Get(projectile), out CustomThrowableBase cur_item))
            return;
        cur_item.OnProjectileSpawned(projectile);
    }

    internal static void PhaseChanged(ushort Serial, MicroHidPhase phase)
    {
        if (!CustomItems.TryGetCustomItem(Serial, out CustomMicroHIDBase cur_item))
            return;
        if (Item.Get(Serial) is not MicroHIDItem microHIDItem)
            return;
        cur_item.OnPhaseChanged(microHIDItem, phase);
    }


    internal static void BrokenSyncModule_OnBroken(ushort Serial)
    {
        if (!CustomItems.TryGetCustomItem(Serial, out CustomMicroHIDBase cur_item))
            return;
        if (Item.Get(Serial) is not MicroHIDItem microHIDItem)
            return;
        cur_item.OnBroken(microHIDItem);
    }

    internal static void DrawAndInspectorModule_OnInspectRequested(ushort Serial)
    {
        if (!CustomItems.TryGetCustomItem(Serial, out CustomMicroHIDBase cur_item))
            return;
        if (Item.Get(Serial) is not MicroHIDItem microHIDItem)
            return;
        cur_item.OnInspectRequested(microHIDItem);
    }
}
