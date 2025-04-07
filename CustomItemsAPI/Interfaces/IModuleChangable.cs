using CustomItemsAPI.Helpers;

namespace CustomItemsAPI.Interfaces;

public interface IModuleChangable
{
    public Dictionary<ModuleChanger, Type> ReplaceModules { get; }
}
