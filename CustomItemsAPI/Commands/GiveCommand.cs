using CommandSystem;
using Utils;

namespace CustomItemsAPI.Commands;

/// <summary>
/// Command for giving custom item to the player.
/// </summary>
[CommandHandler(typeof(CustomItemsCommandBase))]
public sealed class GiveCommand : ICommand, IUsageProvider
{
    /// <inheritdoc/>
    public string Command => "give";

    /// <inheritdoc/>
    public string[] Aliases => ["give"];

    /// <inheritdoc/>
    public string Description => "Give item to player(s)";

    /// <inheritdoc/>
    public string[] Usage => ["%player%", "itemname"];

    /// <inheritdoc/>
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
        StringComparison comparison = Main.Instance.Config.EasyCompare ?  StringComparison.InvariantCulture : StringComparison.InvariantCultureIgnoreCase;
        if (!CustomItems.IsItemNameExist(itemname, comparison))
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
