using Gpiot.Models;

namespace Gpiot.Interfaces;

public interface IGpioHandler
{
    public GpioPin GetStatusOfPin(int pinId);
    public bool SetPin(GpioPin pinInfo);
}