using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace RestaurantPAOOWPF
{
    internal class IOManager
    {
		public IOManager()
		{

		}

		public static string[] readFileByLines(string path)
		{
			return File.ReadAllLines(path);
		}
	}
}
