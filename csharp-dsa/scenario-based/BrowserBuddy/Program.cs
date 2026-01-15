//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
namespace BrowserBuddy
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			BrowserMain browserMain = new BrowserMain();
			browserMain.Start();
		}
	}
}