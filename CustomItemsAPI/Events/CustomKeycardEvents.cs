using CustomItemsAPI.Items;
using LabApi.Features.Wrappers;
using GeneratorColliderId =  MapGeneration.Distributors.Scp079Generator.GeneratorColliderId;

namespace CustomItemsAPI.Events;

public static class CustomKeycardEvents
{
    public static event Action<CustomKeycardBase, Player, Item, Door, bool>? InteractedDoor;
    public static event Action<CustomKeycardBase, Player, Item, Door, TypeWrapper<bool>, TypeWrapper<bool>>? InteractingDoor;
    public static event Action<CustomKeycardBase, Player, Item, Generator, GeneratorColliderId>? InteractedGenerator;
    public static event Action<CustomKeycardBase, Player, Item, Generator, TypeWrapper<GeneratorColliderId>, TypeWrapper<bool>>? InteractingGenerator;
    public static event Action<CustomKeycardBase, Player, Item, Locker, LockerChamber, bool>? InteractedLocker;
    public static event Action<CustomKeycardBase, Player, Item, Locker, LockerChamber, TypeWrapper<bool>, TypeWrapper<bool>>? InteractingLocker;
    public static event Action<CustomKeycardBase, Player, KeycardItem>? InspectedKeycard;
    public static event Action<CustomKeycardBase, Player, KeycardItem, TypeWrapper<bool>>? InspectingKeycard;

    public static void OnInteractedDoor(CustomKeycardBase customItem, Player player, Item item, Door door, bool canOpen)
        => InteractedDoor?.Invoke(customItem, player, item, door, canOpen);
    public static void OnInteractingDoor(CustomKeycardBase customItem, Player player, Item item, Door door, TypeWrapper<bool> canOpen, TypeWrapper<bool> isAllowed)
        => InteractingDoor?.Invoke(customItem, player, item, door, canOpen, isAllowed);
    public static void OnInteractedGenerator(CustomKeycardBase customItem, Player player, Item item, Generator generator, GeneratorColliderId colliderId)
        => InteractedGenerator?.Invoke(customItem, player, item, generator, colliderId);
    public static void OnInteractingGenerator(CustomKeycardBase customItem, Player player, Item item, Generator generator, TypeWrapper<GeneratorColliderId> colliderId, TypeWrapper<bool> isAllowed)
        => InteractingGenerator?.Invoke(customItem, player, item, generator, colliderId, isAllowed);
    public static void OnInteractedLocker(CustomKeycardBase customItem, Player player, Item item, Locker locker, LockerChamber lockerChamber, bool canOpen)
        => InteractedLocker?.Invoke(customItem, player, item, locker, lockerChamber, canOpen);
    public static void OnInteractingLocker(CustomKeycardBase customItem, Player player, Item item, Locker locker, LockerChamber lockerChamber, TypeWrapper<bool> canOpen, TypeWrapper<bool> isAllowed)
        => InteractingLocker?.Invoke(customItem, player, item, locker, lockerChamber, canOpen, isAllowed);
    public static void OnInspectedKeycard(CustomKeycardBase customItem, Player player, KeycardItem keycardItem)
        => InspectedKeycard?.Invoke(customItem, player, keycardItem);
    public static void OnInspectingKeycard(CustomKeycardBase customItem, Player player, KeycardItem keycardItem, TypeWrapper<bool> isAllowed)
        => InspectingKeycard?.Invoke(customItem, player, keycardItem, isAllowed);
}
