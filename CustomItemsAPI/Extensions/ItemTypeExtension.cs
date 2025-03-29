namespace CustomItemsAPI.Extensions;

public static class ItemTypeExtension
{
    public static bool IsArmor(this ItemType itemType) =>
    itemType is ItemType.ArmorCombat or ItemType.ArmorHeavy or ItemType.ArmorLight;

    public static bool IsAmmo(this ItemType itemType) =>
    itemType is ItemType.Ammo9x19 or ItemType.Ammo556x45 or ItemType.Ammo12gauge or ItemType.Ammo44cal or ItemType.Ammo762x39;

    public static bool IsKeycard(this ItemType itemType) =>
    itemType is ItemType.KeycardJanitor or ItemType.KeycardScientist or ItemType.KeycardResearchCoordinator or ItemType.KeycardZoneManager
    or ItemType.KeycardGuard or ItemType.KeycardMTFPrivate or ItemType.KeycardContainmentEngineer or ItemType.KeycardMTFOperative
    or ItemType.KeycardMTFCaptain or ItemType.KeycardFacilityManager or ItemType.KeycardChaosInsurgency or ItemType.KeycardO5;
}
