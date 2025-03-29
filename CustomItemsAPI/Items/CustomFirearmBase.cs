using InventorySystem.Items.Firearms.Modules;
using LabApi.Features.Wrappers;

namespace CustomItemsAPI.Items;

// Experimental !

public abstract class CustomFirearmBase : CustomItemBase
{
    public virtual ModuleBase[] AddModules { get; } = null;
    public virtual Type[] RemoveModules { get; } = null;
    public override void Parse(Item item)
    {
        base.Parse(item);
        if (item.Category != ItemCategory.Firearm)
            throw new ArgumentOutOfRangeException("Type", item.Type, "Invalid Firearm type.");
        if (item is not FirearmItem firearm)
            throw new ArgumentException("FirearmItem must not be null!");
        var subcomponents = firearm.Base.AllSubcomponents.ToList();
        if (RemoveModules != null)
        {
            foreach (var removeType in subcomponents.Where(x => RemoveModules.Contains(x.GetType())).ToList())
            {
                subcomponents.Remove(removeType);
            }
        }
        if (AddModules != null)
        {
            foreach (var moduleBase in AddModules)
            {
                subcomponents.Add(moduleBase);
            }
        }
        firearm.Base.AllSubcomponents = [..subcomponents];
    }
}
