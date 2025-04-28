using CustomItemsAPI.Items;
using Interactables.Interobjects.DoorUtils;

namespace CustomItemsAPI.TestItems;

internal class SingleUseKC : CustomSingleUseKeyCardBase
{
    public override bool? AllowClosingDoors => true;
    public override DoorPermissionFlags SingleUsePermission =>  DoorPermissionFlags.All;
    public override string CustomItemName { get; set; } = "SingleUseKC";
    public override string Description { get; set; } = "SingleUseKC";

    public override ItemType Type => ItemType.SurfaceAccessPass;
}
