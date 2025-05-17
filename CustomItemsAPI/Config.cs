using System.ComponentModel;

namespace CustomItemsAPI;

/// <summary>
/// Configuration for Custom Items.
/// </summary>
internal sealed class Config
{
    /// <summary>
    /// Should print out Debug related information.
    /// </summary>
    public bool Debug { get; set; }

    /// <summary>
    /// Printing component on before and after
    /// </summary>
    public bool PrintComponentOnChange { get; set; }

    /// <summary>
    /// Whenever getting/spawning the item should ignore the case of it.
    /// </summary>
    public bool EasyCompare { get; set; } = true;


    public bool ShowPickedUpHint { get; set; } = true;

    [Description("Hint when you picked up the custom item. {0}: DisplayName {1}: Description.")]
    public string PickedUpHint { get; set; } = "You picked up {0}\n{1}";


    public bool ShowSelectedHint { get; set; } = true;

    [Description("Hint when you selected a the custom item. {0}: DisplayName {1}: Description.")]
    public string SelectedHint { get; set; } = "You selected {0}\n{1}";
}
