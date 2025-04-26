using CustomItemsAPI.Helpers;
using Interactables.Interobjects.DoorUtils;
using LabApi.Features.Wrappers;

namespace CustomItemsAPI.Items;

/// <summary>
/// Custom Item Base for <see cref="ItemCategory.Keycard"/>.
/// </summary>
public abstract class CustomKeyCardBase : CustomItemBase
{
    /// <summary>
    /// Sets the permissions for custom keycard.
    /// </summary>
    public abstract KeycardLevels Levels { get; }

    /// <inheritdoc/>
    public override void Parse(Item item)
    {
        base.Parse(item);
        if (item.Category != ItemCategory.Keycard)
                throw new ArgumentOutOfRangeException("Type", item.Type, "Invalid Keycard type.");
        if (item is not KeycardItem keycard)
            throw new ArgumentException("keycard must not be null!");
        keycard.Base.KeycardGfx.SetPermissions(Levels);
    }

    /// <summary>
    /// Called when <paramref name="player"/> is interacting with the <paramref name="door"/>.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="door">The <see cref="Door"/> the <paramref name="player"/> interacting.</param>
    /// <param name="canOpen">Can the <paramref name="player"/> open the <paramref name="door"/>.</param>
    /// <param name="isAllowed">Can allow this action.</param>
    public virtual void OnInteractingDoor(Player player, Door door, TypeWrapper<bool> canOpen, TypeWrapper<bool> isAllowed)
    {

    }

    /// <summary>
    /// Called when <paramref name="player"/> is interacted with the <paramref name="door"/>.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="door">The <see cref="Door"/> the <paramref name="player"/> interacted.</param>
    /// <param name="canOpen">The <paramref name="player"/> can open the <paramref name="door"/>.</param>
    public virtual void OnInteractedDoor(Player player, Door door, bool canOpen)
    {

    }

    /// <summary>
    /// Called when <paramref name="player"/> is interacting with the <paramref name="generator"/>.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="generator">The <see cref="Generator"/> the <paramref name="player"/> interacting.</param>
    /// <param name="isAllowed">Can allow this action.</param>
    public virtual void OnInteractingGenerator(Player player, Generator generator, TypeWrapper<bool> isAllowed)
    {

    }

    /// <summary>
    /// Called when <paramref name="player"/> is interacted with the <paramref name="generator"/>.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="generator">The <see cref="Generator"/> the <paramref name="player"/> interacted.</param>
    public virtual void OnInteractedGenerator(Player player, Generator generator)
    {

    }

    /// <summary>
    /// Called when <paramref name="player"/> is interacting with the <paramref name="locker"/>.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="locker">The <see cref="Locker"/> the <paramref name="player"/> interacting.</param>
    /// <param name="lockerChamber">The targeted <see cref="LockerChamber"/>.</param>
    /// <param name="canOpen">Can the <paramref name="player"/> open the <paramref name="locker"/>.</param>
    /// <param name="isAllowed">Can allow this action.</param>
    public virtual void OnInteractingLocker(Player player, Locker locker, LockerChamber lockerChamber, TypeWrapper<bool> canOpen, TypeWrapper<bool> isAllowed)
    {

    }

    /// <summary>
    /// Called when <paramref name="player"/> is interacted with the <paramref name="locker"/>.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="locker">The <see cref="Locker"/> the <paramref name="player"/> interacted.</param>
    /// <param name="lockerChamber">The targeted <see cref="LockerChamber"/>.</param>
    /// <param name="canOpen">The <paramref name="player"/> can open the <paramref name="locker"/>.</param>
    public virtual void OnInteractedLocker(Player player, Locker locker, LockerChamber lockerChamber, bool canOpen)
    {

    }
}
