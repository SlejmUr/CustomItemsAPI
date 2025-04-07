using CustomItemsAPI.Items;
using InventorySystem.Items.Firearms.Modules;

namespace CustomItemsAPI.TestItems;

public class VectorTest : CustomFirearmBase
{
    public override string CustomItemName => nameof(VectorTest);

    public override string Description => nameof(VectorTest);

    public override ItemType ItemType =>  ItemType.GunCrossvec;
    /*
    public override Dictionary<Type, Type> ReplaceModules => new()
    {
        { typeof(SingleBulletHitscan), typeof(BuckshotHitreg) }
    };*/
}
