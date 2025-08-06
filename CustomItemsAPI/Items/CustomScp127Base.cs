using CustomItemsAPI.Helpers;
using InventorySystem.Items.Firearms.Modules.Scp127;
using LabApi.Features.Wrappers;

namespace CustomItemsAPI.Items;

/// <summary>
/// Custom <see cref="Scp127Firearm"/> base.
/// </summary>
public abstract class CustomScp127Base : CustomFirearmBase
{
    /// <inheritdoc/>
    public override void Parse(Item item)
    {
        base.Parse(item);
        if (item is not Scp127Firearm)
            throw new ArgumentException("scp127Firearm must not be null!");
    }

    /// <summary>
    /// The <paramref name="scp127Firearm"/> that gaining <paramref name="experienceGain"/> amount of experience.
    /// </summary>
    /// <param name="scp127Firearm">The <see cref="Scp127Firearm"/></param>
    /// <param name="experienceGain">How many experience gained</param>
    /// <param name="isAllowed">Can allow this action.</param>
    public virtual void OnGainingExperience(Scp127Firearm scp127Firearm, TypeWrapper<float> experienceGain, TypeWrapper<bool> isAllowed)
    {
        CL.Debug($"OnGainingExperience {scp127Firearm.Serial} {experienceGain.Value}", Main.Instance.Config.Debug);
    }

    /// <summary>
    /// The <paramref name="scp127Firearm"/> that gained <paramref name="experienceGain"/> amount of experience.
    /// </summary>
    /// <param name="scp127Firearm">The <see cref="Scp127Firearm"/></param>
    /// <param name="experienceGain">How many experience gained</param>
    public virtual void OnGainExperience(Scp127Firearm scp127Firearm, float experienceGain)
    {
        CL.Debug($"OnGainExperience {scp127Firearm.Serial} {experienceGain}", Main.Instance.Config.Debug);
    }


    /// <summary>
    /// The <paramref name="scp127Firearm"/> that leveling up to tier <paramref name="tier"/>.
    /// </summary>
    /// <param name="scp127Firearm">The <see cref="Scp127Firearm"/> item</param>
    /// <param name="tier">The <see cref="Scp127Tier"/> to level up</param>
    /// <param name="isAllowed">Can allow this action.</param>
    public virtual void OnLevellingUp(Scp127Firearm scp127Firearm, Scp127Tier tier, TypeWrapper<bool> isAllowed)
    {
        CL.Debug($"OnLevellingUp {scp127Firearm.Serial} {tier}", Main.Instance.Config.Debug);
    }

    /// <summary>
    /// The <paramref name="scp127Firearm"/> that leveled up to tier <paramref name="tier"/>.
    /// </summary>
    /// <param name="scp127Firearm">The <see cref="Scp127Firearm"/> item</param>
    /// <param name="tier">The <see cref="Scp127Tier"/> to level up</param>
    public virtual void OnLevelUp(Scp127Firearm scp127Firearm, Scp127Tier tier)
    {
        CL.Debug($"OnLevelUp {scp127Firearm.Serial} {tier}", Main.Instance.Config.Debug);
    }

    /// <summary>
    /// The <paramref name="scp127Firearm"/> that talking.
    /// </summary>
    /// <param name="scp127Firearm">The <see cref="Scp127Firearm"/></param>
    /// <param name="voiceLine">The <see cref="Scp127VoiceLinesTranslation"/> will play.</param>
    /// <param name="priority">The voice line <see cref="Scp127VoiceTriggerBase.VoiceLinePriority"/>.</param>
    /// <param name="isAllowed">Can allow this action.</param>
    public virtual void OnTalking(Scp127Firearm scp127Firearm, TypeWrapper<Scp127VoiceLinesTranslation> voiceLine, TypeWrapper<Scp127VoiceTriggerBase.VoiceLinePriority> priority, TypeWrapper<bool> isAllowed)
    {
        CL.Debug($"OnTalking {scp127Firearm.Serial} {voiceLine.Value} {priority.Value}", Main.Instance.Config.Debug);
    }

    /// <summary>
    /// The <paramref name="scp127Firearm"/> that talked.
    /// </summary>
    /// <param name="scp127Firearm">The <see cref="Scp127Firearm"/></param>
    /// <param name="voiceLine">The <see cref="Scp127VoiceLinesTranslation"/> will play.</param>
    /// <param name="priority">The voice line <see cref="Scp127VoiceTriggerBase.VoiceLinePriority"/>.</param>
    public virtual void OnTalked(Scp127Firearm scp127Firearm, Scp127VoiceLinesTranslation voiceLine, Scp127VoiceTriggerBase.VoiceLinePriority priority)
    {
        CL.Debug($"OnTalked {scp127Firearm.Serial} {voiceLine} {priority}", Main.Instance.Config.Debug);
    }
}
