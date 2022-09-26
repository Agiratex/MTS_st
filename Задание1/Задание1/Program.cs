using System;
using System.Diagnostics;
using System.Windows;
class Program
{
	static void Main(string[] args)
	{
		try
		{
			FailProcess();
		}
		catch { }

		Console.WriteLine("Failed to fail process!");
		Console.ReadKey();
	}

	static void FailProcess()
	{
		Environment.Exit(-1);
		//Environment.FailFast("Actualy failed!");
		//Process.GetCurrentProcess().Kill();
	}
}
