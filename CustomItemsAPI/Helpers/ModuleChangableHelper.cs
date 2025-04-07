using CustomItemsAPI.Interfaces;
using InventorySystem.Items.Autosync;
using UnityEngine;

namespace CustomItemsAPI.Helpers;

public static class ModuleChangableHelper
{
    public static void ApplyChange(this ModularAutosyncItem item, IModuleChangable moduleChangable)
    {
        item.OnAdded(null);
        List<SubcomponentBase> subcomponents = [];
        foreach (SubcomponentBase subcomponent in item.AllSubcomponents)
        {
            var KVToReplace = moduleChangable.ReplaceModules.FirstOrDefault(x=>x.Key.ModuleType == subcomponent.GetType());
            if (KVToReplace.Value != default)
            {
                // Getting the child if exists (must be duh! otherwise use the main object)
                GameObject child = item.gameObject;
                if (KVToReplace.Key.ChildId != -1)
                    child = item.gameObject.transform.GetChild(KVToReplace.Key.ChildId).gameObject;
                if (!string.IsNullOrEmpty(KVToReplace.Key.ChildName))
                    child = item.gameObject.transform.Find(KVToReplace.Key.ChildName).gameObject;

                // Here we find it and remove it!
                var realComponent = child.transform.Find(subcomponent.name);
                realComponent.parent = null;
                GameObject.Destroy(realComponent);

                // Creating new GameObject with the Components that we have
                GameObject myObject = new GameObject(KVToReplace.Value.Name, [KVToReplace.Value]);
                // Adding that to the child transform (re-parenting)
                myObject.transform.SetParent(child.transform, false);
                // getting the component and adding into the subcomponents.
                SubcomponentBase new_component = myObject.GetComponent<SubcomponentBase>();
                subcomponents.Add(new_component);
            }
            else if(!subcomponents.Contains(subcomponent))
                subcomponents.Add(subcomponent);
        }
        item.AllSubcomponents = [.. subcomponents];
        foreach (var subcomponentBase in item.AllSubcomponents)
        {
            CL.Info($"subcomponentBase: {subcomponentBase}");
        }
        item.OnAdded(null);
    }
}
