using CustomItemsAPI.Items;
using InventorySystem;
using InventorySystem.Items;
using InventorySystem.Items.Pickups;
using LabApi.Features.Wrappers;
using System.Reflection;
using UnityEngine;

namespace CustomItemsAPI;

/// <summary>
/// Static class for handling Custom Items, such as spawning, giving to player, checking and getting the item. 
/// </summary>
public static class CustomItems
{
    internal static readonly Dictionary<ushort, CustomItemBase> SerialToCustomItem = [];

    internal static readonly HashSet<CustomItemBase> CustomItemBaseList = [];

    #region Creating Custom Item
    /// <summary>
    /// Creating a new item with as <typeparamref name="T"/> 
    /// </summary>
    /// <typeparam name="T">Any <see cref="CustomItemBase"/></typeparam>
    /// <returns><see langword="null"/> if <typeparamref name="T"/> not found inside <see cref="CustomItemBaseList"/> or created <typeparamref name="T"/> item </returns>
    public static T? CreateItem<T>() where T : CustomItemBase
    {
        var cib = CustomItemBaseList.FirstOrDefault(x => x.GetType() == typeof(T));
        if (cib == null)
            return null;
        var newItem = (T)cib;
        newItem.OnNewCreated();
        return newItem;
    }

    /// <summary>
    /// Creating a new <see cref="CustomItemBase"/> from <paramref name="ItemName"/>
    /// </summary>
    /// <param name="ItemName">A registered <see cref="CustomItemBase.CustomItemName"/>.</param>
    /// <returns><see langword="null"/> if <paramref name="ItemName"/> not found inside <see cref="CustomItemBaseList"/>.</returns>
    public static CustomItemBase CreateItem(string ItemName)
    {
        var cib = CustomItemBaseList.FirstOrDefault(x => x.CustomItemName == ItemName);
        if (cib == null)
            return null;
        cib.OnNewCreated();
        return cib;
    }
    #endregion
    #region Adding Item to player
    /// <summary>
    /// Create and add Custom Item as <typeparamref name="T"/> to the <paramref name="player"/> Inventory.
    /// </summary>
    /// <typeparam name="T">Any <see cref="CustomItemBase"/>.</typeparam>
    /// <param name="player">The player to add item to.</param>
    public static Item? AddCustomItem<T>(Player player) where T : CustomItemBase
    {
        T? item = CreateItem<T>();
        return AddCustomItem(item, player);
    }

    /// <summary>
    /// Add <paramref name="CustomItemName"/> to the <paramref name="player"/> Inventory.
    /// </summary>
    /// <param name="CustomItemName">The Custom Item name.</param>
    /// <param name="player">The <see cref="Player"/> to add item to.</param>
    public static Item? AddCustomItem(string CustomItemName, Player player)
    {
        CustomItemBase? customItemBase = CreateItem(CustomItemName);
        return AddCustomItem(customItemBase, player);
    }

    /// <summary>
    /// Add <paramref name="item"/> to the <paramref name="player"/> Inventory.
    /// </summary>
    /// <param name="item">The Custom Item.</param>
    /// <param name="player">The <see cref="Player"/> to add item to.</param>
    public static Item? AddCustomItem(CustomItemBase? item, Player player)
    {
        if (item == null)
            return null;
        var itemBase = player.AddItem(item.Type);
        if (itemBase == null)
            return null;
        item.Parse(itemBase);
        player.ReferenceHub.inventory.UserInventory.Items[itemBase.Serial] = itemBase.Base;
        SerialToCustomItem.Add(itemBase.Serial, item);
        return itemBase;
    }

    /// <summary>
    /// Add <paramref name="item"/> to the <paramref name="hub"/> Inventory.
    /// </summary>
    /// <param name="item">The Custom Item.</param>
    /// <param name="hub">The <see cref="ReferenceHub"/> to add item to.</param>
    public static Item? AddCustomItem(CustomItemBase? item, ReferenceHub hub)
    {
        if (item == null)
            return null;
        var itemBase = Item.Get(hub.inventory.ServerAddItem(item.Type, ItemAddReason.AdminCommand));
        if (itemBase == null)
            return null;
        item.Parse(itemBase);
        hub.inventory.UserInventory.Items[itemBase.Serial] = itemBase.Base;
        SerialToCustomItem.Add(itemBase.Serial, item);
        return itemBase;
    }
    #endregion
    #region Spawn Item

