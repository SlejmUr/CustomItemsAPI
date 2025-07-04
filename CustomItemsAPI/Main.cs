using LabApi.Loader.Features.Plugins;
using LabApi.Events.CustomHandlers;
using CustomItemsAPI.EventHandlers;
using InventorySystem;
using InventorySystem.Items.ThrowableProjectiles;
using InventorySystem.Items.MicroHID.Modules;
using InventorySystem.Items.Jailbird;

namespace CustomItemsAPI;

internal sealed class Main : Plugin<Config>
{
    public static Main Instance;
    public override string Name => "CustomItemsAPI";

    public override string Description => "Enabling creating custom items";

    public override string Author => "SlejmUr";

    public override Version Version => new(0, 0, 5, 5);

    public override Version RequiredApiVersion => LabApi.Features.LabApiProperties.CurrentVersion;

    private CommonItemHandler commonItemHandler = new();
    private KeyCardItemHandler keyCardItemHandler = new();
    private NonItemRelatedHandler nonItemRelatedHandler = new();
    private UsableItemHandler usableItemHandler = new();
    private ThrowableItemHandler throwableItemHandler = new();
    private DamageHandler damageHandler = new();
    private FirearmHandler firearmHandler = new();
    private Scp914Handler scp914Handler = new();

    public override void Enable()
    {
        Instance = this;
        CustomHandlersManager.RegisterEventsHandler(commonItemHandler);
        CustomHandlersManager.RegisterEventsHandler(keyCardItemHandler);
        CustomHandlersManager.RegisterEventsHandler(nonItemRelatedHandler);
        CustomHandlersManager.RegisterEventsHandler(usableItemHandler);
        CustomHandlersManager.RegisterEventsHandler(throwableItemHandler);
        CustomHandlersManager.RegisterEventsHandler(damageHandler);
        CustomHandlersManager.RegisterEventsHandler(firearmHandler);
        CustomHandlersManager.RegisterEventsHandler(scp914Handler);
        InventoryExtensions.OnItemRemoved += Subscribed.OnItemRemoved;
        ThrownProjectile.OnProjectileSpawned += Subscribed.ProjectileSpawned;
        CycleController.OnPhaseChanged += Subscribed.PhaseChanged;
        BrokenSyncModule.OnBroken += Subscribed.BrokenSyncModule_OnBroken;
        DrawAndInspectorModule.OnInspectRequested += Subscribed.DrawAndInspectorModule_OnInspectRequested;
        JailbirdItem.OnRpcReceived += Subscribed.Jailbird_OnRpcReceived;
        CustomItems.RegisterCustomItems();
    }

    public override void Disable()
    {
        Instance = null;
        CustomHandlersManager.UnregisterEventsHandler(commonItemHandler);
        commonItemHandler = null;
        CustomHandlersManager.UnregisterEventsHandler(keyCardItemHandler);
        keyCardItemHandler = null;
        CustomHandlersManager.UnregisterEventsHandler(nonItemRelatedHandler);
        nonItemRelatedHandler = null;
        CustomHandlersManager.UnregisterEventsHandler(usableItemHandler);
        usableItemHandler = null;
        CustomHandlersManager.UnregisterEventsHandler(throwableItemHandler);
        throwableItemHandler = null;
        CustomHandlersManager.UnregisterEventsHandler(damageHandler);
        damageHandler = null;
        CustomHandlersManager.UnregisterEventsHandler(firearmHandler);
        firearmHandler = null;
        CustomHandlersManager.UnregisterEventsHandler(scp914Handler);
        scp914Handler = null;
        InventoryExtensions.OnItemRemoved -= Subscribed.OnItemRemoved;
        ThrownProjectile.OnProjectileSpawned -= Subscribed.ProjectileSpawned;
        CycleController.OnPhaseChanged -= Subscribed.PhaseChanged;
        BrokenSyncModule.OnBroken -= Subscribed.BrokenSyncModule_OnBroken;
        DrawAndInspectorModule.OnInspectRequested -= Subscribed.DrawAndInspectorModule_OnInspectRequested;
        JailbirdItem.OnRpcReceived -= Subscribed.Jailbird_OnRpcReceived;
        CustomItems.UnRegisterAllCustomItems();
    }
}
