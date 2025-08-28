using LabApi.Events.CustomHandlers;
using MEC;

namespace CustomItemsAPI.EventHandlers;

internal sealed class NonItemRelatedHandler : CustomEventsHandler
{
    public override void OnServerWaitingForPlayers()
    {
        CustomItems.ClearSerials();
        Timing.CallDelayed(3, () =>
        {
            // Map should be generated at this point
            foreach (var item in CustomItems.CustomItemBaseList)
            {
                item.OnDistribute();
            }
        });
    }
}
