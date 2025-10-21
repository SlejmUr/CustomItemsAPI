using CustomItemsAPI.Items;
using InventorySystem.Items.MicroHID.Modules;
using LabApi.Features.Wrappers;

namespace CustomItemsAPI.Events;

public static class CustomMicroHIDEvents
{
    public static event Action<CustomMicroHIDBase, MicroHIDItem, MicroHidPhase>? PhaseChanged;
    public static event Action<CustomMicroHIDBase, MicroHIDItem>? Broken;

    public static void OnPhaseChanged(CustomMicroHIDBase customMicro, MicroHIDItem microHIDItem, MicroHidPhase phase)
        => PhaseChanged?.Invoke(customMicro, microHIDItem, phase);

    public static void OnBroken(CustomMicroHIDBase customMicro, MicroHIDItem microHIDItem)
        => Broken?.Invoke(customMicro, microHIDItem);
}
