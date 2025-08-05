using CustomItemsAPI.Classes;
using CustomItemsAPI.Helpers;
using CustomItemsAPI.Interfaces;
using InventorySystem.Items.Firearms;
using InventorySystem.Items.Firearms.Modules;
using LabApi.Features.Wrappers;
using LabApiExtensions.Configs;
using LabApiExtensions.Managers;
using PlayerStatsSystem;

namespace CustomItemsAPI.Items;

/// <summary>
/// Custom <see cref="FirearmItem"/> base.
/// </summary>
public abstract class CustomFirearmBase : CustomItemBase, IModuleChangable
{
    /// <inheritdoc/>
    public virtual Dictionary<ModuleChanger, Type> ReplaceModules { get; } = [];

    /// <inheritdoc/>
    public virtual List<ModuleChanger> AddModules { get; } = [];

    /// <summary>
    /// The <see cref="FirearmItem"/>'s Damage.
    /// </summary>
    public virtual MathValueFloat Damage { get; } = new();

    /// <summary>
    /// Changer for <see cref="A7BurnEffectModule"/>.
    /// </summary>
    public virtual A7Burn A7Burn { get; } = new();

    /// <inheritdoc/>
    public override void Parse(Item item)
    {
        base.Parse(item);
        if (item is not FirearmItem firearmItem)
            throw new ArgumentException("FirearmItem must not be null!");
        if (TryGetModule(firearmItem, out A7BurnEffectModule a7BurnEffectModule))
            A7Burn.Apply(ref a7BurnEffectModule);
    }

    /// <summary>
    /// Trying to get a <see cref="FirearmSubcomponentBase"/> from a <see cref="Firearm"/>.
    /// </summary>
    /// <typeparam name="T">Any <see cref="FirearmSubcomponentBase"/>.</typeparam>
    /// <param name="firearm"></param>
    /// <param name="module">The Module <see cref="FirearmSubcomponentBase"/></param>
    /// <param name="ignoreSubmodules">Ignore weapon SubModules.</param>
    /// <returns>True if the <paramref name="module"/> found otherwise false.</returns>
    public bool TryGetModule<T>(FirearmItem firearm, out T module, bool ignoreSubmodules = true) where T : FirearmSubcomponentBase
    {
        return firearm.Base.TryGetModule(out module, ignoreSubmodules);
    }

    /// <summary>
    /// This <paramref name="player"/> who aimed.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="weapon">The weapon</param>
    /// <param name="aiming">Is aiming or not</param>
    public virtual void OnAim(Player player, FirearmItem weapon, bool aiming)
    {
        CL.Debug($"OnAim {player.PlayerId} {weapon.Serial} {aiming}", Main.Instance.Config.Debug);
    }

    /// <summary>
    /// This <paramref name="player"/> who dry fired.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="weapon">The weapon</param>
    public virtual void OnDryFired(Player player, FirearmItem weapon)
    {
        CL.Debug($"OnDryFired {player.PlayerId} {weapon.Serial}", Main.Instance.Config.Debug);
    }

    /// <summary>
    /// This <paramref name="player"/> who dry firing.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="weapon">The weapon</param>
    /// <param name="isAllowedHelper">Can allow this action.</param>
    public virtual void OnDryFiring(Player player, FirearmItem weapon, TypeWrapper<bool> isAllowedHelper)
    {
        CL.Debug($"OnDryFiring {player.PlayerId} {weapon.Serial}", Main.Instance.Config.Debug);
    }

    /// <summary>
    /// This <paramref name="player"/> who reloaded.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="weapon">The weapon</param>
    public virtual void OnReloaded(Player player, FirearmItem weapon)
    {
        CL.Debug($"OnReloaded {player.PlayerId} {weapon.Serial}", Main.Instance.Config.Debug);
    }

    /// <summary>
    /// This <paramref name="player"/> who reloading.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="weapon">The weapon</param>
    /// <param name="isAllowedHelper">Can allow this action.</param>
    public virtual void OnReloading(Player player, FirearmItem weapon, TypeWrapper<bool> isAllowedHelper)
    {
        CL.Debug($"OnReloading {player.PlayerId} {weapon.Serial}", Main.Instance.Config.Debug);
    }

    /// <summary>
    /// This <paramref name="player"/> who shooting.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="weapon">The weapon</param>
    /// <param name="isAllowedHelper">Can allow this action.</param>
    public virtual void OnShooting(Player player, FirearmItem weapon, TypeWrapper<bool> isAllowedHelper)
    {
        CL.Debug($"OnShooting {player.PlayerId} {weapon.Serial}", Main.Instance.Config.Debug);
    }

