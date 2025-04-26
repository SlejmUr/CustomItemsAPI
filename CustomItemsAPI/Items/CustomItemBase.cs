using InventorySystem.Items.Pickups;
using InventorySystem.Items;
using LabApi.Features.Wrappers;
using UnityEngine;
using CustomItemsAPI.Helpers;
using CustomItemsAPI.Interfaces;
using InventorySystem.Items.Autosync;

namespace CustomItemsAPI.Items;

/// <summary>
/// Custom Item Base
/// </summary>
public abstract class CustomItemBase : ICloneable
{
    /// <summary>
    /// Name of your custom item.
    /// </summary>
    public abstract string CustomItemName { get; }

    /// <summary>
    /// Item description for admins.
    /// </summary>
    public abstract string Description { get; }

    /// <summary>
    /// <see cref="ItemType"/> to be made.
    /// </summary>
    public abstract ItemType Type { get; }

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
    /// ItemBase. It stores when the <see cref="Parse(Item)"/> function called.
    /// </summary>
    public Item ItemBase;

    /// <summary>
    /// ItemBase. It stores when the <see cref="Parse(Pickup)"/> function called.
    /// </summary>
    public Pickup PickupBase;

    /// <summary>
    /// Called when the New Item created for this Type.
    /// </summary>
    public virtual void OnNewCreated()
    {

    }

    /// <summary>
    /// Parsing <paramref name="item"/> to this Custom Item.
    /// </summary>
    /// <param name="item">A custom item.</param>
    public virtual void Parse(Item item)
    {
        ItemBase = item;
        PickupBase = Pickup.Get(item.Base.PickupDropModel);
        CL.Info(item.Base.gameObject.PrintComponentTree());
        if (this is IModuleChangable changable && changable != null && item.Base is ModularAutosyncItem modularAutosync && modularAutosync != null)
            modularAutosync.ApplyChange(changable);
        CL.Info(item.Base.gameObject.PrintComponentTree());
    }

    /// <summary>
    /// Parsing <paramref name="pickup"/> to this custom item.
    /// </summary>
    /// <param name="pickup">A Custom Pickup</param>
    public virtual void Parse(Pickup pickup)
    {
        PickupBase = pickup;
    }

    /// <summary>
    /// This <paramref name="player"/> changed to/from this Custom Item.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="changedToThisItem">Is player selected item or unselected it.</param>
    public virtual void OnChanged(Player player, bool changedToThisItem)
    {

    }

    /// <summary>
    /// This <paramref name="player"/> changing to/from this Custom Item.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="changedToThisItem">Is player selected item or unselected it.</param>
    /// <param name="isAllowed">Can allow this action.</param>
    public virtual void OnChanging(Player player, bool changedToThisItem, TypeWrapper<bool> isAllowed)
    {

    }

    /// <summary>
    /// This <paramref name="player"/> who currently dropping to Currect Custom Item.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="isAllowed">Can allow this action.</param>
    public virtual void OnDropping(Player player, TypeWrapper<bool> isAllowed)
    {

    }

    /// <summary>
    /// This <paramref name="player"/> who currently dropped to Currect Custom Item.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    public virtual void OnDropped(Player player)
    {

    }

    /// <summary>
    /// This <paramref name="player"/> who searching the Currect Custom Item.
    /// </summary>
    /// <param name="player">Player who called this function.</param>
    /// <param name="pickup">The pickup searching.</param>
    /// <param name="isAllowed">Can allow this action.</param>
    public virtual void OnSearching(Player player, Pickup pickup, TypeWrapper<bool> isAllowed)
    {

    }

    /// <summary>
    /// This <paramref name="player"/> who picked up the Currect Custom Item.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    public virtual void OnSearched(Player player)
    {

    }

    /// <summary>
    /// This <paramref name="player"/> who picking up the Currect Custom Item.
    /// </summary>
    /// <param name="player">Player who called this function.</param>
    /// <param name="pickup">The pickup picking up</param>
    /// <param name="isAllowed">Can allow this action.</param>
    public virtual void OnPicking(Player player, Pickup pickup, TypeWrapper<bool> isAllowed)
    {

    }

    /// <summary>
    /// This <paramref name="player"/> who picked up the Currect Custom Item.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="item">The item has been picked up.</param>
    public virtual void OnPicked(Player player, Item item)
    {
        Parse(item);
    }

    /// <summary>
    /// This <paramref name="player"/> who throwing the Currect Custom Item.
    /// </summary>
    /// <param name="player">Player who called this function.</param>
    /// <param name="pickup">The pickup to throw</param>
    /// <param name="rigidbody">The rigidbody for the <paramref name="pickup"/></param>
    /// <param name="isAllowed">Can allow this action.</param>
    public virtual void OnThrowing(Player player, Pickup pickup, Rigidbody rigidbody, TypeWrapper<bool> isAllowed)
    {

    }

    /// <summary>
    /// This <paramref name="player"/> who threw up the Currect Custom Item.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="rigidbody">The rigidbody for the <see cref="LabApi.Features.Wrappers.Pickup"/></param>
    public virtual void OnThrew(Player player, Rigidbody rigidbody)
    {

    }


    /// <summary>
    /// This <paramref name="player"/> who removed the Currect Custom Item.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="itemBase">ItemBase</param>
    /// <param name="itemPickupBase">itemPickupBase</param>
    public virtual void OnRemoved(Player player, ItemBase? itemBase, ItemPickupBase? itemPickupBase)
    {
        if (itemPickupBase == null)
        {
            CL.Info("removing custom item");
            CustomItems.SerialToCustomItem.Remove(itemBase.ItemSerial);
        }
    }

    /// <inheritdoc/>
    public object Clone()
    {
        return MemberwiseClone();
    }
}
