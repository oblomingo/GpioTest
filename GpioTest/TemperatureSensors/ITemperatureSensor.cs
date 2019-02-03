using System;
using GpioTest.TemperatureSensors;

namespace GpioTest
{
	public interface ITemperatureSensor : IDisposable
	{
		event EventHandler<SensorDataReadEventArgs> OnMeasure;
		void Start();
		void Dispose();
	}
}
