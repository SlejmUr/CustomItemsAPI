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
    /// Item Type to be made.
    /// </summary>
    public abstract ItemType ItemType { get; }

    /// <summary>
    /// Serial of the item.
    /// </summary>
    public ushort Serial
    {
        get
        { 
            if (Item != null)
                return Item.Serial;
            if (Pickup != null)
                return Pickup.Serial;
            return 0;
        }
    }


    /// <summary>
    /// ItemBase. It stores when the <see cref="Parse(Item)"/> function called.
    /// </summary>
    public Item Item;

    /// <summary>
    /// ItemBase. It stores when the <see cref="Parse(Pickup)"/> function called.
    /// </summary>
    public Pickup Pickup;

    /// <summary>
    /// Called when the New Item created for this Type.
    /// </summary>
    public virtual void OnNewCreated()
    {

    }

    public virtual void Parse(Item item)
    {
        Item = item;
        Pickup = Pickup.Get(item.Base.PickupDropModel);
        CL.Info(item.Base.gameObject.PrintComponentTree());
        if (this is IModuleChangable changable && changable != null && item.Base is ModularAutosyncItem modularAutosync && modularAutosync != null)
        {
            modularAutosync.ApplyChange(changable);
        }
        CL.Info(item.Base.gameObject.PrintComponentTree());
    }

    public virtual void Parse(Pickup pickup)
    {
        Pickup = pickup;
    }

    /// <summary>
    /// This <paramref name="player"/> changed to/from this Custom Item.
    /// </summary>
    /// <param name="player">The Player who called this function</param>
    /// <param name="changedToThisItem">Is player selected item or unselected it</param>
    public virtual void OnChanged(Player player, bool changedToThisItem)
    {

    }

    public virtual void OnChanging(Player player, bool changedToThisItem, TypeWrapper<bool> isAllowed)
    {

    }

    /// <summary>
    /// This <paramref name="player"/> who currently dropping to Currect Custom Item.
    /// </summary>
    /// <param name="player">The Player who called this function</param>
    public virtual void OnDropping(Player player, TypeWrapper<bool> isAllowed)
    {

    }

    /// <summary>
    /// This <paramref name="player"/> who currently dropping to Currect Custom Item.
    /// </summary>
    /// <param name="player">The Player who called this function</param>
    public virtual void OnDropped(Player player)
    {

    }

    /// <summary>
    /// This <paramref name="player"/> who currently picking up the Currect Custom Item.
    /// </summary>
    /// <param name="player">Player who called this function</param>
    /// <param name="pickup"></param>
    public virtual void OnSearching(Player player, Pickup pickup, TypeWrapper<bool> isAllowed)
    {

    }

    /// <summary>
    /// This <paramref name="player"/> who already picked up the Currect Custom Item.
    /// </summary>
    /// <param name="player">The Player who called this function</param>
    public virtual void OnSearched(Player player)
    {

    }

    /// <summary>
    /// This <paramref name="player"/> who currently picking up the Currect Custom Item.
    /// </summary>
    /// <param name="player">Player who called this function</param>
    /// <param name="pickup"></param>
    public virtual void OnPicking(Player player, Pickup pickup, TypeWrapper<bool> isAllowed)
    {

    }

    /// <summary>
    /// This <paramref name="player"/> who already picked up the Currect Custom Item.
    /// </summary>
    /// <param name="player">The Player who called this function</param>
    public virtual void OnPicked(Player player, Item item)
    {
        Parse(item);
    }

    /// <summary>
    /// This <paramref name="player"/> who currently picking up the Currect Custom Item.
    /// </summary>
    /// <param name="player">Player who called this function</param>
    /// <param name="pickup"></param>
    public virtual void OnThrowing(Player player, Pickup pickup, Rigidbody rigidbody, TypeWrapper<bool> isAllowed)
    {

    }

    /// <summary>
    /// This <paramref name="player"/> who already picked up the Currect Custom Item.
    /// </summary>
    /// <param name="player">The Player who called this function</param>
    public virtual void OnThrew(Player player, Rigidbody rigidbody)
    {

    }


    /// <summary>
    /// This <paramref name="player"/> who dropped to Currect Custom Item.
    /// </summary>
    /// <param name="player">The Player who called this function</param>
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

    public object Clone()
    {
        return MemberwiseClone();
    }
}
