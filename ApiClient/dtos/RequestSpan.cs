namespace ApiClient;

public record RequestSpan
{
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }
    public TimeUnit TimeUnit { get; init; }
    
    // ReSharper disable once ConvertToPrimaryConstructor
    private RequestSpan(DateTime startDate, DateTime endDate, TimeUnit timeUnit)
    {
        StartDate = startDate;
        EndDate = endDate;
        TimeUnit = timeUnit;
    }
    
    /// <summary>
    /// Resolution day
    /// </summary>
    /// <param name="startDate"></param>
    /// <returns></returns>
    public static RequestSpan GetDay(DateTime startDate) => new(startDate, startDate.AddHours(23).AddMinutes(59), TimeUnit.Day);
    
    /// <summary>
    /// Resolution month
    /// </summary>
    /// <param name="startDate"></param>
    /// <returns></returns>
    public static RequestSpan GetMonth(DateTime startDate) => new(startDate, startDate, TimeUnit.Month);
    
    /// <summary>
    /// Resolution hour
    /// </summary>
    /// <param name="startDate"></param>
    /// <returns></returns>
    public static RequestSpan GetDayHourly(DateTime startDate) => new(startDate, startDate, TimeUnit.Hour);
    
    /// <summary>
    /// Resolution 15 minutes
    /// </summary>
    /// <param name="startDate"></param>
    /// <returns></returns>
    public static RequestSpan GetDayQuarterOfAnHour(DateTime startDate) => new(startDate, startDate, TimeUnit.QuarterOfAnHour);
}