using System;
using System.Collections.Generic;
using System.Text;

namespace GpioTest
{
	public class DHTData
	{
		public float TempCelcius { get; set; }
		public float TempFahrenheit { get; set; }
		public float Humidity { get; set; }
		public double HeatIndex { get; set; }
	}

	public class DHTException : Exception
	{
	}

	public enum DHTSensorTypes
	{
		DHT11,
		DHT21,
		DHT22
	}
}
