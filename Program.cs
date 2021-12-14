using System;

namespace MapoxeO {
	class Program {
		static void Main() {
			var cin = Console.In;
			var cout = Console.Out;
			var fsplitter = new BinarySplitter(cin.ReadLine());
			cout.WriteLine(fsplitter.Split(int.Parse(cin.ReadLine())));
		}
	}
}