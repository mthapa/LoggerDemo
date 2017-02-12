using LoggerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLogger
{
    public class DatabaseLogger: ILogger
	{
		const string _type = "DatabaseLogger";
		public void Log(string content)
		{
			Console.WriteLine($"{_type}:{content}");
		}
	}
}
