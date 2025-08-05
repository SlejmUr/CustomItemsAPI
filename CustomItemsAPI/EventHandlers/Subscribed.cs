using CustomItemsAPI.Items;
using InventorySystem.Items;
using InventorySystem.Items.Jailbird;
using InventorySystem.Items.MicroHID.Modules;
using InventorySystem.Items.Pickups;
using InventorySystem.Items.ThrowableProjectiles;
using LabApi.Features.Wrappers;
using MEC;

namespace CustomItemsAPI.EventHandlers;

internal sealed class Subscribed
{
    internal static void OnItemRemoved(ReferenceHub hub, ItemBase itemBase, ItemPickupBase itemPickupBase)
    {
        var customItem = CustomItems.GetCustomItem<CustomItemBase>(Item.Get(itemBase));
        var customItem2 = CustomItems.GetCustomItem<CustomItemBase>(Pickup.Get(itemPickupBase));
        customItem?.OnRemoved(Player.Get(hub), itemBase, itemPickupBase);
        if (customItem != null && customItem != customItem2)
            customItem2?.OnRemoved(Player.Get(hub), itemBase, itemPickupBase);
    }

    internal static void ProjectileSpawned(ThrownProjectile projectile)
    {
        var cur_item = CustomItems.GetCustomItem<CustomThrowableBase>(Pickup.Get(projectile));
        cur_item?.OnProjectileSpawned(projectile);
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
