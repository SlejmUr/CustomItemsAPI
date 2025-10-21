using CustomItemsAPI.Items;
using InventorySystem.Items.Firearms.Modules.Scp127;
using LabApi.Features.Wrappers;

namespace CustomItemsAPI.Events;

public static class CustomScp127Events
{
    public static event Action<CustomScp127Base, Scp127Firearm, float>? GainExperience;
    public static event Action<CustomScp127Base, Scp127Firearm, TypeWrapper<float>, TypeWrapper<bool>>? GainingExperience;
    public static event Action<CustomScp127Base, Scp127Firearm, Scp127Tier>? LevelUp;
    public static event Action<CustomScp127Base, Scp127Firearm, Scp127Tier, TypeWrapper<bool>>? LevellingUp;
    public static event Action<CustomScp127Base, Scp127Firearm, Scp127VoiceLinesTranslation, Scp127VoiceTriggerBase.VoiceLinePriority>? Talked;
    public static event Action<CustomScp127Base, Scp127Firearm, TypeWrapper<Scp127VoiceLinesTranslation>, TypeWrapper<Scp127VoiceTriggerBase.VoiceLinePriority>, TypeWrapper<bool>>? Talking;

    public static void OnGainExperience(CustomScp127Base custom, Scp127Firearm scp127Firearm, float experienceGain)
        => GainExperience?.Invoke(custom, scp127Firearm, experienceGain);
    public static void OnGainingExperience(CustomScp127Base custom, Scp127Firearm scp127Firearm, TypeWrapper<float> experienceGain, TypeWrapper<bool> isAllowed)
        => GainingExperience?.Invoke(custom, scp127Firearm, experienceGain, isAllowed);
    public static void OnLevelUp(CustomScp127Base custom, Scp127Firearm scp127Firearm, Scp127Tier tier)
        => LevelUp?.Invoke(custom, scp127Firearm, tier);
    public static void OnLevellingUp(CustomScp127Base custom, Scp127Firearm scp127Firearm, Scp127Tier tier, TypeWrapper<bool> isAllowed)
        => LevellingUp?.Invoke(custom, scp127Firearm, tier, isAllowed);
    public static void OnTalked(CustomScp127Base custom, Scp127Firearm scp127Firearm, Scp127VoiceLinesTranslation voiceLine, Scp127VoiceTriggerBase.VoiceLinePriority priority)
        => Talked?.Invoke(custom, scp127Firearm, voiceLine, priority);
    public static void OnTalking(CustomScp127Base custom, Scp127Firearm scp127Firearm, TypeWrapper<Scp127VoiceLinesTranslation> voiceLine, TypeWrapper<Scp127VoiceTriggerBase.VoiceLinePriority> priority, TypeWrapper<bool> isAllowed)
        => Talking?.Invoke(custom, scp127Firearm, voiceLine, priority, isAllowed);
}

