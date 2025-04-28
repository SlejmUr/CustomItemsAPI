using InventorySystem.Items.Autosync;
using InventorySystem.Items.Pickups;
using InventorySystem.Items;
using LabApi.Features.Wrappers;
using UnityEngine;
using CustomItemsAPI.Helpers;
using CustomItemsAPI.Interfaces;
using Scp914;

namespace CustomItemsAPI.Items;

/// <summary>
/// Custom <see cref="Item"/> base
/// </summary>
public abstract class CustomItemBase : ICloneable
{
    /// <summary>
    /// Name of your custom item.
    /// </summary>
    public abstract string CustomItemName { get; set; }

    /// <summary>
    /// Item description for admins.
    /// </summary>
    public abstract string Description { get; set; }

    /// <summary>
    /// <see cref="ItemType"/> to be made.
    /// </summary>
    public abstract ItemType Type { get; }

    /// <summary>
    /// Name of your custom item.
    /// </summary>
    public virtual string DisplayName { get; set; }

    /// <summary>
    /// Serial of the item.
    /// </summary>
    public ushort Serial
    {
        get
        { 
            if (ItemBase != null)
                return ItemBase.Serial;
            if (PickupBase != null)
                return PickupBase.Serial;
            return 0;
        }
    }

    /// <summary>
    /// Gets the new weight of the <see cref="Pickup"/>
    /// </summary>
    public virtual float Weight { get; } = float.NaN;

    /// <summary>
    /// ItemBase. It stores when the <see cref="Parse(Item)"/> function called.
    /// </summary>
    public Item ItemBase { get; private set; }

    /// <summary>
    /// ItemBase. It stores when the <see cref="Parse(Pickup)"/> function called.
    /// </summary>
    public Pickup PickupBase { get; private set; }

    /// <summary>
    /// Called once when this instance is registered.
    /// </summary>
    public virtual void OnRegistered()
    {
        CL.Debug($"OnRegistered {this.GetType()}", Main.Instance.Config.Debug);
    }
    
    /// <summary>
    /// Called once when this instance is unregistered.
    /// </summary>
    public virtual void OnUnRegistered()
    {
        CL.Debug($"OnUnRegistered {this.GetType()}", Main.Instance.Config.Debug);
    }

    /// <summary>
    /// Called when the New Item created for this Type.
    /// </summary>
    public virtual void OnNewCreated()
    {
        CL.Debug($"OnNewCreated {this.GetType()}", Main.Instance.Config.Debug);
    }

    /// <summary>
    /// Parsing <paramref name="item"/> to this Custom Item.
    /// </summary>
    /// <param name="item">A custom item.</param>
    public virtual void Parse(Item item)
    {
        CL.Debug($"Parse {item.Serial}", Main.Instance.Config.Debug);
        ItemBase = item;
        CL.Debug(item.Base.gameObject.PrintComponentTree(), Main.Instance.Config.PrintComponentOnChange);
        if (this is IModuleChangable changable && changable != null && item.Base is ModularAutosyncItem modularAutosync && modularAutosync != null)
            modularAutosync.ApplyChange(changable);
        CL.Debug(item.Base.gameObject.PrintComponentTree(), Main.Instance.Config.PrintComponentOnChange);
    }

    /// <summary>
    /// Parsing <paramref name="pickup"/> to this custom item.
    /// </summary>
    /// <param name="pickup">A Custom Pickup</param>
    public virtual void Parse(Pickup pickup)
    {
        CL.Debug($"Parse {pickup.Serial}", Main.Instance.Config.Debug);
        PickupBase = pickup;
        if (!float.IsNaN(Weight))
            PickupBase.Weight = Weight;
    }

    /// <summary>
    /// Called when <see cref="LabApi.Events.Handlers.ServerEvents.MapGenerated"/> runs for every already made instance.
    /// </summary>
    public virtual void OnDistribute()
    {
        CL.Debug("OnDistribute", Main.Instance.Config.Debug);
    }

    /// <summary>
    /// This <paramref name="player"/> changed to/from this Custom Item.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="oldItem"></param>
    /// <param name="newItem"></param>
    /// <param name="changedToThisItem">Is player selected item or unselected it.</param>
    public virtual void OnChanged(Player player, Item? oldItem, Item? newItem, bool changedToThisItem)
    {
        CL.Debug($"OnChanged {player.PlayerId} {oldItem?.Serial} {newItem?.Serial} {changedToThisItem}", Main.Instance.Config.Debug);
    }

    /// <summary>
    /// This <paramref name="player"/> changing to/from this Custom Item.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="oldItem"></param>
    /// <param name="newItem"></param>
    /// <param name="changedToThisItem">Is player selected item or unselected it.</param>
    /// <param name="isAllowed">Can allow this action.</param>
    public virtual void OnChanging(Player player, Item? oldItem, Item? newItem, bool changedToThisItem, TypeWrapper<bool> isAllowed)
    {
        CL.Debug($"OnChanging {player.PlayerId} {oldItem?.Serial} {newItem?.Serial} {changedToThisItem}", Main.Instance.Config.Debug);
    }

    /// <summary>
    /// This <paramref name="player"/> who currently dropping to Currect Custom Item.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="item"></param>
    /// <param name="isAllowed">Can allow this action.</param>
    public virtual void OnDropping(Player player, Item item, TypeWrapper<bool> isAllowed)
    {
        CL.Debug($"OnDropping {player.PlayerId} {item.Serial}", Main.Instance.Config.Debug);
    }

