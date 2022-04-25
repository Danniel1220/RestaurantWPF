using System;

public class IOManager
{
	public IOManager()
	{
		readFile();
	}

	public void readFile()
    {
		string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Resources\MenuTabs.txt");
		string[] files = File.ReadAllLines(path);

		System.Console.WriteLine("test");
	}
}
