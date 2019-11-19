using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema02
{
	class Program
	{
		static void Main(string[] args)
		{
			CompleteRange cs = new CompleteRange();

			cs.build(new List<int> { 2, 1, 4, 5 });
			cs.build(new List<int> { 4, 2, 9 });
			cs.build(new List<int> { 58, 60, 55 });

		}
	}
}
