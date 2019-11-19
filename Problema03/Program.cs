using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema03
{
	class Program
	{
		static void Main(string[] args)
		{
			MoneyParts moneyParts = new MoneyParts();

			string moneda = "305";
			moneyParts.build(moneda);
		}
	}
}
