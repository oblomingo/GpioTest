using System;
using System.Threading;
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
				using (TemperatureSensorAM2302 sensor = new TemperatureSensorAM2302(Pi.Gpio[P1.Gpio17]))
				{
					sensor.OnDataAvailable += Sensor_OnDataAvailable;
					sensor.Start();
				}

				Console.ReadLine();
				//var dht = new DHT(Pi.Gpio.Pin07, DHTSensorTypes.DHT22);
				//while (true)
				//{
				//	try
				//	{
				//		var d = dht.ReadData();
				//		Console.WriteLine(DateTime.UtcNow);
				//		Console.WriteLine(" temp: " + d.TempCelcius);
				//		Console.WriteLine(" hum: " + d.Humidity);
				//	}
				//	catch (DHTException)
				//	{
				//	}
				//	Thread.Sleep(5000);
				//}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message + " - " + e.StackTrace);
				Console.ReadLine();
			}
		}

		private static void Sensor_OnDataAvailable(object sender, TemperatureSensorAM2302.AM2302DataReadEventArgs e)
		{
			Console.WriteLine($"[{DateTime.Now.ToShortTimeString()}] TemperatureCelsius: {e.TemperatureCelsius}, HumidityPercentage: {e.HumidityPercentage}");
		}
	}
}
