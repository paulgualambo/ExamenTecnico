using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema01
{
	class Program
	{
		static void Main(string[] args)
		{
			ChangeString cs = new ChangeString();

			//cs.build("123 abcd**12");
			Console.Write(cs.build("123 abcd*3") == "123 bcde*3");
			Console.Write(cs.build("**Casa 52") == "**Dbtb 52");
		}
	}
}
