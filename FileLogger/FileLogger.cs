using LoggerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLogger
{
	public class FileLogger:ILogger
	{
		const string _type = "FileLogger";
		public void Log(string content)
		{
			Console.WriteLine($"{_type}:{content}");
		}
	}
}
