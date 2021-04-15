static public class Helpers
{
    private static readonly string format = "{0:#,0.00}" ;
    static public string GetFormaTMoney(this decimal? value) 
        => value.HasValue ? GetFormaTMoney(value.Value) : "a más";
    static public string GetFormaTMoney(this decimal value) 
        => string.Format(format, value);
    
}