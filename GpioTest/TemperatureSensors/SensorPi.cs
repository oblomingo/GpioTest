using System;
using System.Collections.Generic;
using System.Text;
using Unosquare.RaspberryIO.Gpio;

namespace GpioTest.TemperatureSensors
{
	public class SensorPi
	{
		static SensorPi()
		{

		}

		public static GpioController Gpio => null;

		public static P1 Pin { get; set; }
	}
}
