using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema02
{
	class CompleteRange
	{
		public List<int> build(List<int> input) {

			//Obteniendo el numero mayor
			int max = input.Max();
			input = input.OrderBy(e => e).ToList();

			for (int i = 0; i <= max-1; i++) {

				if (input[i] != (i+1)) {
					input.Insert(i, i + 1);
				}
			}

			return input;
		}
	}
}
