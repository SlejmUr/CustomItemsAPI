using CustomItemsAPI.Items;
using InventorySystem;
using InventorySystem.Items;
using LabApi.Features.Wrappers;
using System.Reflection;
using UnityEngine;

namespace CustomItemsAPI;

public static class CustomItems
{
    internal static readonly Dictionary<ushort, CustomItemBase> SerialToCustomItem = [];

    internal static readonly HashSet<CustomItemBase> CustomItemBaseList = [];

    #region Creating Custom Item
    /// <summary>
    /// Creating a new item with as <typeparamref name="T"/> 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns>null if <typeparamref name="T"/> not found inside <see cref="CustomItemBaseList"/> or created <typeparamref name="T"/> item </returns>
    public static T? CreateItem<T>() where T : CustomItemBase
    {
        var cib = CustomItemBaseList.FirstOrDefault(x => x.GetType() == typeof(T));
        if (cib == null)
            return null;
        var newItem = (T)cib.Clone();
        newItem.OnNewCreated();
        return newItem;
    }

    public static CustomItemBase CreateItem(string ItemName)
    {
        var cib = CustomItemBaseList.FirstOrDefault(x => x.CustomItemName == ItemName);
        if (cib == null)
            return null;
        var newItem = (CustomItemBase)cib.Clone();
        newItem.OnNewCreated();
        return newItem;
    }
    #endregion
    #region Adding Item to player
    public static void AddCustomItem<T>(Player player) where T : CustomItemBase
    {
        var item = CreateItem<T>();
        AddCustomItem(item, player);
    }

    public static void AddCustomItem(CustomItemBase item, Player player)
    {
        if (item == null)
            return;
        var itemBase = player.AddItem(item.ItemType);
        if (itemBase == null)
            return;
        item.Parse(itemBase);
        player.ReferenceHub.inventory.UserInventory.Items[item.Serial] = itemBase.Base;
        SerialToCustomItem.Add(item.Serial, item);
    }

    public static void AddCustomItem(CustomItemBase item, ReferenceHub hub)
    {
        if (item == null)
            return;
        var itemBase = Item.Get(hub.inventory.ServerAddItem(item.ItemType, ItemAddReason.AdminCommand, item.Serial));
        if (itemBase == null)
            return;
        item.Parse(itemBase);
        hub.inventory.UserInventory.Items[item.Serial] = itemBase.Base;
        SerialToCustomItem.Add(item.Serial, item);
    }
    #endregion
    #region Spawn Item
    public static void Spawn<T>(Vector3 position, Quaternion rotation = default, Vector3 scale = default) where T : CustomItemBase
    {
        var item = CreateItem<T>();
        Spawn(item, position, rotation, scale);
    }

    public static void Spawn(CustomItemBase customItem, Vector3 position, Quaternion rotation = default, Vector3 scale = default)
    {
        if (rotation == null)
            rotation = Quaternion.identity;
        if (scale == null)
            scale = Vector3.one;
        var pickup = Pickup.Create(customItem.ItemType, position, rotation, scale) ?? throw new Exception("Pickup must not be null!");
        customItem.Parse(pickup);
        SerialToCustomItem.Add(pickup.Serial, customItem);
    }
    #endregion
    #region Checks
    public static bool IsItemNameExist(string ItemName)
    {
        return CustomItemBaseList.Any(x => x.CustomItemName == ItemName);
    }
    public static bool IsCustom(ushort serial) => SerialToCustomItem.ContainsKey(serial);
    public static bool IsCustom(Item? item) => item != null && SerialToCustomItem.ContainsKey(item.Serial);
    public static bool IsCustom(Pickup? item) => item != null && SerialToCustomItem.ContainsKey(item.Serial);
    public static bool IsHoldingCustomItem(Player? player)
    {
        if (player == null)
            return false;
        return IsCustom(player.CurrentItem);
    }
    #endregion
    #region GetCustomItem
    public static T? GetCustomItem<T>(Item? item) where T : CustomItemBase
    {
        if (item == null)
            return null;
        return GetCustomItem<T>(item.Serial);
    }

    public static T? GetCustomItem<T>(Pickup? item) where T : CustomItemBase
    {
        if (item == null)
            return null;
        return GetCustomItem<T>(item.Serial);
    }
    public static T? GetCustomItem<T>(Player player) where T : CustomItemBase
    {
        if (player.IsServer)
            return null;
        return GetCustomItem<T>(player.CurrentItem);
    }

    public static T? GetCustomItem<T>(ushort serial) where T : CustomItemBase
    {
        if (serial == 0)
            return null;
        if (SerialToCustomItem.TryGetValue(serial, out var customItem))
            return (T?)customItem;
        return null;
    }
    #endregion
    #region Register Custom Item
    public static void RegisterCustomItems()
    {
        Assembly assembly = Assembly.GetCallingAssembly();
        var types = assembly.GetTypes().Where(x => !x.IsAbstract).Where(item => item.BaseType == typeof(CustomItemBase) || item.BaseType.IsSubclassOf(typeof(CustomItemBase))).ToList();
        foreach (var item in types)
        {
            CustomItemBase customItemBase = (CustomItemBase)Activator.CreateInstance(item);
            if (customItemBase == null)
                continue;
            CustomItemBaseList.Add(customItemBase);
        }
    }

    public static void RegisterCustomItems(params Type[] types)
    {
        foreach (var type in types)
        {
            RegisterCustomItem(type);
        }
    }

    public static void RegisterCustomItem(Type type)
    {
        CustomItemBase customItemBase = (CustomItemBase)Activator.CreateInstance(type);
        if (customItemBase == null)
            return;
        CustomItemBaseList.Add(customItemBase);
    }

    public static void RegisterCustomItem(CustomItemBase customItemBase)
    {
        if (customItemBase == null)
            return;
        CustomItemBaseList.Add(customItemBase);
    }
    #endregion
    #region Unregister Custom Item
    public static void UnRegisterCustomItems(params Type[] types)
    {
        foreach (var type in types)
        {
            UnRegisterCustomItem(type);
        }
    }

    public static void UnRegisterCustomItem(Type type)
    {
        CustomItemBaseList.RemoveWhere(x=>x.GetType() == type);
    }

    public static void UnRegisterCustomItem(CustomItemBase customItemBase)
    {
        if (customItemBase == null)
            return;
        CustomItemBaseList.Remove(customItemBase);
    }

    public static void UnRegisterAllCustomItems()
    {
        CustomItemBaseList.Clear();
        SerialToCustomItem.Clear();
    }

    public static void ClearSerials()
    {
        SerialToCustomItem.Clear();
    }
    #endregion
}
