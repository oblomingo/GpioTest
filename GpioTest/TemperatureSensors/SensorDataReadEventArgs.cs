using System;
using System.Collections.Generic;
using System.Text;

namespace GpioTest.TemperatureSensors
{
	public class SensorDataReadEventArgs
	{
		public SensorDataReadEventArgs(decimal temperatureCelsius, decimal humidityPercentage)
		{
			TemperatureCelsius = temperatureCelsius;
			HumidityPercentage = humidityPercentage;
		}
		public decimal TemperatureCelsius { get; }

		/// <summary>
		/// Gets the humidity percentage.
		/// </summary>
		public decimal HumidityPercentage { get; }
	}
}
