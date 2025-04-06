using CustomItemsAPI.Items;
using CustomItemsAPI.TestItems.Modules.MicroHID;
using InventorySystem.Items.Firearms.Modules;
using InventorySystem.Items.MicroHID.Modules;

namespace CustomItemsAPI.TestItems;

public class FirearmTest : CustomFirearmBase
{
    public override string CustomItemName => nameof(FirearmTest);

    public override string Description => nameof(FirearmTest);

    public override ItemType ItemType =>  ItemType.GunShotgun;
    /*
    public override Dictionary<Type, Type> ReplaceModules => new()
    {
        { typeof(SingleBulletHitscan), typeof(BuckshotHitreg) }
    };*/
}
