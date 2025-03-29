using LabApi.Loader.Features.Plugins;
using LabApi.Events.CustomHandlers;
using CustomItemsAPI.EventHandlers;
using InventorySystem;
using InventorySystem.Items.ThrowableProjectiles;
using InventorySystem.Items.Firearms;

namespace CustomItemsAPI;

internal sealed class Main : Plugin
{
    public Main Instance;
    public override string Name => "CustomItemsAPI";

    public override string Description => "Enabling creating custom items";

    public override string Author => "SlejmUr";

    public override Version Version => new(0, 0, 1, 0);

    public override Version RequiredApiVersion => LabApi.Features.LabApiProperties.CurrentVersion;

    private CommonItemHandler CommonItemHandler;
    private KeyCardItemHandler KeyCardItemHandler;
    private NonItemRelatedHandler NonItemRelatedHandler;
    private UsableItemHandler UsableItemHandler;
    private ThrowableItemHandler ThrowableItemHandler;

    public override void Disable()
    {
        Instance = null;
        CustomHandlersManager.UnregisterEventsHandler(CommonItemHandler);
        CommonItemHandler = null;
        CustomHandlersManager.UnregisterEventsHandler(KeyCardItemHandler);
        KeyCardItemHandler = null;
        CustomHandlersManager.UnregisterEventsHandler(NonItemRelatedHandler);
        NonItemRelatedHandler = null;
        CustomHandlersManager.UnregisterEventsHandler(UsableItemHandler);
        UsableItemHandler = null;
        CustomHandlersManager.UnregisterEventsHandler(ThrowableItemHandler);
        ThrowableItemHandler = null;
        InventoryExtensions.OnItemRemoved -= Subscribed.OnItemRemoved;
        ThrownProjectile.OnProjectileSpawned -= Subscribed.ProjectileSpawned;
        CustomItems.UnRegisterAllCustomItems();
    }

    public override void Enable()
    {
        Instance = this;
        CommonItemHandler = new();
        CustomHandlersManager.RegisterEventsHandler(CommonItemHandler);
        KeyCardItemHandler = new();
        CustomHandlersManager.RegisterEventsHandler(KeyCardItemHandler);
        NonItemRelatedHandler = new();
        CustomHandlersManager.RegisterEventsHandler(NonItemRelatedHandler);
        UsableItemHandler = new();
        CustomHandlersManager.RegisterEventsHandler(UsableItemHandler);
        ThrowableItemHandler = new();
        CustomHandlersManager.RegisterEventsHandler(ThrowableItemHandler);
        InventoryExtensions.OnItemRemoved += Subscribed.OnItemRemoved;
        ThrownProjectile.OnProjectileSpawned += Subscribed.ProjectileSpawned;
        CustomItems.RegisterCustomItems();
        
        foreach (var item in InventoryItemLoader.AvailableItems)
        {
            CL.Info($"ItemType: {item.Key} Base type: {item.Value.GetType()}");

            if (item.Value is Firearm firearm && firearm != null)
            {
                foreach (var module in firearm.Modules)
                {
                    CL.Info($"FireArmModule: IsSubmodule: {module.IsSubmodule} Type: {module.GetType()}  UniqueComponentId: {module.UniqueComponentId}");
                }
            }
        }
        
    }
}
