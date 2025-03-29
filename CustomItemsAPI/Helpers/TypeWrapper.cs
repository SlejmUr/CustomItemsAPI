namespace CustomItemsAPI.Helpers;

public class TypeWrapper<T>
{
    public T Value { get; set; }

    public TypeWrapper()
    {

    }

    public TypeWrapper(T value)
    {
        Value = value;
    }
}
