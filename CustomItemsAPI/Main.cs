using CustomItemsAPI.EventHandlers;
using InventorySystem;
using InventorySystem.Items.MicroHID.Modules;
using InventorySystem.Items.ThrowableProjectiles;
using LabApi.Events.CustomHandlers;
using LabApi.Loader;
using LabApi.Loader.Features.Plugins;

namespace CustomItemsAPI;

internal sealed class Main : Plugin<Config>
{
    public static Main Instance;
    public override string Name => "CustomItemsAPI";

    public override string Description => "Enabling creating custom items";

    public override string Author => "SlejmUr";

    public override Version Version => new(0, 0, 8, 0);

    public override Version RequiredApiVersion => LabApi.Features.LabApiProperties.CurrentVersion;

    private readonly CommonItemHandler commonItemHandler = new();
    private readonly KeyCardItemHandler keyCardItemHandler = new();
    private readonly NonItemRelatedHandler nonItemRelatedHandler = new();
    private readonly UsableItemHandler usableItemHandler = new();
    private readonly ThrowableItemHandler throwableItemHandler = new();
    private readonly DamageHandler damageHandler = new();
    private readonly FirearmHandler firearmHandler = new();
    private readonly Scp914Handler scp914Handler = new();
    private readonly JailbirdHandler jailbirdHandler = new();
    private readonly RevolverHandler revolverHandler = new();
    private readonly Scp127Handler scp127Handler = new();
    private readonly CoinHandler coinHandler = new();

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
        CustomHandlersManager.RegisterEventsHandler(coinHandler);
        InventoryExtensions.OnItemRemoved += Subscribed.OnItemRemoved;
        ThrownProjectile.OnProjectileSpawned += Subscribed.ProjectileSpawned;
        CycleController.OnPhaseChanged += Subscribed.PhaseChanged;
        BrokenSyncModule.OnBroken += Subscribed.BrokenSyncModule_OnBroken;
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
        CustomHandlersManager.UnregisterEventsHandler(coinHandler);
        InventoryExtensions.OnItemRemoved -= Subscribed.OnItemRemoved;
        ThrownProjectile.OnProjectileSpawned -= Subscribed.ProjectileSpawned;
        CycleController.OnPhaseChanged -= Subscribed.PhaseChanged;
        BrokenSyncModule.OnBroken -= Subscribed.BrokenSyncModule_OnBroken;
        CustomItems.UnRegisterAllCustomItems();
    }

    public override void LoadConfigs()
    {
        if (!this.TryLoadConfig(ConfigFileName, out Config config))
        {
            CL.Warn("Failed to load the configuration file, using default values.");
            config = new();
        }

        Config = config;
    }
}
