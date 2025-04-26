using CustomItemsAPI.Helpers;
using CustomItemsAPI.Items;
using Interactables.Interobjects.DoorUtils;
using LabApi.Features.Wrappers;

namespace CustomItemsAPI.TestItems;

class KeycardTest : CustomKeyCardBase
{
    public override KeycardLevels Levels => new(3, 3, 3);

    public override string CustomItemName => "KeycardTest";

    public override string Description => "KeycardTest";

    public override ItemType Type => ItemType.KeycardJanitor;

    public override void OnInteractingLocker(Player player, Locker locker, LockerChamber lockerChamber, TypeWrapper<bool> canOpen, TypeWrapper<bool> isAllowed)
    {
        canOpen.Value = true;
        isAllowed.Value = true;
    }
    public override void OnInteractingGenerator(Player player, Generator generator, TypeWrapper<bool> isAllowed)
    {
        isAllowed.Value = true;
    }

    public override void OnInteractingDoor(Player player, Door door, TypeWrapper<bool> canOpen, TypeWrapper<bool> isAllowed)
    {
        canOpen.Value = true;
        isAllowed.Value = true;
    }
}