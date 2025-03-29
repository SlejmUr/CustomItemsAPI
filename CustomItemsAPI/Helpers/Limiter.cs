namespace CustomItemsAPI.Helpers;

public class Limiter<E, T>(E enumType, T type) where E : Enum where T : struct 
{
    public E EnumType { get; } = enumType;

    public T Type { get; } = type;
}