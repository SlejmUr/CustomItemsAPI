using CustomItemsAPI.Helpers;
using CustomItemsAPI.Interfaces;
using InventorySystem.Items.Firearms;
using LabApi.Features.Wrappers;

namespace CustomItemsAPI.Items;

public abstract class CustomFirearmBase : CustomItemBase, IModuleChangable
{
    public virtual Dictionary<ModuleChanger, Type> ReplaceModules { get; } = [];
    public FirearmItem Firearm => Item as FirearmItem;

    public override void Parse(Item item)
    {
        base.Parse(item);
        if (Firearm.Category != ItemCategory.Firearm)
            throw new ArgumentOutOfRangeException("Type", item.Type, "Invalid Firearm type.");
        if (Item is not FirearmItem)
            throw new ArgumentException("FirearmItem must not be null!");
    }
}
