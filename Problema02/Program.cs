using System;
using System.Linq;

namespace Problema02
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			CompleteRange cs = new CompleteRange();

			//cs.build(new List<int> { 2, 1, 4, 5 });
			//cs.build(new List<int> { 4, 2, 9 });
			//cs.build(new List<int> { 58, 60, 55 });


			while (true)
			{
				string cadena = "";
				Console.WriteLine("\n\n---Ingrese los numeros con comas separadas---");
				cadena = Console.ReadLine();
				int[] cadenasplit = cadena.Split(',').Select(n => Convert.ToInt32(n)).ToArray();

				//El argumento es una coleccion como indica el problema
				int[] lista = cs.build(cadenasplit.ToList()).ToArray();

				for (int i = 0; i < lista.Length; i++)
				{
					Console.Write(lista[i]);
					if (cadenasplit.Contains(lista[i]))
					{
						Console.Write("*");
					}
					Console.Write((i < lista.Length - 1) ? "," : "");
				}

			}
		}
	}
}
