using CustomItemsAPI.Items;

namespace CustomItemsAPI.TestItems;

public class TestGun : CustomFirearmBase
{
    public override string CustomItemName { get; set; } = nameof(TestGun);

    public override string Description { get; set; } = nameof(TestGun);

    public override ItemType Type =>  ItemType.GunA7;
}
