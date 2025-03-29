using LabApi.Events.CustomHandlers;

namespace CustomItemsAPI.EventHandlers;

internal sealed class NonItemRelatedHandler : CustomEventsHandler
{
    public override void OnServerWaitingForPlayers()
    {
        CustomItems.ClearSerials();
    }
}
