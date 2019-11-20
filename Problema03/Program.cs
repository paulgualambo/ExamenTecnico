using System;

namespace Problema03
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			MoneyParts m = new MoneyParts();

			while (true)
			{
				Console.WriteLine("\n\n---Ingrese un monto---");
				string monto = Console.ReadLine();
				double[][] result = m.build(Convert.ToDouble(monto));

				int forma = 1;

				Console.WriteLine("[");
				//foreach (double[] a in result)
				for (int i = 0; i < result.Length; i++)
				{
					Console.Write("\t[");
					double[] a = result[i];
					for (int j = 0; j < a.Length; j++)
					{
						Console.Write(a[j]);
						Console.Write((j < a.Length - 1) ? "," : "");
					}
					Console.Write("]");
					Console.WriteLine((i < result.Length - 1) ? "," : "");
					forma++;
				}
				Console.WriteLine("]");
			}
		}

	}
}

