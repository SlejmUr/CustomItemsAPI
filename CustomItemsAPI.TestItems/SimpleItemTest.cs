using CustomItemsAPI.Items;
using LabApi.Features.Wrappers;

namespace CustomItemsAPI.TestItems;

class SimpleItemTest : CustomItemBase
{
    public override string CustomItemName { get; set; } = "SimpleItemTest";
    public override string Description { get; set; } = "Testing simple item";
    public override ItemType Type => ItemType.KeycardGuard;

}