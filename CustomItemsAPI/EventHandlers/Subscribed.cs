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
        customItem?.OnRemoved(Player.Get(hub), itemBase, itemPickupBase);
        customItem = CustomItems.GetCustomItem<CustomItemBase>(Pickup.Get(itemPickupBase));
        customItem?.OnRemoved(Player.Get(hub), itemBase, itemPickupBase);
    }

    internal static void ProjectileSpawned(ThrownProjectile projectile)
    {
        var cur_item = CustomItems.GetCustomItem<CustomThrowableBase>(Pickup.Get(projectile));
        cur_item?.OnProjectileSpawned(projectile);
    }

    internal static void PhaseChanged(ushort Serial, MicroHidPhase phase)
    {
        var cur_item = CustomItems.GetCustomItem<CustomMicroHIDBase>(Serial);
        cur_item?.OnPhaseChanged(phase);
    }
}
