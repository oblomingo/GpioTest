﻿using GpioTest.TemperatureSensors;
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
				using (ITemperatureSensor sensor = new TemperatureSensorForTesting(P1.Gpio22))
				{
					//Observable
					//	.FromEventPattern<SensorDataReadEventArgs>(sensor, "OnMeasure")
					//	.Sample(TimeSpan.FromSeconds(20))
					//	.Subscribe(x => Sensor_OnDataAvailable(x.EventArgs));
					sensor.OnMeasure += Sensor_OnMeasure; ;
					sensor.Start();

					Console.ReadLine();
				}

				//var controller = GpioController.Instance;
				//controller.Pin21.Write(GpioPinValue.High);
				//var isOn = controller.Pin21.Read();

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
