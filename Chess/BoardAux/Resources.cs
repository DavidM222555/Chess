namespace Chess.BoardAux;

public class Resources
{
    public readonly IDictionary<int, string> RowNames = new Dictionary<int, string>();
    public readonly IDictionary<int, string> ColNames = new Dictionary<int, string>();

    public Resources()
    {
        RowNames.Add(0, "8");
        RowNames.Add(1, "7");
        RowNames.Add(2, "6");
        RowNames.Add(3, "5");
        RowNames.Add(4, "4");
        RowNames.Add(5, "3");
        RowNames.Add(6, "2");
        RowNames.Add(7, "1");
        
        ColNames.Add(0, "a");
        ColNames.Add(1, "b");
        ColNames.Add(2, "c");
        ColNames.Add(3, "d");
        ColNames.Add(4, "e");
        ColNames.Add(5, "f");
        ColNames.Add(6, "g");
        ColNames.Add(7, "h");

    }
    
}