    /// <summary>
    /// Spawns a <see cref="CustomItemBase"/> to specified parameters.
    /// </summary>
    /// <param name="customItemame"></param>
    /// <param name="position">The position the pickup should spawn.</param>
    /// <param name="rotation">The rotation the pickup should spawn.</param>
    /// <param name="scale">The scale the pickup should spawn.</param>
    /// <param name="shouldSpawn"></param>
    /// <returns>Returns <see langword="null"/> if pickup cannot be created otherwise it is a <see cref="Pickup"/>.</returns>
    public static Pickup? Spawn(string customItemame, Vector3 position, Quaternion? rotation = null, Vector3? scale = null, bool shouldSpawn = true)
    {
        CustomItemBase? item = CreateItem(customItemame);
        return Spawn(item, position, rotation, scale, shouldSpawn);
    }

    /// <summary>
    /// Spawns a Custom Item as <typeparamref name="T"/> to specified parameters.
    /// </summary>
    /// <typeparam name="T">Any <see cref="CustomItemBase"/>.</typeparam>
    /// <param name="position">The position the pickup should spawn.</param>
    /// <param name="rotation">The rotation the pickup should spawn.</param>
    /// <param name="scale">The scale the pickup should spawn.</param>
    /// <param name="shouldSpawn"></param>
    /// <returns>Returns <see langword="null"/> if pickup cannot be created otherwise it is a <see cref="Pickup"/>.</returns>
    public static Pickup? Spawn<T>(Vector3 position, Quaternion? rotation = null, Vector3? scale = null, bool shouldSpawn = true) where T : CustomItemBase
    {
        T? item = CreateItem<T>();
        return Spawn(item, position, rotation, scale, shouldSpawn);
    }

    /// <summary>
    /// Spawns a <paramref name="customItem"/> to specified parameters.
    /// </summary>
    /// <param name="customItem"></param>
    /// <param name="position">The position the pickup should spawn.</param>
    /// <param name="rotation">The rotation the pickup should spawn.</param>
    /// <param name="scale">The scale the pickup should spawn.</param>
    /// <param name="shouldSpawn"></param>
    /// <returns>Returns <see langword="null"/> if pickup cannot be created or <paramref name="customItem"/> is <see langword="null"/> otherwise it is a <see cref="Pickup"/>.</returns>
    public static Pickup? Spawn(CustomItemBase? customItem, Vector3 position, Quaternion? rotation = null, Vector3? scale = null, bool shouldSpawn = true)
    {
        if (customItem == null)
            return null;
        if (rotation == null)
            rotation = Quaternion.identity;
        if (scale == null)
            scale = Vector3.one;
        var pickup = Pickup.Create(customItem.Type, position, rotation.Value, scale.Value);
        if (pickup == null)
            return null;
        if (shouldSpawn)
            pickup.Spawn();
        customItem.Parse(pickup);
        SerialToCustomItem.Add(pickup.Serial, customItem);
        return pickup;
    }
    #endregion
    #region Checks
    /// <summary>
    /// Checks if the <see cref="CustomItemBaseList"/> has any <see cref="CustomItemBase.CustomItemName"/> as <paramref name="ItemName"/>.
    /// </summary>
    /// <param name="ItemName">The Custom Item name.</param>
    /// <param name="comparison">String Comparison for easier check.</param>
    /// <returns><see langword="true"/> if found otherwise <see langword="false"/>.</returns>
    public static bool IsItemNameExist(string? ItemName, StringComparison comparison = StringComparison.InvariantCulture)
    {
        if (string.IsNullOrEmpty(ItemName))
            return false;
        return CustomItemBaseList.Any(x => x.CustomItemName.Equals(ItemName, comparison));
    }

    /// <summary>
    /// Checks if the <paramref name="serial"/> contains inside the <see cref="SerialToCustomItem"/>.
    /// </summary>
    /// <param name="serial">The Item Serial Id.</param>
    /// <returns><see langword="true"/> if it is custom item, otherwise <see langword="false"/>.</returns>
    public static bool IsCustom(this ushort serial) => SerialToCustomItem.ContainsKey(serial);

