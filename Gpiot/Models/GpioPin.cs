namespace Gpiot.Models;

public class GpioPin
{
    public int GpioPinId { get; set; }
    public string PinMode { get; set; } = string.Empty;
    public bool Open { get; set; }
    public int Value { get; set; }
}