using CommandSystem;

namespace CustomItemsAPI.Commands;

[CommandHandler(typeof(CustomItemsCommandBase))]
public sealed class ListCommand : ICommand
{
    public string Command => "list";

    public string[] Aliases => ["ls"];

    public string Description => "List all available custom items";

    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
    {
        response = "\n--- Available Custom Items: ---\n";
        foreach (var item in CustomItems.CustomItemBaseList)
        {
            response += $" {item.CustomItemName}\t{item.Description}\n";
        }
        response += "--- Currently Existing items and its id: ---\n";
        foreach (var item in CustomItems.SerialToCustomItem)
        {
            response += $" {item.Key} = {item.Value.CustomItemName}\n";
        }
        return true;
    }
}
