using System.ComponentModel;

namespace CustomItemsAPI.Helpers;

/// <summary>
/// Options for changing the base value with Math.
/// </summary>
public enum MathOption
{
    /// <summary>
    /// Do not change any value
    /// </summary>
    None,
    /// <summary>
    /// Set the value to my value.
    /// </summary>
    Set,
    /// <summary>
    /// Add my value value to base.
    /// </summary>
    Add,
    /// <summary>
    /// Sintract the base with my value.
    /// </summary>
    Subtract,
    /// <summary>
    /// Multiply my value withthe base.
    /// </summary>
    Multiply,
    /// <summary>
    /// Divide my value with the base.
    /// </summary>
    Divide,
}

/// <summary>
/// <see cref="MathOption"/> with <see cref="float"/>.
/// </summary>
public class MathValueFloat
{
    /// <summary>
    /// My value.
    /// </summary>
    public float Value { get; set; } = 0;
    /// <summary>
    /// <see cref="MathOption"/>
    /// </summary>
    public MathOption Math { get; set; } = MathOption.None;

    /// <summary>
    /// Create a new Empty No value, No MathOption
    /// </summary>
    public MathValueFloat()
    {

    }

    /// <summary>
    /// Create a new MathValue with parameters
    /// </summary>
    /// <param name="math"></param>
    /// <param name="value"></param>
    public MathValueFloat(MathOption math, float value)
    {
        Math = math;
        Value = value;
    }
}

/// <summary>
/// <see cref="MathOption"/> with <see cref="int"/>.
/// </summary>
public class MathValueInt
{
    /// <summary>
    /// My value.
    /// </summary>
    public int Value { get; set; } = 0;
    /// <summary>
    /// <see cref="MathOption"/>
    /// </summary>
    public MathOption Math { get; set; } = MathOption.None;

    /// <summary>
    /// Create a new Empty No value, No MathOption
    /// </summary>
    public MathValueInt()
    {

    }

    /// <summary>
    /// Create a new MathValue with parameters
    /// </summary>
    /// <param name="math"></param>
    /// <param name="value"></param>
    public MathValueInt(MathOption math, int value)
    {
        Math = math;
        Value = value;
    }
}


/// <summary>
/// Helper class for <see cref="MathOption"/>
/// </summary>
public static class MathValueHelper
{
    /// <summary>
    /// Create a new <see cref="float"/> from a <paramref name="mathOption"/>, <paramref name="inFloat"/>, <paramref name="myValue"/>.
    /// </summary>
    /// <param name="mathOption"></param>
    /// <param name="inFloat"></param>
    /// <param name="myValue"></param>
    /// <returns></returns>
    public static float MathWithFloat(this MathOption mathOption, float inFloat, float myValue)
    {
        return mathOption switch
        {
            MathOption.None => inFloat,
            MathOption.Set => myValue,
            MathOption.Add => inFloat + myValue,
            MathOption.Subtract => inFloat - myValue,
            MathOption.Multiply => inFloat * myValue,
            MathOption.Divide => inFloat / myValue,
            _ => inFloat,
        };
    }

    /// <summary>
    /// Create a new <see cref="int"/> from a <paramref name="mathOption"/>, <paramref name="inInt"/>, <paramref name="myValue"/>.
    /// </summary>
    /// <param name="mathOption"></param>
    /// <param name="inInt"></param>
    /// <param name="myValue"></param>
    /// <returns></returns>
    public static int MathWithInt(this MathOption mathOption, int inInt, int myValue)
    {
        return mathOption switch
        {
            MathOption.None => inInt,
            MathOption.Set => myValue,
            MathOption.Add => inInt + myValue,
            MathOption.Subtract => inInt - myValue,
            MathOption.Multiply => inInt * myValue,
            MathOption.Divide => inInt / myValue,
            _ => inInt,
        };
    }

    /// <summary>
    /// Change the <paramref name="inValue"/> with <paramref name="mathValue"/>.
    /// </summary>
    /// <param name="mathValue"></param>
    /// <param name="inValue"></param>
    public static void MathWithValue(this MathValueFloat mathValue, ref float inValue)
    {
        inValue = mathValue.Math.MathWithFloat(inValue, mathValue.Value);
    }

    /// <summary>
    /// Change the <paramref name="inValue"/> with <paramref name="mathValue"/>.
    /// </summary>
    /// <param name="mathValue"></param>
    /// <param name="inValue"></param>
    public static float MathWithValue(this MathValueFloat mathValue, float inValue)
    {
        return mathValue.Math.MathWithFloat(inValue, mathValue.Value);
    }

    /// <summary>
    /// Change the <paramref name="inValue"/> with <paramref name="mathValue"/>.
    /// </summary>
    /// <param name="mathValue"></param>
    /// <param name="inValue"></param>
    public static void MathWithValue(this MathValueInt mathValue, ref int inValue)
    {
        inValue = mathValue.Math.MathWithInt(inValue, mathValue.Value);
    }


    /// <summary>
    /// Change the <paramref name="inValue"/> with <paramref name="mathValue"/>.
    /// </summary>
    /// <param name="mathValue"></param>
    /// <param name="inValue"></param>
    public static int MathWithValue(this MathValueInt mathValue, int inValue)
    {
        return mathValue.Math.MathWithInt(inValue, mathValue.Value);
    }
}
