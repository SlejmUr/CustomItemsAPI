﻿using CommandSystem;
using LabApi.Features.Wrappers;
using UnityEngine;
using Utils;

namespace CustomItemsAPI.Commands;

/// <summary>
/// Command for spawning custom item to the player.
/// </summary>
[CommandHandler(typeof(CustomItemsCommandBase))]
public sealed class SpawnCommand : ICommand, IUsageProvider
{
    /// <inheritdoc/>
    public string Command => "spawn";

    /// <inheritdoc/>
    public string[] Aliases => ["spawn"];

    /// <inheritdoc/>
    public string Description => "Spawn custom item";

    /// <inheritdoc/>
    public string[] Usage => ["itemname", "x", "y", "z"];

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
        string itemname = arguments.At(0);
        StringComparison comparison = Main.Instance.Config.EasyCompare ?  StringComparison.InvariantCulture : StringComparison.InvariantCultureIgnoreCase;
        if (!CustomItems.IsItemNameExist(itemname, comparison))
        {
            response = "ItemName not exists!";
            return false;
        }
        if (!float.TryParse(arguments.At(1), out float x))
        {
            response = "Spawn coordinate is wrong! (X)";
            return false;
        }
        if (!float.TryParse(arguments.At(2), out float y))
        {
            response = "Spawn coordinate is wrong! (Y)";
            return false;
        }
        if (!float.TryParse(arguments.At(3), out float z))
        {
            response = "Spawn coordinate is wrong! (Z)";
            return false;
        }
        var customitem = CustomItems.CreateItem(itemname);
        if (customitem == null)
        {
            response = "Item creation failed!";
            return false;
        }
        var pickup = CustomItems.Spawn(customitem, new Vector3(x, y, z));
        response = $"Done!";
        return true;
    }
}
