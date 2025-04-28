using CustomItemsAPI.Items;

namespace CustomItemsAPI.TestItems.ManyItemTest;

internal class ManyItemBase : CustomItemBase
{
    public override string CustomItemName { get; set; }
    public override string Description { get; set; }
    public override ItemType Type => ItemType.ArmorLight;
}
