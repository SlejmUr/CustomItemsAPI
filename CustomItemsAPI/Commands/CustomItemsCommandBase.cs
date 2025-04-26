using CommandSystem;

namespace CustomItemsAPI.Commands;

/// <summary>
/// Parent command base for every Custom Item Command.
/// </summary>
[CommandHandler(typeof(RemoteAdminCommandHandler))]
public sealed class CustomItemsCommandBase : ParentCommand, IUsageProvider
{
    /// <inheritdoc/>
    public override string Command => "lci";

    /// <inheritdoc/>
    public override string[] Aliases => ["labapicustomitems"];

    /// <inheritdoc/>
    public override string Description => "Interacting with Custom Items";

    /// <inheritdoc/>
    public string[] Usage => ["give/list", "%player% ItemName"];

    /// <inheritdoc/>
    public override void LoadGeneratedCommands()
    {
        RegisterCommand(new GiveCommand());
        RegisterCommand(new ListCommand());
    }

    /// <inheritdoc/>
    protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
    {
        response = $"Please specify a valid subcommand!\n- {Command} list\n- {Command} give %player% ItemName";
        return false;
    }

}
