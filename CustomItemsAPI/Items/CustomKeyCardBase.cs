using CustomItemsAPI.Helpers;
using Interactables.Interobjects.DoorUtils;
using LabApi.Features.Wrappers;

namespace CustomItemsAPI.Items;

/// <summary>
/// Custom Item Base for <see cref="ItemCategory.Keycard"/>
/// </summary>
public abstract class CustomKeyCardBase : CustomItemBase
{
    /// <summary>
    /// Sets the permissions for custom keycard.
    /// </summary>
    public abstract KeycardPermissions Permissions { get; }

    /// <inheritdoc/>
    public override void Parse(Item item)
    {
        base.Parse(item);
        if (item.Category != ItemCategory.Keycard)
                throw new ArgumentOutOfRangeException("Type", item.Type, "Invalid Keycard type.");
        if (item is not KeycardItem keycard)
            throw new ArgumentException("keycard must not be null!");
        keycard.Base.Permissions = Permissions;
    }

    public virtual void OnInteractingDoor(Player player, Door door, TypeWrapper<bool> canOpen, TypeWrapper<bool> isAllowed)
    {

    }

    public virtual void OnInteractedDoor(Player player, Door door, bool canOpen)
    {

    }

    public virtual void OnInteractingGenerator(Player player, Generator generator, TypeWrapper<bool> isAllowed)
    {

    }

    public virtual void OnInteractedGenerator(Player player, Generator generator)
    {

    }

    public virtual void OnInteractingLocker(Player player, Locker locker, LockerChamber lockerChamber, TypeWrapper<bool> canOpen, TypeWrapper<bool> isAllowed)
    {

    }

    public virtual void OnInteractedLocker(Player player, Locker locker, LockerChamber lockerChamber, bool canOpen)
    {

    }
}
