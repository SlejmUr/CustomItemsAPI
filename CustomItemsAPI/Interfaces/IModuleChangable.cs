namespace CustomItemsAPI.Interfaces;

public interface IModuleChangable
{
    public Dictionary<Type, Type> ReplaceModules { get; }
}
