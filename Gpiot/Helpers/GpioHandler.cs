using System.Device.Gpio;
using Gpiot.Interfaces;
using GpioPin = Gpiot.Models.GpioPin;

namespace Gpiot.Helpers;

public class GpioHandler : IDisposable, IGpioHandler
{
    private readonly GpioController _gpioController;

    public GpioHandler()
    {
        _gpioController = new GpioController();
    }

    public GpioPin GetStatusOfPin(int pinId)
    {
        var open = _gpioController.IsPinOpen(pinId);
        var pinMode = string.Empty;
        var pinValue = 0;
        
        if (open)
        {
            var mode = _gpioController.GetPinMode(pinId);
            pinMode = GpioValueMapper.GetPinMode(mode);
            pinValue = _gpioController.Read(pinId).Equals(PinValue.High) ?
                    1 : 0;
        }
        
        return new GpioPin
        {
            GpioPinId = pinId,
            PinMode = pinMode,
            Value = pinValue,
            Open = open
        };
    }

    public bool SetPin(GpioPin pinInfo)
    {
        if (pinInfo.Open) {
            _gpioController.OpenPin(pinInfo.GpioPinId);
        } else {
            _gpioController.ClosePin(pinInfo.GpioPinId);
        }
        
        if (!_gpioController.IsPinOpen(pinInfo.GpioPinId))
        {
            return true;                        
        }

        try {
            var mode = GpioValueMapper.GetPinMode(pinInfo.PinMode);
            _gpioController.SetPinMode(pinInfo.GpioPinId, mode);
            var val = GpioValueMapper.GetPinValue(pinInfo.Value); 
            _gpioController.Write(pinInfo.GpioPinId, val);
            
            return true;
        } catch {
            return false;
        }
    }

    public void Dispose()
    {
        _gpioController.Dispose();
    }
}