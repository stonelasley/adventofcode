namespace Aoc2023.Day03;

public record SchematicItem(int LineNumber, string Value, int Index)
{
    public bool IsEmpty => string.IsNullOrEmpty(Value) || Value == "_";
    public bool IsSymbol => !IsNumber && !IsEmpty;
    public int EndIndex => IsEmpty ? Index : Index + (Value.Length - 1);
    public bool IsNumber => int.TryParse(Value, out int _);
    public bool IsStar => Value == "*";
    public int? NumberValue => int.TryParse(Value, out int result) ? result : null;
}