    /// <summary>
    /// This <paramref name="player"/> who shot.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="weapon">The weapon</param>
    public virtual void OnShot(Player player, FirearmItem weapon)
    {
        CL.Debug($"OnShot {player.PlayerId} {weapon.Serial}", Main.Instance.Config.Debug);
    }

    /// <summary>
    /// This <paramref name="player"/> who toggled the flashlight.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="weapon">The weapon</param>
    /// <param name="newState">State of flashlight</param>
    public virtual void OnToggledFlashlight(Player player, FirearmItem weapon, bool newState)
    {
        CL.Debug($"OnToggledFlashlight {player.PlayerId} {weapon.Serial} {newState}", Main.Instance.Config.Debug);
    }

    /// <summary>
    /// This <paramref name="player"/> who toggling the flashlight.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="weapon">The weapon</param>
    /// <param name="newState">State of flashlight</param>
    /// <param name="isAllowedHelper">Can allow this action.</param>
    public virtual void OnTogglingFlashlight(Player player, FirearmItem weapon, TypeWrapper<bool> newState, TypeWrapper<bool> isAllowedHelper)
    {
        CL.Debug($"OnAim {player.PlayerId} {weapon.Serial} {newState.Value}", Main.Instance.Config.Debug);
    }

    /// <summary>
    /// This <paramref name="player"/> who unloaded.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="weapon">The weapon</param>
    public virtual void OnUnloaded(Player player, FirearmItem weapon)
    {
        CL.Debug($"OnUnloaded {player.PlayerId} {weapon.Serial}", Main.Instance.Config.Debug);
    }

    /// <summary>
    /// This <paramref name="player"/> who unloading.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="weapon">The weapon</param>
    /// <param name="isAllowedHelper">Can allow this action.</param>
    public virtual void OnUnloading(Player player, FirearmItem weapon, TypeWrapper<bool> isAllowedHelper)
    {
        CL.Debug($"OnUnloading {player.PlayerId} {weapon.Serial}", Main.Instance.Config.Debug);
    }

    /// <summary>
    /// This <paramref name="player"/> who got hurt.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="attacker">The Player who attacker the <paramref name="player"/></param>
    /// <param name="firearmDamage">Firearm Damage</param>
    /// <param name="isAllowedHelper">Can allow this action.</param>
    public virtual void OnHurting(Player player, Player attacker, FirearmDamageHandler firearmDamage, TypeWrapper<bool> isAllowedHelper)
    {
        CL.Debug($"OnHurting (Before) {player.PlayerId} {attacker.PlayerId} {firearmDamage.Damage}", Main.Instance.Config.Debug);
        firearmDamage.Damage = Damage.MathCalculation(firearmDamage.Damage);
        CL.Debug($"OnHurting (After) {player.PlayerId} {attacker.PlayerId} {firearmDamage.Damage}", Main.Instance.Config.Debug);
    }

    /// <summary>
    /// This <paramref name="player"/> who got hurt.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="attacker">The Player who attacker the <paramref name="player"/></param>
    /// <param name="firearmDamage">Firearm Damage</param>
    public virtual void OnHurt(Player player, Player attacker, FirearmDamageHandler firearmDamage)
    {
        CL.Debug($"OnHurt {player.PlayerId} {attacker.PlayerId} {firearmDamage.Damage}", Main.Instance.Config.Debug);
    }

    /// <summary>
    /// This <paramref name="player"/> changing <paramref name="firearmItem"/> attachment from <paramref name="oldAttachments"/> to <paramref name="newState"/>.
    /// </summary>
    /// <param name="player"></param>
    /// <param name="firearmItem"></param>
    /// <param name="oldAttachments"></param>
    /// <param name="newState"></param>
    /// <param name="isAllowedHelper"></param>
    public virtual void OnChangingAttachments(Player player, FirearmItem firearmItem, uint oldAttachments, TypeWrapper<uint> newState, TypeWrapper<bool> isAllowedHelper)
    {
        CL.Debug($"OnChangedAttachments {player.PlayerId} {firearmItem.Serial} {oldAttachments} {newState.Value}", Main.Instance.Config.Debug);
    }

    /// <summary>
    /// This <paramref name="player"/> changed <paramref name="firearmItem"/> attachment from <paramref name="oldAttachments"/> to <paramref name="newAttachments"/>.
    /// </summary>
    /// <param name="player"></param>
    /// <param name="firearmItem"></param>
    /// <param name="oldAttachments"></param>
    /// <param name="newAttachments"></param>
    public virtual void OnChangedAttachments(Player player, FirearmItem firearmItem, uint oldAttachments, uint newAttachments)
    {
        CL.Debug($"OnChangedAttachments {player.PlayerId} {firearmItem.Serial} {oldAttachments} {newAttachments}", Main.Instance.Config.Debug);
    }
}
