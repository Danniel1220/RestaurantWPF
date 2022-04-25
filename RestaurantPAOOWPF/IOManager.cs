using System;
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

		public static async void printReceipt(string receiptString)
        {
			string finalReceiptString = "# BON FISCAL \n\n";
			finalReceiptString += receiptString;

			string receiptFileName = "Bonuri/BonFiscal " + DateTime.Now.ToString("yyyy-dd-M HH-mm-ss") + ".txt";

			await File.WriteAllTextAsync(receiptFileName, finalReceiptString);
        }
	}
}
