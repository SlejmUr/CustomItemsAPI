using CustomItemsAPI.Helpers;
using CustomItemsAPI.Items;
using InventorySystem.Items.Firearms;
using InventorySystem.Items.Firearms.Modules.Scp127;
using LabApi.Events.Arguments.Scp127Events;
using LabApi.Events.CustomHandlers;
using LabApi.Features.Wrappers;

namespace CustomItemsAPI.EventHandlers;

internal sealed class Scp127Handler : CustomEventsHandler
{
    public override void OnScp127GainingExperience(Scp127GainingExperienceEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.Scp127Item, out CustomScp127Base cur_item))
            return;
        TypeWrapper<bool> isAllowed = new(ev.IsAllowed);
        TypeWrapper<float> experienceGain = new(ev.ExperienceGain);
        cur_item.OnGainingExperience(ev.Scp127Item, experienceGain, isAllowed);
        ev.IsAllowed = isAllowed.Value;
        ev.ExperienceGain = experienceGain.Value;
    }

    public override void OnScp127GainExperience(Scp127GainExperienceEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.Scp127Item, out CustomScp127Base cur_item))
            return;
        cur_item.OnGainExperience(ev.Scp127Item, ev.ExperienceGain);
    }

    public override void OnScp127LevellingUp(Scp127LevellingUpEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.Scp127Item, out CustomScp127Base cur_item))
            return;
        TypeWrapper<bool> isAllowed = new(ev.IsAllowed);
        TypeWrapper<Scp127Tier> tier = new(ev.Tier);
        cur_item.OnLevellingUp(ev.Scp127Item, tier, isAllowed);
        ev.IsAllowed = isAllowed.Value;
        ev.Tier = tier.Value;
    }

    public override void OnScp127LevelUp(Scp127LevelUpEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.Scp127Item, out CustomScp127Base cur_item))
            return;
        cur_item.OnLevelUp(ev.Scp127Item, ev.Tier);
    }

    public override void OnScp127Talking(Scp127TalkingEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.Scp127Item, out CustomScp127Base cur_item))
            return;
        TypeWrapper<bool> isAllowed = new(ev.IsAllowed);
        TypeWrapper<Scp127VoiceLinesTranslation> voiceLine = new(ev.VoiceLine);
        TypeWrapper<Scp127VoiceTriggerBase.VoiceLinePriority> priority = new(ev.Priority);
        cur_item.OnTalking(ev.Scp127Item, voiceLine, priority, isAllowed);
        ev.IsAllowed = isAllowed.Value;
        ev.VoiceLine = voiceLine.Value;
        ev.Priority = priority.Value;
    }

    public override void OnScp127Talked(Scp127TalkedEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.Scp127Item, out CustomScp127Base cur_item))
            return;
        cur_item.OnTalked(ev.Scp127Item, ev.VoiceLine, ev.Priority);
    }
}