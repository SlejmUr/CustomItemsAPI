using CommandSystem;
using Utils;

namespace CustomItemsAPI.Commands;

[CommandHandler(typeof(CI_Command))]
public sealed class GiveCommand : ICommand, IUsageProvider
{
    public string Command => "give";

    public string[] Aliases => ["give"];

    public string Description => "Give item to player(s)";

    public string[] Usage => ["%player%", "itemname"];

    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
    {
        if (!sender.CheckPermission(PlayerPermissions.GivingItems, out response))
        {
            return false;
        }
        if (arguments.Count < 2)
        {
            response = "To execute this command provide at least 2 arguments!\nUsage: " + arguments.Array[0] + " " + this.DisplayCommandUsage();
            return false;
        }
        List<ReferenceHub> list = RAUtils.ProcessPlayerIdOrNamesList(arguments, 0, out string[] array, false);
        if (list == null)
        {
            response = "Playerlist is null!";
            return false;
        }
        if (array == null || array.Length == 0)
        {
            response = "You must specify ItemName to give.";
            return false;
        }
        string itemname = array[0];
        if (!CustomItems.IsItemNameExist(itemname))
        {
            response = "ItemName not exists!";
            return false;
        }
        foreach (var item in list)
        {
            var customitem = CustomItems.CreateItem(itemname);
            if (customitem != null)
                CustomItems.AddCustomItem(customitem, item);
        }
        response = "Done!";
        return true;
    }
}
