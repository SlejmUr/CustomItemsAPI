using CustomItemsAPI.TestItems.ManyItemTest;
using LabApi.Loader.Features.Plugins;

namespace CustomItemsAPI.TestItems;

internal sealed class Main : Plugin
{
    public static Main Instance;
    public override string Name => "CustomItemsAPI.TestItems";

    public override string Description => "Enabling creating custom items";

    public override string Author => "SlejmUr";

    public override Version Version => new(0, 0, 3, 3);

    public override Version RequiredApiVersion => LabApi.Features.LabApiProperties.CurrentVersion;

    public override void Disable()
    {
        Instance = null;
        CustomItems.UnRegisterAllCustomItems();
    }

    public override void Enable()
    {
        Instance = this;
        CustomItems.RegisterCustomItemsExcept([typeof(ManyItemBase)]);
        foreach (var item in Enumerable.Range(0, 5))
        {
            CustomItems.RegisterCustomItem(new ManyItemBase()
            { 
                CustomItemName = $"{nameof(ManyItemBase)}_{item}",
                Description = $"Test decs for item: {item}"
            });
        }
    }
}
