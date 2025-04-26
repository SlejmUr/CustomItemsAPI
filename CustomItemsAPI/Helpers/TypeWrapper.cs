namespace CustomItemsAPI.Helpers;

/// <summary>
/// Type wrapper to not need to use <see langword="ref"/> or <see langword="out"/> as parameter.
/// </summary>
/// <typeparam name="T">Any <see langword="type"/>.</typeparam>
public class TypeWrapper<T>
{
    /// <summary>
    /// The default value.
    /// </summary>
    public readonly T DefaultValue;
    /// <summary>
    /// The Value of the Type.
    /// </summary>
    public T Value { get; set; }

    /// <summary>
    /// Create a new <see cref="TypeWrapper{T}"/> with <see cref="DefaultValue"/> as <see langword="default"/>
    /// </summary>
    public TypeWrapper()
    {
        DefaultValue = default;
    }

    /// <summary>
    /// Create a new <see cref="TypeWrapper{T}"/> with <see cref="DefaultValue"/> as <paramref name="value"/>.
    /// </summary>
    /// <param name="value">The initial value.</param>
    public TypeWrapper(T value)
    {
        Value = value;
        DefaultValue = value;
    }
}
