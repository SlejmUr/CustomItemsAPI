namespace CustomItemsAPI.Helpers;

public class ModuleChanger
{
    public Type ModuleType;
    public int ChildId = -1;
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
