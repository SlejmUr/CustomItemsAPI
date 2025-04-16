using CustomItemsAPI.Helpers;

namespace CustomItemsAPI.Interfaces;

public interface IModuleChangable
{
    /// <summary>
    /// Modules to replace the Base to our Custom One. (ONLY CUSTOM!)
    /// </summary>
    public Dictionary<ModuleChanger, Type> ReplaceModules { get; }

    public List<ModuleChanger> AddModules { get; }
}
