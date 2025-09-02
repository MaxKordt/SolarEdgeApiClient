namespace ApiClient;

public static class TimeUnitParam
{
    public static string ToParam(this TimeUnit timeUnit) => timeUnit switch
    {
        TimeUnit.QuarterOfAnHour => "QUARTER_OF_AN_HOUR",
        TimeUnit.Hour => "HOUR",
        TimeUnit.Day => "DAY",
        TimeUnit.Week => "WEEK",
        TimeUnit.Month => "MONTH",
        TimeUnit.Year => "YEAR",
        _ => throw new ArgumentOutOfRangeException(nameof(timeUnit), timeUnit, null)
    };
}