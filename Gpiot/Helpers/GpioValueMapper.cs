using System.Device.Gpio;
using Gpiot.Consts;

namespace Gpiot.Helpers;

public static class GpioValueMapper
{
    public static string GetPinMode(PinMode pinMode) => pinMode switch
    {
        PinMode.Input => GpioConsts.PIN_MODE_INPUT,
        PinMode.Output => GpioConsts.PIN_MODE_OUTPUT,
        PinMode.InputPullDown => GpioConsts.PIN_MODE_PULL_DOWN,
        PinMode.InputPullUp => GpioConsts.PIN_MODE_PULL_UP,
        _ => throw new ArgumentOutOfRangeException("Not supported pin mode.")
    };

    public static PinMode GetPinMode(string pinMode) => pinMode switch
    {
        GpioConsts.PIN_MODE_INPUT => PinMode.Input,
        GpioConsts.PIN_MODE_OUTPUT => PinMode.Output,
        GpioConsts.PIN_MODE_PULL_DOWN => PinMode.InputPullDown,
        GpioConsts.PIN_MODE_PULL_UP => PinMode.InputPullUp,
        _ => throw new ArgumentOutOfRangeException("Not supported pin mode.")
    };

    public static PinValue GetPinValue(int val) => val switch
    {
        0 => PinValue.Low,
        1 => PinValue.High,
        _ => throw new ArgumentOutOfRangeException("Not supported pin mode.")
    };
}