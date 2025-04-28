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
    public bool EasyCompare { get; set; }
}
