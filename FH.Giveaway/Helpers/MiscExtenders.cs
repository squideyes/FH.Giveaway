namespace FH.Giveaway;

public static class MiscExtenders
{
    public static string ToDateString(this DateOnly date) => 
        date.ToString("yyyy-MM-dd");
}
