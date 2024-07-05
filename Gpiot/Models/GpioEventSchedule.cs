public class GpioEventSchedule
{
    public string ScheduleName { get; set; } = string.Empty;
    public int PinNumber { get; set; }
    public string StartTime { get; set; } = string.Empty;
    public int Interval { get; set; }
    public int InitialValue { get; set; }
}