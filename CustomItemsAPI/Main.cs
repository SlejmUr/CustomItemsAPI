using LabApi.Loader.Features.Plugins;
using LabApi.Events.CustomHandlers;
using CustomItemsAPI.EventHandlers;
using InventorySystem;
using InventorySystem.Items.ThrowableProjectiles;
using InventorySystem.Items.MicroHID.Modules;

namespace CustomItemsAPI;

internal sealed class Main : Plugin<Config>
{
    public static Main Instance;
    public override string Name => "CustomItemsAPI";

    public override string Description => "Enabling creating custom items";

    public override string Author => "SlejmUr";

    public override Version Version => new(0, 0, 3, 0);

    public override Version RequiredApiVersion => LabApi.Features.LabApiProperties.CurrentVersion;

    private CommonItemHandler commonItemHandler;
    private KeyCardItemHandler keyCardItemHandler;
    private NonItemRelatedHandler nonItemRelatedHandler;
    private UsableItemHandler usableItemHandler;
    private ThrowableItemHandler throwableItemHandler;
    private DamageHandler damageHandler;
    private FirearmHandler firearmHandler;

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
        InventoryExtensions.OnItemRemoved -= Subscribed.OnItemRemoved;
        ThrownProjectile.OnProjectileSpawned -= Subscribed.ProjectileSpawned;
        CycleController.OnPhaseChanged -= Subscribed.PhaseChanged;
        CustomItems.UnRegisterAllCustomItems();
    }

    public override void Enable()
    {
        Instance = this;
        commonItemHandler = new();
        CustomHandlersManager.RegisterEventsHandler(commonItemHandler);
        keyCardItemHandler = new();
        CustomHandlersManager.RegisterEventsHandler(keyCardItemHandler);
        nonItemRelatedHandler = new();
        CustomHandlersManager.RegisterEventsHandler(nonItemRelatedHandler);
        usableItemHandler = new();
        CustomHandlersManager.RegisterEventsHandler(usableItemHandler);
        throwableItemHandler = new();
        CustomHandlersManager.RegisterEventsHandler(throwableItemHandler);
        damageHandler = new();
        CustomHandlersManager.RegisterEventsHandler(damageHandler);
        firearmHandler = new();
        CustomHandlersManager.RegisterEventsHandler(firearmHandler);
        InventoryExtensions.OnItemRemoved += Subscribed.OnItemRemoved;
        ThrownProjectile.OnProjectileSpawned += Subscribed.ProjectileSpawned;
        CycleController.OnPhaseChanged += Subscribed.PhaseChanged;
        CustomItems.RegisterCustomItems();
    }
}