    /// <summary>
    /// Checks if the <see cref="Item.Serial"/> contains inside the <see cref="SerialToCustomItem"/>.
    /// </summary>
    /// <param name="item">The <see cref="Item"/> to check its Serial.</param>
    /// <returns><see langword="true"/> if it is custom item, otherwise <see langword="false"/>.</returns>
    public static bool IsCustom(this Item? item) => item != null && SerialToCustomItem.ContainsKey(item.Serial);

    /// <summary>
    /// Checks if the <see cref="Item.Serial"/> contains inside the <see cref="SerialToCustomItem"/>.
    /// </summary>
    /// <param name="item">The <see cref="Item"/> to check its Serial.</param>
    /// <returns><see langword="true"/> if it is custom item, otherwise <see langword="false"/>.</returns>
    public static bool IsCustom(this ItemBase? item) => item != null && SerialToCustomItem.ContainsKey(item.ItemSerial);

    /// <summary>
    /// Checks if the <see cref="Pickup.Serial"/> contains inside the <see cref="SerialToCustomItem"/>.
    /// </summary>
    /// <param name="item">The <see cref="Pickup"/> to check its Serial.</param>
    /// <returns><see langword="true"/> if it is custom item, otherwise <see langword="false"/>.</returns>
    public static bool IsCustom(this Pickup? item) => item != null && SerialToCustomItem.ContainsKey(item.Serial);

    /// <summary>
    /// Checks if the <see cref="Pickup.Serial"/> contains inside the <see cref="SerialToCustomItem"/>.
    /// </summary>
    /// <param name="item">The <see cref="Pickup"/> to check its Serial.</param>
    /// <returns><see langword="true"/> if it is custom item, otherwise <see langword="false"/>.</returns>
    public static bool IsCustom(this ItemPickupBase? item) => item != null && SerialToCustomItem.ContainsKey(item.Info.Serial);

    /// <summary>
    /// Checks if <paramref name="player"/> holding a custom item.
    /// </summary>
    /// <param name="player">The player to check.</param>
    /// <returns><see langword="true"/> if it is custom item, otherwise <see langword="false"/>.</returns>
    public static bool IsHoldingCustomItem(this Player? player)
    {
        if (player == null)
            return false;
        return IsCustom(player.CurrentItem);
    }
    #endregion
    #region GetCustomItem with T
    /// <summary>
    /// Get the custom item as <typeparamref name="T"/> from <paramref name="item"/>.
    /// </summary>
    /// <typeparam name="T">Any <see cref="CustomItemBase"/>.</typeparam>
    /// <param name="item">The <see cref="Item"/> to get from.</param>
    /// <returns><see langword="null"/> if could not get the item otherwise <typeparamref name="T"/>.</returns>
    public static T? GetCustomItem<T>(this Item? item) where T : CustomItemBase
    {
        if (item == null)
            return null;
        return GetCustomItem<T>(item.Serial);
    }

    /// <summary>
    /// Get the custom item as <typeparamref name="T"/> from <paramref name="item"/>.
    /// </summary>
    /// <typeparam name="T">Any <see cref="CustomItemBase"/>.</typeparam>
    /// <param name="item">The <see cref="Pickup"/> to get from.</param>
    /// <returns><see langword="null"/> if could not get the item otherwise <typeparamref name="T"/>.</returns>
    public static T? GetCustomItem<T>(this Pickup? item) where T : CustomItemBase
    {
        if (item == null)
            return null;
        return GetCustomItem<T>(item.Serial);
    }

    /// <summary>
    /// Get the custom item as <typeparamref name="T"/> from <paramref name="player"/> from it's <see cref="Player.CurrentItem"/>.
    /// </summary>
    /// <typeparam name="T">Any <see cref="CustomItemBase"/>.</typeparam>
    /// <param name="player">The <see cref="Pickup"/> to get from.</param>
    /// <returns><see langword="null"/> if could not get the item otherwise <typeparamref name="T"/>.</returns>
    public static T? GetCustomItem<T>(this Player player) where T : CustomItemBase
    {
        if (player.IsHost)
            return null;
        return GetCustomItem<T>(player.CurrentItem);
    }

