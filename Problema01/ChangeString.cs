using System;

namespace Problema01
{
	internal class ChangeString
	{

		public string abecedario = "abcdefghijklmnñopqrstuvwxyz";

		public string build(string s)
		{
			string tempS = "";

			int index = 0;
			int sizeS = abecedario.Length;
			

			foreach(char letter in s) { 

				//guardando el caracter y convertiendolo a minusculas para la busqueda
				char lLower = Char.ToLower(letter);

				index = abecedario.IndexOf(lLower);

				int newIndex = index + 1;

				//evitar el fuera de rango
				newIndex = sizeS > newIndex ? newIndex : 0;

				if (index == -1)
				{
					tempS += letter;
				}
				else
				{

					tempS += (lLower.CompareTo(letter) == 0) ? abecedario.Substring(newIndex, 1) : abecedario.Substring(newIndex, 1).ToUpper();
				}
			}


			return tempS;
		}

	}
}

