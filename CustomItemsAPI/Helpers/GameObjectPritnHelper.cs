using UnityEngine;

namespace CustomItemsAPI.Helpers;

public static class GameObjectPritnHelper
{
    public static string PrintComponentTree(this GameObject @object)
    {
        return "\n" + DeepLayersPrint(@object, 0);
    }

    public static string DeepLayersPrint(this GameObject @object, int level)
    {
        string log = string.Empty;
        foreach (var item in @object.GetComponents(typeof(Component)))
        {
            log += $"{string.Join(" ", Enumerable.Repeat("\t", level))}{item}\n";
        }
        for (int i = 0; i < @object.transform.childCount; i++)
        {
            var child = @object.transform.GetChild(i);
            log += $"{string.Join(" ", Enumerable.Repeat("\t", level))}{child}\n";
            log += DeepLayersPrint(child.gameObject, level + 1);
        }
        return log;
    }
}
