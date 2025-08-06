using CustomItemsAPI.Classes;
using CustomItemsAPI.Helpers;
using CustomItemsAPI.Interfaces;
using InventorySystem.Items.Firearms;
using InventorySystem.Items.Firearms.Modules;
using InventorySystem.Items.Firearms.Modules.Scp127;
using LabApi.Features.Wrappers;
using LabApiExtensions.Configs;
using LabApiExtensions.Managers;
using PlayerStatsSystem;

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
        if (item is not Scp127Firearm scp127Firearm)
            throw new ArgumentException("scp127Firearm must not be null!");
    }

    public virtual void OnGainingExperience(Scp127Firearm fierarm, TypeWrapper<float> experienceGain, TypeWrapper<bool> isAllowed)
    {

    }

    public virtual void OnGainExperience(Scp127Firearm fierarm, float experienceGain)
    {

    }

    public virtual void OnLevellingUp(Scp127Firearm fierarm, TypeWrapper<Scp127Tier> tier, TypeWrapper<bool> isAllowed)
    {

    }

    public virtual void OnLevelUp(Scp127Firearm fierarm, Scp127Tier tier)
    {

    }

    public virtual void OnTalking(Scp127Firearm fierarm, TypeWrapper<Scp127VoiceLinesTranslation> voiceLine, TypeWrapper<Scp127VoiceTriggerBase.VoiceLinePriority> priority, TypeWrapper<bool> isAllowed)
    {

    }

    public virtual void OnTalked(Scp127Firearm fierarm, Scp127VoiceLinesTranslation voiceLine, Scp127VoiceTriggerBase.VoiceLinePriority priority)
    {

    }

}
