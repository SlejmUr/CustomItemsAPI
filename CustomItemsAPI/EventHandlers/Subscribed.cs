using CustomItemsAPI.Items;
using InventorySystem.Items;
using InventorySystem.Items.MicroHID.Modules;
using InventorySystem.Items.Pickups;
using InventorySystem.Items.ThrowableProjectiles;
using LabApi.Features.Wrappers;
using MEC;

namespace CustomItemsAPI.EventHandlers;

internal sealed class Subscribed
{
    const float WaitForRemove = 0.5f;

    internal static void OnItemRemoved(ReferenceHub hub, ItemBase itemBase, ItemPickupBase itemPickupBase)
    {
        var customItem = CustomItems.GetCustomItem<CustomItemBase>(Item.Get(itemBase));
        var customItem2 = CustomItems.GetCustomItem<CustomItemBase>(Pickup.Get(itemPickupBase));
        Timing.CallDelayed(WaitForRemove, ()=> 
        {
            customItem?.OnRemoved(Player.Get(hub), itemBase, itemPickupBase);
            if (customItem != null && customItem != customItem2)
                customItem2?.OnRemoved(Player.Get(hub), itemBase, itemPickupBase);
        });
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
