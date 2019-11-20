using System.Collections.Generic;
using System.Linq;

namespace Problema03
{
	public class MoneyParts
	{
		public double[][] build(double monto)
		{

			//double[] monedas = { 20, 10, 5, 2, 1 };
			double[] monedas = { 0.05, 0.1, 0.2, 0.5, 1, 2, 5, 10, 20, 50, 100, 200 };

			//Invirtiendo el orden de forma ascendente
			monedas = monedas.OrderByDescending(m => m).ToArray();

			//Array que sirve para realizar los calculos de resta de coeficientes
			int[] flagRestaUno = Enumerable.Repeat(0, monedas.Length).ToArray();

			//Para restar los montos
			double resto = 0;			
			

			//Array que guarda los coeficientes de una iteracion
			int[] columnaCoeficientes = Enumerable.Repeat(0, monedas.Length).ToArray();

			List<int[]> coeficientes = new List<int[]>();
					

			bool iterar = true;

			//La primera vez que itera se recalcula todo
			bool recalculo = true;

			int iteracion = 1;
			while (iterar)
			{
				resto = monto;
				
				for (int lugarMoneda = 0; lugarMoneda < monedas.Length; lugarMoneda++)
				{
					//Depurando las demas monedas cuando el resto es cero
					if (resto == 0)
					{
						columnaCoeficientes[lugarMoneda] = 0;
					}

					//Si estamos en el flag se resta uno
					if (flagRestaUno[lugarMoneda] == 1)
					{
						columnaCoeficientes[lugarMoneda]--;
						recalculo = true;
						resto = System.Math.Round(resto - columnaCoeficientes[lugarMoneda] * monedas[lugarMoneda],2);
						continue;
					}

					//Reacalculando los coeficientes
					if (recalculo)
					{
						columnaCoeficientes[lugarMoneda] = (int)(System.Math.Round(resto / monedas[lugarMoneda],2));
					}

					resto = System.Math.Round(resto - columnaCoeficientes[lugarMoneda] * monedas[lugarMoneda],2);
				}
				iteracion++;
				//Apartir del segunda iteracion
				recalculo = false;

				//Restablecer el arreglo
				flagRestaUno = Enumerable.Repeat(0, monedas.Length).ToArray();

				//Se toma desde el penultimo hasta el primero
				for (int i = columnaCoeficientes.Length - 2; i >= 0; i--)
				{
					iterar = false;
					if (columnaCoeficientes[i] != 0)
					{
						iterar = true;
						flagRestaUno[i] = 1;
						break;
					}

				}

				//Agregando los coeficientes
				coeficientes.Add((int[])columnaCoeficientes.Clone());
				
			}

			List<double[]> resultado = new List<double[]>();
			//Transformando el resultado
			foreach (var _coeficientes in coeficientes) {

				//Cantidad de tipos de monedas
				double[] _resultadoMondas = new double[_coeficientes.Sum(m => m)];

				int cantidad = 0;
				for (int i = 0; i < _coeficientes.Length; i++) {
					for (int j = 1; j <= _coeficientes[i]; j++) {
						_resultadoMondas[cantidad] = monedas[i];
						cantidad++;
					}
				}

				resultado.Add((double[])_resultadoMondas.Clone());
			}

			return resultado.ToArray();
		}
	}
}