    /// <summary>
    /// Get the custom item as <typeparamref name="T"/> from <paramref name="serial"/>.
    /// </summary>
    /// <typeparam name="T">Any <see cref="CustomItemBase"/>.</typeparam>
    /// <param name="serial">The serial id of the item/pickup.</param>
    /// <returns><see langword="null"/> if could not get the item otherwise <typeparamref name="T"/>.</returns>
    public static T? GetCustomItem<T>(this ushort serial) where T : CustomItemBase
    {
        if (serial == 0)
            return null;
        if (SerialToCustomItem.TryGetValue(serial, out var customItem) && customItem is T customItemType)
            return customItemType;
        return null;
    }
    #endregion
    #region GetCustomItems without T
    /// <summary>
    /// Get the custom item as <see cref="CustomItemBase"/> from <paramref name="item"/>.
    /// </summary>
    /// <param name="item">The <see cref="Item"/> to get from.</param>
    /// <returns><see langword="null"/> if could not get the item otherwise <see cref="CustomItemBase"/>.</returns>
    public static CustomItemBase? GetCustomItem(this Item? item)
    {
        if (item == null)
            return null;
        return GetCustomItem(item.Serial);
    }

    /// <summary>
    /// Get the custom item as <see cref="CustomItemBase"/> from <paramref name="item"/>.
    /// </summary>
    /// <param name="item">The <see cref="ItemBase"/> to get from.</param>
    /// <returns><see langword="null"/> if could not get the item otherwise <see cref="CustomItemBase"/>.</returns>
    public static CustomItemBase? GetCustomItem(this ItemBase? item)
    {
        if (item == null)
            return null;
        return GetCustomItem(item.ItemSerial);
    }

    /// <summary>
    /// Get the custom item as <see cref="CustomItemBase"/> from <paramref name="item"/>.
    /// </summary>
    /// <param name="item">The <see cref="Pickup"/> to get from.</param>
    /// <returns><see langword="null"/> if could not get the item otherwise <see cref="CustomItemBase"/>.</returns>
    public static CustomItemBase? GetCustomItem(this Pickup? item)
    {
        if (item == null)
            return null;
        return GetCustomItem(item.Serial);
    }

    /// <summary>
    /// Get the custom item as <see cref="CustomItemBase"/> from <paramref name="item"/>.
    /// </summary>
    /// <param name="item">The <see cref="ItemPickupBase"/> to get from.</param>
    /// <returns><see langword="null"/> if could not get the item otherwise <see cref="CustomItemBase"/>.</returns>
    public static CustomItemBase? GetCustomItem(this ItemPickupBase? item)
    {
        if (item == null)
            return null;
        return GetCustomItem(item.Info.Serial);
    }

    /// <summary>
    /// Get the custom item as <see cref="CustomItemBase"/> from <paramref name="player"/> from it's <see cref="Player.CurrentItem"/>.
    /// </summary>
    /// <param name="player">The <see cref="Pickup"/> to get from.</param>
    /// <returns><see langword="null"/> if could not get the item otherwise <see cref="CustomItemBase"/>.</returns>
    public static CustomItemBase? GetCustomItem(this Player player)
    {
        if (player.IsHost) // Use Npc or something rather than server for testing!
            return null;
        return GetCustomItem(player.CurrentItem);
    }

    /// <summary>
    /// Get the custom item as <see cref="CustomItemBase"/> from <paramref name="serial"/>.
    /// </summary>
    /// <param name="serial">The serial id of the item/pickup.</param>
    /// <returns><see langword="null"/> if could not get the item otherwise <see cref="CustomItemBase"/>.</returns>
    public static CustomItemBase? GetCustomItem(this ushort serial)
    {
        if (serial == 0)
            return null;
        if (SerialToCustomItem.TryGetValue(serial, out var customItem))
            return customItem;
        return null;
    }
    #endregion
    #region TryGetCustomItems

    /// <summary>
    /// Gets the <paramref name="customItem"/> associated with the <paramref name="player"/>.
    /// </summary>
    /// <param name="player"></param>
    /// <param name="customItem"></param>
    /// <returns></returns>
    public static bool TryGetCustomItem(this Player player, out CustomItemBase? customItem)
    {
        return TryGetCustomItem(player.CurrentItem, out customItem);
    }

