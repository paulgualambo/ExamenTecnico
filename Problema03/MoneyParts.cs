using System;
using System.Collections.Generic;
using System.Linq;

namespace Problema03
{
	internal class MoneyParts
	{
		//private double[] monedas = { 0.05, 0.1, 0.2, 0.5, 1, 2, 5, 10, 20, 50, 100, 200 };
		private double[] monedas = { 0.05, 0.1, 0.2, 0.5, 1, 2, 5, 10, 20, 50, 100, 200 };

		//Forma de la respuesta es 
		// a1*m1 a2*m2 a3*m3 a4*m4 a5*m5 a6*m6 a7*m7 a8*m8 a9*m9
		public List<Dictionary<double, int>> build(string monto)
		{
			int[,] coeficientes = new int[100, 12];

			List<Dictionary<double, int>> listaMonedasCoeficientes = new List<Dictionary<double, int>>();

			Dictionary<double, int> monedasCoeficientes = new Dictionary<double, int>();

			double[] monedasOrder = monedas.OrderByDescending(m => m).ToArray();
			double montoTemp = Convert.ToDouble(monto);

			double resto = montoTemp;


			//double money = 0.0;
			//double[] newListaMonedas = monedasOrder.Where(m => m != money).ToArray();

			foreach (double money in monedasOrder)
			{
				int coeficienteMax = obtenerCoeficienteMaximo(resto, money);

				for (int coeficiente = coeficienteMax; coeficiente > 0; coeficiente--)
				{
					//calculoOtrasMonedas(coeficiente, money, monedasOrder, resto)
				}
				listaMonedasCoeficientes.Add(monedasCoeficientes);
			}

			//return listaMonedasCoeficientes;
		}

		private int obtenerCoeficienteMaximo(double monto, double money)
		{
			return (int)(monto / money);
		}

		//private calculoOtrasMonedas(int coeficiente, double money, double[] listaMonedas, double monto)
		//{

		//	//Nuevo monto
		//	monto = monto - coeficiente * money;

		//	//A la lista de monedas le quitare la moneda seleccionada
		//	listaMonedas = listaMonedas.Where(m => m != money).ToArray();
		//}

	}
}
