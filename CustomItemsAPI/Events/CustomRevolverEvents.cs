using CustomItemsAPI.Items;
using LabApi.Features.Wrappers;

namespace CustomItemsAPI.Events;

public static class CustomRevolverEvents
{
    public static event Action<CustomRevolverBase, Player, RevolverFirearm>? Spinned;
    public static event Action<CustomRevolverBase, Player, RevolverFirearm, TypeWrapper<bool>>? Spinning;

    public static void OnSpinned(CustomRevolverBase custom, Player player, RevolverFirearm revolver)
        => Spinned?.Invoke(custom, player, revolver);

    public static void OnSpinning(CustomRevolverBase custom, Player player, RevolverFirearm revolver, TypeWrapper<bool> isAllowed)
        => Spinning?.Invoke(custom, player, revolver, isAllowed);
}
