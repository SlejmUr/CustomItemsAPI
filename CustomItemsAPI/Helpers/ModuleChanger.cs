namespace CustomItemsAPI.Helpers;

public class ModuleChanger
{
    /// <summary>
    /// The Module Type to replace from.
    /// </summary>
    public Type ModuleType;
    /// <summary>
    /// The Child Id that the Module is in.
    /// </summary>
    public int ChildId = -1;
    /// <summary>
    /// The Child Name that the Module is in.
    /// </summary>
    public string ChildName;

    public ModuleChanger()
    {

    }

    public ModuleChanger(Type moduleType, int childId)
    {
        ModuleType = moduleType;
        ChildId = childId;
    }

    public ModuleChanger(Type moduleType, string childName)
    {
        ModuleType = moduleType;
        ChildName = childName;
    }

    public ModuleChanger(Type moduleType, int childId, string childName)
    {
        ModuleType = moduleType;
        ChildId = childId;
        ChildName = childName;
    }
}