    /// <summary>
    /// Gets the <paramref name="customItem"/> associated with the <paramref name="item"/>.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="customItem"></param>
    /// <returns></returns>
    public static bool TryGetCustomItem(this Item? item, out CustomItemBase? customItem)
    {
        customItem = null;
        if (item == null)
            return false;
        return TryGetCustomItem(item.Serial, out customItem);
    }

    /// <summary>
    /// Gets the <paramref name="customItem"/> associated with the <paramref name="pickup"/>.
    /// </summary>
    /// <param name="pickup"></param>
    /// <param name="customItem"></param>
    /// <returns></returns>
    public static bool TryGetCustomItem(this Pickup? pickup, out CustomItemBase? customItem)
    {
        customItem = null;
        if (pickup == null)
            return false;
        return TryGetCustomItem(pickup.Serial, out customItem);
    }

    /// <summary>
    /// Gets the <paramref name="customItem"/> associated with the <paramref name="serial"/>.
    /// </summary>
    /// <param name="serial"></param>
    /// <param name="customItem"></param>
    /// <returns></returns>
    public static bool TryGetCustomItem(this ushort serial, out CustomItemBase? customItem)
    {
        return SerialToCustomItem.TryGetValue(serial, out customItem);
    }
    #endregion
    #region TryGetCustomItems as T

    /// <summary>
    /// Gets the <paramref name="customItem"/> associated with the <paramref name="player"/>.
    /// </summary>
    /// <param name="player"></param>
    /// <param name="customItem"></param>
    /// <returns></returns>
    public static bool TryGetCustomItem<T>(this Player player, out T? customItem) where T : CustomItemBase
    {
        return TryGetCustomItem<T>(player.CurrentItem, out customItem);
    }

    /// <summary>
    /// Gets the <paramref name="customItem"/> associated with the <paramref name="item"/>.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="customItem"></param>
    /// <returns></returns>
    public static bool TryGetCustomItem<T>(this Item? item, out T? customItem) where T : CustomItemBase
    {
        customItem = null;
        if (item == null)
            return false;
        return TryGetCustomItem(item.Serial, out customItem);
    }

    /// <summary>
    /// Gets the <paramref name="customItem"/> associated with the <paramref name="pickup"/>.
    /// </summary>
    /// <param name="pickup"></param>
    /// <param name="customItem"></param>
    /// <returns></returns>
    public static bool TryGetCustomItem<T>(this Pickup? pickup, out T? customItem) where T : CustomItemBase
    {
        customItem = null;
        if (pickup == null)
            return false;
        return TryGetCustomItem(pickup.Serial, out customItem);
    }

    /// <summary>
    /// Gets the <paramref name="customItem"/> associated with the <paramref name="serial"/>.
    /// </summary>
    /// <param name="serial"></param>
    /// <param name="customItem"></param>
    /// <returns></returns>
    public static bool TryGetCustomItem<T>(this ushort serial, out T? customItem) where T : CustomItemBase
    {
        if (SerialToCustomItem.TryGetValue(serial, out var customItemBase) && customItemBase is T customItemT)
        {
            customItem = customItemT;
            return true;
        }
        customItem = null;
        return false;
    }
    #endregion
    #region Register Custom Item
    /// <summary>
    /// Register custom items with the Calling Assembly.
    /// </summary>
    public static void RegisterCustomItems()
    {
        Assembly assembly = Assembly.GetCallingAssembly();
        if (assembly == typeof(CustomItems).Assembly)
            return;
        List<Type> types = [.. assembly.GetTypes().
            Where(item =>
                !item.IsAbstract &&
                typeof(CustomItemBase).IsAssignableFrom(item)
                )];
        foreach (Type type in types)
        {
            RegisterCustomItem(type);
        }
    }

    /// <summary>
    /// Register custom items with the Calling Assembly except <paramref name="exceptType"/>'s.
    /// </summary>
    /// <param name="exceptType">Parameter array of the <see cref="Type"/> of a <see cref="CustomItemBase"/>.</param>
    public static void RegisterCustomItemsExcept(params Type[] exceptType)
    {
        Assembly assembly = Assembly.GetCallingAssembly();
        if (assembly == typeof(CustomItems).Assembly)
            return;
        List<Type> types = [.. assembly.GetTypes().
            Where(item => 
                !item.IsAbstract &&
                typeof(CustomItemBase).IsAssignableFrom(item))];
        foreach (Type type in types)
        {
            if (exceptType.Contains(type))
                continue;
            RegisterCustomItem(type);
        }
    }