    /// <summary>
    /// This <paramref name="player"/> who currently dropped to Currect Custom Item.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="pickup"></param>
    public virtual void OnDropped(Player player, Pickup pickup)
    {
        CL.Debug($"OnDropped {player.PlayerId} {pickup.Serial}", Main.Instance.Config.Debug);
    }

    /// <summary>
    /// This <paramref name="player"/> who searching the Currect Custom Item.
    /// </summary>
    /// <param name="player">Player who called this function.</param>
    /// <param name="pickup">The pickup searching.</param>
    /// <param name="isAllowed">Can allow this action.</param>
    public virtual void OnSearching(Player player, Pickup pickup, TypeWrapper<bool> isAllowed)
    {
        CL.Debug($"OnSearching {player.PlayerId} {pickup.Serial}", Main.Instance.Config.Debug);
    }

    /// <summary>
    /// This <paramref name="player"/> who picked up the Currect Custom Item.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="pickup"></param>
    public virtual void OnSearched(Player player, Pickup pickup)
    {
        CL.Debug($"OnSearched {player.PlayerId} {pickup.Serial}", Main.Instance.Config.Debug);
    }

    /// <summary>
    /// This <paramref name="player"/> who picking up the Currect Custom Item.
    /// </summary>
    /// <param name="player">Player who called this function.</param>
    /// <param name="pickup">The pickup picking up</param>
    /// <param name="isAllowed">Can allow this action.</param>
    public virtual void OnPicking(Player player, Pickup pickup, TypeWrapper<bool> isAllowed)
    {
        CL.Debug($"OnPicking {player.PlayerId} {pickup.Serial}", Main.Instance.Config.Debug);
    }

    /// <summary>
    /// This <paramref name="player"/> who picked up the Currect Custom Item.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="item">The item has been picked up.</param>
    public virtual void OnPicked(Player player, Item item)
    {
        CL.Debug($"OnPicked {player.PlayerId} {item.Serial}", Main.Instance.Config.Debug);
    }

    /// <summary>
    /// This <paramref name="player"/> who throwing the Currect Custom Item.
    /// </summary>
    /// <param name="player">Player who called this function.</param>
    /// <param name="pickup">The pickup to throw.</param>
    /// <param name="rigidbody">The rigidbody for the <paramref name="pickup"/></param>
    /// <param name="isAllowed">Can allow this action.</param>
    public virtual void OnThrowing(Player player, Pickup pickup, Rigidbody rigidbody, TypeWrapper<bool> isAllowed)
    {
        CL.Debug($"OnThrowing {player.PlayerId} {pickup.Serial} {rigidbody}", Main.Instance.Config.Debug);
        if (!float.IsNaN(Weight))
            pickup.Weight = Weight;
    }

    /// <summary>
    /// This <paramref name="player"/> who threw up the Currect Custom Item.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="pickup"></param>
    /// <param name="rigidbody">The rigidbody for the <see cref="Pickup"/></param>
    public virtual void OnThrew(Player player, Pickup pickup, Rigidbody rigidbody)
    {
        CL.Debug($"OnThrew {player.PlayerId} {rigidbody}", Main.Instance.Config.Debug);
    }

    /// <summary>
    /// Called when <paramref name="player"/> is processing <paramref name="item"/> on <paramref name="knobSetting"/> setting at 914.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="item">The currently processing item.</param>
    /// <param name="knobSetting">The know setting value.</param>
    /// <param name="isAllowed">Can allow this action.</param>
    public virtual void OnProcessingItem(Player player, Item item, Scp914KnobSetting knobSetting, TypeWrapper<bool> isAllowed)
    {
        CL.Debug($"OnProcessingItem {player.PlayerId} {item.Serial} {knobSetting}", Main.Instance.Config.Debug);
        isAllowed.Value = false;
    }

    /// <summary>
    /// Called when a <paramref name="pickup"/> is processing on <paramref name="knobSetting"/> setting at 914.
    /// </summary>
    /// <param name="pickup">The currently processing pickup.</param>
    /// <param name="knobSetting">The know setting value.</param>
    /// <param name="isAllowed">Can allow this action.</param>
    public virtual void OnProcessingPickup(Pickup pickup, Scp914KnobSetting knobSetting, TypeWrapper<bool> isAllowed)
    {
        CL.Debug($"OnProcessingPickup {pickup.Serial} {knobSetting}", Main.Instance.Config.Debug);
        isAllowed.Value = false;
    }

    /// <summary>
    /// This <paramref name="player"/> who removed the Currect Custom Item.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="itemBase">ItemBase</param>
    /// <param name="itemPickupBase">itemPickupBase</param>
    public virtual void OnRemoved(Player player, ItemBase? itemBase, ItemPickupBase? itemPickupBase)
    {
        CL.Debug($"OnRemoved {player.PlayerId} {itemBase == null} {itemPickupBase == null}", Main.Instance.Config.Debug);
        if (itemPickupBase == null)
        {
            CustomItems.SerialToCustomItem.Remove(itemBase.ItemSerial);
        }
    }

    /// <inheritdoc/>
    public object Clone()
    {
        return MemberwiseClone();
    }
}
