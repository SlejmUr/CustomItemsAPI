using CustomItemsAPI.Interfaces;
using InventorySystem.Items.Autosync;

namespace CustomItemsAPI.Helpers;

public static class ModuleChangableHelper
{
    public static void ApplyChange(this ModularAutosyncItem item, IModuleChangable moduleChangable)
    {
        item.OnAdded(null);
        List<SubcomponentBase> subcomponents = [];
        foreach (var subcomponent in item.AllSubcomponents)
        {
            CL.Info("ApplyChange subcomponent: " + subcomponent);
        }
        foreach (var subcomponent in item.AllSubcomponents)
        {
            if (moduleChangable.ReplaceModules.TryGetValue(subcomponent.GetType(), out Type type))
                subcomponents.Add(item.gameObject.AddComponent(type) as SubcomponentBase);
            else if(!subcomponents.Contains(subcomponent))
                subcomponents.Add(subcomponent);
        }
        item.AllSubcomponents = [.. subcomponents];
        foreach (var subcomponent in item.AllSubcomponents)
        {
            CL.Info("ApplyChange changed: " + subcomponent);
        }
        item.OnAdded(null);
    }
}
