using CustomItemsAPI.Items;
using LabApi.Features.Wrappers;

namespace CustomItemsAPI.TestItems;

class SimpleItemTest : CustomItemBase
{
    public override string CustomItemName => "SimpleItemTest";
    public override string Description => "Testing simple item";
    public override ItemType ItemType => ItemType.KeycardGuard;

    public override void OnDropped(Player player)
    {
        player.SendHint("dropped");
    }
}