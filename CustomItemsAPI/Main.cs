using CustomItemsAPI.EventHandlers;
using InventorySystem;
using InventorySystem.Items.MicroHID.Modules;
using InventorySystem.Items.ThrowableProjectiles;
using LabApi.Events.CustomHandlers;
using LabApi.Loader.Features.Plugins;

namespace CustomItemsAPI;

internal sealed class Main : Plugin<Config>
{
    public static Main Instance;
    public override string Name => "CustomItemsAPI";

    public override string Description => "Enabling creating custom items";

    public override string Author => "SlejmUr";

    public override Version Version => new(0, 0, 6, 0);

    public override Version RequiredApiVersion => LabApi.Features.LabApiProperties.CurrentVersion;

    private CommonItemHandler commonItemHandler = new();
    private KeyCardItemHandler keyCardItemHandler = new();
    private NonItemRelatedHandler nonItemRelatedHandler = new();
    private UsableItemHandler usableItemHandler = new();
    private ThrowableItemHandler throwableItemHandler = new();
    private DamageHandler damageHandler = new();
    private FirearmHandler firearmHandler = new();
    private Scp914Handler scp914Handler = new();
    private JailbirdHandler jailbirdHandler = new();
    private RevolverHandler revolverHandler = new();
    private Scp127Handler scp127Handler = new();

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
        CustomHandlersManager.RegisterEventsHandler(jailbirdHandler);
        CustomHandlersManager.RegisterEventsHandler(revolverHandler);
        CustomHandlersManager.RegisterEventsHandler(scp127Handler);
        InventoryExtensions.OnItemRemoved += Subscribed.OnItemRemoved;
        ThrownProjectile.OnProjectileSpawned += Subscribed.ProjectileSpawned;
        CycleController.OnPhaseChanged += Subscribed.PhaseChanged;
        BrokenSyncModule.OnBroken += Subscribed.BrokenSyncModule_OnBroken;
        DrawAndInspectorModule.OnInspectRequested += Subscribed.DrawAndInspectorModule_OnInspectRequested;
        CustomItems.RegisterCustomItems();
    }

    public override void Disable()
    {
        CustomHandlersManager.UnregisterEventsHandler(commonItemHandler);
        CustomHandlersManager.UnregisterEventsHandler(keyCardItemHandler);
        CustomHandlersManager.UnregisterEventsHandler(nonItemRelatedHandler);
        CustomHandlersManager.UnregisterEventsHandler(usableItemHandler);
        CustomHandlersManager.UnregisterEventsHandler(throwableItemHandler);
        CustomHandlersManager.UnregisterEventsHandler(damageHandler);
        CustomHandlersManager.UnregisterEventsHandler(firearmHandler);
        CustomHandlersManager.UnregisterEventsHandler(scp914Handler);
        CustomHandlersManager.UnregisterEventsHandler(jailbirdHandler);
        CustomHandlersManager.UnregisterEventsHandler(revolverHandler);
        CustomHandlersManager.UnregisterEventsHandler(scp127Handler);
        InventoryExtensions.OnItemRemoved -= Subscribed.OnItemRemoved;
        ThrownProjectile.OnProjectileSpawned -= Subscribed.ProjectileSpawned;
        CycleController.OnPhaseChanged -= Subscribed.PhaseChanged;
        BrokenSyncModule.OnBroken -= Subscribed.BrokenSyncModule_OnBroken;
        DrawAndInspectorModule.OnInspectRequested -= Subscribed.DrawAndInspectorModule_OnInspectRequested;
        CustomItems.UnRegisterAllCustomItems();
    }
}
