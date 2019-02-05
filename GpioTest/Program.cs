using GpioTest.TemperatureSensors;
using System;
using System.Reactive.Linq;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Gpio;
using Unosquare.RaspberryIO.Peripherals;

namespace GpioTest
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				Pi.Gpio.Pin26.PinMode = GpioPinDriveMode.Input;
				// The below lines are reoughly equivalent
				var isOn = Pi.Gpio.Pin26.Read(); // Reads as a boolean
				var isOnText = isOn ? "on" : "off";
				Console.WriteLine($"Gpio26 is {isOnText}");

				Console.ReadLine();

				Console.WriteLine($"Turnning on Gpio26");
				Pi.Gpio.Pin26.PinMode = GpioPinDriveMode.Output;
				// The below lines are reoughly equivalent
				Pi.Gpio.Pin26.Write(true); // Writes a boolean
				Console.WriteLine($"Turned on Gpio26");

				Console.ReadLine();

				Pi.Gpio.Pin26.PinMode = GpioPinDriveMode.Input;
				// The below lines are reoughly equivalent
				isOn = Pi.Gpio.Pin26.Read(); // Reads as a boolean
				isOnText = isOn ? "on" : "off";
				Console.WriteLine($"Gpio26 is {isOnText}");

				Console.ReadLine();

				Console.WriteLine($"Turnning off Gpio26");
				Pi.Gpio.Pin26.PinMode = GpioPinDriveMode.Output;
				// The below lines are reoughly equivalent
				Pi.Gpio.Pin26.Write(GpioPinValue.Low); // Writes a boolean
				Console.WriteLine($"Turned off Gpio26");

				Console.ReadLine();

				Pi.Gpio.Pin26.PinMode = GpioPinDriveMode.Input;
				// The below lines are reoughly equivalent
				isOn = Pi.Gpio.Pin26.Read(); // Reads as a boolean
				isOnText = isOn ? "on" : "off";
				Console.WriteLine($"Gpio26 is {isOnText}");

				Console.ReadLine();

				//using (ITemperatureSensor sensor = new TemperatureSensorForTesting(P1.Gpio22))
				//{
				//	//Observable
				//	//	.FromEventPattern<SensorDataReadEventArgs>(sensor, "OnMeasure")
				//	//	.Sample(TimeSpan.FromSeconds(20))
				//	//	.Subscribe(x => Sensor_OnDataAvailable(x.EventArgs));
				//	sensor.OnMeasure += Sensor_OnMeasure; ;
				//	sensor.Start();

				//	Console.ReadLine();
				//}



				Console.ReadLine();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message + " - " + e.StackTrace);
				Console.ReadLine();
			}
		}

		private static void Sensor_OnMeasure(object sender, TemperatureSensors.SensorDataReadEventArgs e)
		{
			Console.WriteLine($"[{DateTime.Now.ToShortTimeString()}] TemperatureCelsius: {e.TemperatureCelsius}, HumidityPercentage: {e.HumidityPercentage}");
		}

		private static void Sensor_OnDataAvailable(SensorDataReadEventArgs e)
		{
			Console.WriteLine($"[{DateTime.Now.ToShortTimeString()}] TemperatureCelsius: {e.TemperatureCelsius}, HumidityPercentage: {e.HumidityPercentage}");
		}

		//private static void Sensor_OnDataAvailable(object sender, TemperatureSensorAM2302.AM2302DataReadEventArgs e)
		//{
		//	Console.WriteLine($"[{DateTime.Now.ToShortTimeString()}] TemperatureCelsius: {e.TemperatureCelsius}, HumidityPercentage: {e.HumidityPercentage}");
		//}
	}
}
