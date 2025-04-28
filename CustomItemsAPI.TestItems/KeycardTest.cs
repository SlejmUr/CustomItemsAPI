using CustomItemsAPI.Helpers;
using CustomItemsAPI.Items;
using Interactables.Interobjects.DoorUtils;
using InventorySystem.Items.Keycards;
using LabApi.Features.Wrappers;
using UnityEngine;

namespace CustomItemsAPI.TestItems;

class KeycardTest : CustomKeyCardBase
{
    public override KeycardLevels? Levels => new(3, 3, 3);

    public override bool? OpenDoorsOnThrow => true;
    public override string CustomItemName { get; set; } = "KeycardTest";

    public override string Description { get; set; } = "KeycardTest";

    public override string CustomName => "test";

    public override string CustomNameTag => "SomeTag";

    public override string CustomSerial => "66666565";
    public override Color? PermissionColor => Color.red;
    public override Color? TintColor => Color.blue;
    public override ItemType Type => ItemType.KeycardCustomTaskForce;

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