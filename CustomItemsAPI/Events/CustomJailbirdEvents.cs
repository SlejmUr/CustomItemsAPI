using CustomItemsAPI.Items;
using LabApi.Features.Wrappers;

namespace CustomItemsAPI.Events;

public static class CustomJailbirdEvents
{
    public static event Action<CustomJailbirdBase, Player, JailbirdItem, TypeWrapper<InventorySystem.Items.Jailbird.JailbirdMessageType>, TypeWrapper<bool>, TypeWrapper<bool>, TypeWrapper<bool>>? ProcessingJailbirdMessage;
    public static event Action<CustomJailbirdBase, Player, JailbirdItem, InventorySystem.Items.Jailbird.JailbirdMessageType>? ProcessedJailbirdMessage;

    public static void OnProcessingJailbirdMessage(CustomJailbirdBase customItem, Player player, JailbirdItem jailbirdItem, TypeWrapper<InventorySystem.Items.Jailbird.JailbirdMessageType> message, TypeWrapper<bool> allowInspectHelper, TypeWrapper<bool> allowAttackHelper, TypeWrapper<bool> isAllowedHelper)
        => ProcessingJailbirdMessage?.Invoke(customItem, player, jailbirdItem, message, allowInspectHelper, allowAttackHelper, isAllowedHelper);

    public static void OnProcessedJailbirdMessage(CustomJailbirdBase customItem, Player player, JailbirdItem jailbirdItem, InventorySystem.Items.Jailbird.JailbirdMessageType message)
        => ProcessedJailbirdMessage?.Invoke(customItem, player, jailbirdItem, message);
}
