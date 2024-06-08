using System.Device.Gpio;
using GpioPin = Gpiot.Models.GpioPin;

namespace Gpiot.Helpers;

public class GpioHandler : IDisposable
{
    private readonly GpioController _gpioController;

    public GpioHandler()
    {
        _gpioController = new GpioController();
    }

    public GpioPin GetStatusOfPin(int pinId)
    {
        var pinMode = _gpioController.GetPinMode(pinId);
        var open = _gpioController.IsPinOpen(pinId);
        var pinValue = _gpioController.Read(pinId);
        
        return new GpioPin
        {
            GpioPinId = pinId,
            PinMode = GpioValueMapper.GetPinMode(pinMode),
            Value = pinValue.Equals(PinValue.High) ? 1 : 0,
            Open = open
        };
    }

    public void Dispose()
    {
        _gpioController.Dispose();
    }
}