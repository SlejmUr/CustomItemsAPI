using CustomItemsAPI.Items;
using LabApi.Features.Wrappers;

namespace CustomItemsAPI.Events;

public static class CustomUsableEvents
{
    public static event Action<CustomUsableBase, Player, UsableItem>? Cancelled;
    public static event Action<CustomUsableBase, Player, UsableItem, TypeWrapper<bool>>? Cancelling;
    public static event Action<CustomUsableBase, Player, UsableItem>? Used;
    public static event Action<CustomUsableBase, Player, UsableItem, TypeWrapper<bool>>? Using;

    public static void OnCancelled(CustomUsableBase custom, Player player, UsableItem usableItem)
        => Cancelled?.Invoke(custom, player, usableItem);
    public static void OnCancelling(CustomUsableBase custom, Player player, UsableItem usableItem, TypeWrapper<bool> isAllowed)
        => Cancelling?.Invoke(custom, player, usableItem, isAllowed);

    public static void OnUsed(CustomUsableBase custom, Player player, UsableItem usableItem)
        => Used?.Invoke(custom, player, usableItem);
    public static void OnUsing(CustomUsableBase custom, Player player, UsableItem usableItem, TypeWrapper<bool> isAllowed)
        => Using?.Invoke(custom, player, usableItem, isAllowed);
}

