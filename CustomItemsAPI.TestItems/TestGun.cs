using CustomItemsAPI.Items;
using InventorySystem.Items.Firearms.Modules;

namespace CustomItemsAPI.TestItems;

public class TestGun : CustomFirearmBase
{
    public override string CustomItemName => nameof(TestGun);

    public override string Description => nameof(TestGun);

    public override ItemType ItemType =>  ItemType.GunA7;
}
