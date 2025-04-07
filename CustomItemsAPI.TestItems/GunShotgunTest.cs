using CustomItemsAPI.Items;
using CustomItemsAPI.TestItems.Modules.MicroHID;
using InventorySystem.Items.Firearms.Modules;
using InventorySystem.Items.MicroHID.Modules;

namespace CustomItemsAPI.TestItems;

public class GunShotgunTest : CustomFirearmBase
{
    public override string CustomItemName => nameof(GunShotgunTest);

    public override string Description => nameof(GunShotgunTest);

    public override ItemType ItemType =>  ItemType.GunShotgun;
    /*
    public override Dictionary<Type, Type> ReplaceModules => new()
    {
        { typeof(SingleBulletHitscan), typeof(BuckshotHitreg) }
    };*/
}
