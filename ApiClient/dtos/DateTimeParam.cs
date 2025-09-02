namespace ApiClient;

public static class DateTimeParam
{
    public static string ToEnergyParam(this DateTime dateTime)
    {
        return $"{dateTime:yyyy-MM-dd}";
    }

    public static string ToPowerParam(this DateTime dateTime)
    {
        return $"{dateTime:yyyy-MM-dd}%20{dateTime:HH:mm:ss}";
    }
}