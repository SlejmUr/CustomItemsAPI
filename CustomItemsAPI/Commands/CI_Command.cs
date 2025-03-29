using CommandSystem;

namespace CustomItemsAPI.Commands;

[CommandHandler(typeof(RemoteAdminCommandHandler))]
public sealed class CI_Command : ParentCommand, IUsageProvider
{
    public override string Command => "lci";

    public override string[] Aliases => ["labapicustomitems"];

    public override string Description => "Interacting with Custom Items";

    public string[] Usage => ["give/list", "%player% ItemName"];


    public override void LoadGeneratedCommands()
    {
        RegisterCommand(new GiveCommand());
        RegisterCommand(new ListCommand());
    }

    protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
    {
        response = $"Please specify a valid subcommand!\n- {Command} list\n- {Command} give %player% ItemName";
        return false;
    }

}