    /// <summary>
    /// Register only <paramref name="types"/> as custom items.
    /// </summary>
    /// <param name="types">Parameter array of the <see cref="Type"/> of a <see cref="CustomItemBase"/>.</param>
    public static void RegisterCustomItems(params Type[] types)
    {
        foreach (Type type in types)
        {
            RegisterCustomItem(type);
        }
    }

    /// <summary>
    /// Register individual <paramref name="type"/> as a custom item.
    /// </summary>
    /// <param name="type">The <see cref="Type"/> of a <see cref="CustomItemBase"/>.</param>
    public static void RegisterCustomItem(Type type)
    {
        if (type == null)
            return;
        CustomItemBase customItem = (CustomItemBase)Activator.CreateInstance(type);
        RegisterCustomItem(customItem);
    }

    /// <summary>
    /// Register <paramref name="customItemBase"/> as a custom item.
    /// </summary>
    /// <param name="customItemBase">The instanciated <see cref="CustomItemBase"/></param>
    public static void RegisterCustomItem(this CustomItemBase? customItemBase)
    {
        if (customItemBase == null)
            return;
        customItemBase.OnRegistered();
        CustomItemBaseList.Add(customItemBase);
    }
    #endregion
    #region Unregister Custom Item
    /// <summary>
    /// Unregister <paramref name="types"/> from custom items.
    /// </summary>
    /// <param name="types">Parameter array of the <see cref="Type"/> of a <see cref="CustomItemBase"/>.</param>
    public static void UnRegisterCustomItems(params Type[] types)
    {
        foreach (var type in types)
        {
            UnRegisterCustomItem(type);
        }
    }

    /// <summary>
    /// Unregister <paramref name="type"/> from custom items.
    /// </summary>
    /// <param name="type">The <see cref="Type"/> of a <see cref="CustomItemBase"/>.</param>
    public static void UnRegisterCustomItem(Type type)
    {
        CustomItemBaseList.RemoveWhere(x=>x.GetType() == type);
    }

    /// <summary>
    /// Unregister <paramref name="customItemBase"/> from custom items.
    /// </summary>
    /// <param name="customItemBase">The instanciated <see cref="CustomItemBase"/></param>
    public static void UnRegisterCustomItem(this CustomItemBase customItemBase)
    {
        if (customItemBase == null)
            return;
        customItemBase.OnUnRegistered();
        CustomItemBaseList.Remove(customItemBase);
    }

    /// <summary>
    /// Unregister all custom items.
    /// </summary>
    public static void UnRegisterCustomItems()
    {
        Assembly assembly = Assembly.GetCallingAssembly();
        List<Type> types = [.. assembly.GetTypes().Where(x => !x.IsAbstract).Where(item => item.BaseType == typeof(CustomItemBase) || item.BaseType.IsSubclassOf(typeof(CustomItemBase)))];
        foreach (var item in CustomItemBaseList.Where(x=> types.Contains(x.GetType())).ToList())
        {
            UnRegisterCustomItem(item);
        }
        SerialToCustomItem.Clear();
    }

    /// <summary>
    /// Unregister all custom items.
    /// </summary>
    public static void UnRegisterAllCustomItems()
    {
        foreach (var item in CustomItemBaseList.ToList())
        {
            UnRegisterCustomItem(item);
        }
        SerialToCustomItem.Clear();
    }

    /// <summary>
    /// Clear custom items serials.
    /// </summary>
    public static void ClearSerials()
    {
        SerialToCustomItem.Clear();
    }
    #endregion
    #region Bonus
    /// <summary>
    /// Adding custom item to the serial.
    /// </summary>
    /// <param name="serial"></param>
    /// <param name="customItem"></param>
    public static void AddCustomItemToSerial(ushort serial, CustomItemBase? customItem)
    {
        if (serial == 0)
            return;
        if (customItem == null)
            return;
        if (SerialToCustomItem.ContainsKey(serial))
            return;
        SerialToCustomItem.Add(serial, customItem);
    }
    #endregion
}
