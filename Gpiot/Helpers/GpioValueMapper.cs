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
}