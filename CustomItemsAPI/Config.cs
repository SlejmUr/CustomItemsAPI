namespace CustomItemsAPI;

/// <summary>
/// Configuration for Custom Items.
/// </summary>
public sealed class Config
{
    /// <summary>
    /// Should print out Debug related information.
    /// </summary>
    public bool Debug { get; set; }

    /// <summary>
    /// Whenever getting/spawning the item should ignore the case of it.
    /// </summary>
    public bool EasyCompare { get; set; }
}
