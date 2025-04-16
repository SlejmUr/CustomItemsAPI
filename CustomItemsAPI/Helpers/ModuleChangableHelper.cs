using CustomItemsAPI.Interfaces;
using InventorySystem.Items.Autosync;
using LabApi.Features.Wrappers;
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
                GameObject child = GetGameObjectChild(item.gameObject, KVToReplace.Key);

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

            foreach (var moduleChanger in moduleChangable.AddModules)
            {
                // Getting the child if exists (must be duh! otherwise use the main object)
                GameObject child = GetGameObjectChild(item.gameObject, moduleChanger);

                // Creating new GameObject with the Components that we have
                GameObject myObject = new GameObject(moduleChanger.ModuleType.Name, [moduleChanger.ModuleType]);
                // Adding that to the child transform (re-parenting)
                myObject.transform.SetParent(child.transform, false);
                // getting the component and adding into the subcomponents.
                SubcomponentBase new_component = myObject.GetComponent<SubcomponentBase>();
                subcomponents.Add(new_component);
            }

        }
        item.AllSubcomponents = [.. subcomponents];
        foreach (var subcomponentBase in item.AllSubcomponents)
        {
            CL.Info($"subcomponentBase: {subcomponentBase}");
        }
        item.OnAdded(null);
    }

    public static GameObject GetGameObjectChild(this GameObject gameObject, ModuleChanger moduleChanger)
    {
        GameObject child = gameObject;
        if (moduleChanger.ChildId != -1)
            child = gameObject.transform.GetChild(moduleChanger.ChildId).gameObject;
        if (!string.IsNullOrEmpty(moduleChanger.ChildName))
            child = gameObject.transform.Find(moduleChanger.ChildName).gameObject;
        return child;
    }
}
