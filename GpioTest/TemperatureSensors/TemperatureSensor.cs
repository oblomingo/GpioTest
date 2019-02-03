using System;
using GpioTest.TemperatureSensors;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Gpio;
using Unosquare.RaspberryIO.Peripherals;

namespace GpioTest
{
	public class TemperatureSensor : TemperatureSensorAM2302, ITemperatureSensor
	{
		public TemperatureSensor(P1 pin) : base(Pi.Gpio[pin])
		{
			OnDataAvailable += TemperatureSensor_OnDataAvailable;
		}
		public TemperatureSensor(GpioPin dataPin) : base(dataPin)
		{
			OnDataAvailable += TemperatureSensor_OnDataAvailable;
		}

		private void TemperatureSensor_OnDataAvailable(object sender, TemperatureSensorAM2302.AM2302DataReadEventArgs e)
		{
			OnMeasure?.Invoke(this, new SensorDataReadEventArgs(e.TemperatureCelsius, e.HumidityPercentage));
		}

		public event EventHandler<SensorDataReadEventArgs> OnMeasure;
	}
}
