using System;

namespace MapoxeO {
	class Program {
		static void Main() {
			var cin = Console.In;
			var cout = Console.Out;
			var cerr = Console.Error;

			cout.Write("Please, choose mode:\n\t1 - Splitter\n\t2 - Uniter.\n");
			var @case = int.Parse(cin.ReadLine());
			if (@case == 1) {
				cout.Write("Please, write down the path of that file, which you want to split.\n");
				var fsplitter = new BinarySplitter(cin.ReadLine());
				int totalFiles = fsplitter.Split(int.Parse(cin.ReadLine()));

				cout.Write($"{totalFiles} have been created.");
			} else if (@case == 2) {
				cout.Write("Please, write down the number of files, which you want to unite.\n");
				int lenght = int.Parse(cin.ReadLine());
				string[] pathes = new string[lenght];

				cout.Write("Please, write down the pathes of that files, which you want to unite.\n");
				for (int i = 0; i < lenght; i++) {
					pathes[i] = cin.ReadLine();
				}

				BinaryUniter funiter = new BinaryUniter(pathes);
				funiter.Warning += (string path, string cause) => {
					cout.Write($"[Warning]: {cause}: {path}");
				};
				funiter.Unite();

				cout.WriteLine($"Output file is {funiter.FileOut}");
			} else {
				cerr.WriteLine($"Option {@case} isn't defined.");
			}

			//----------------- Waiting -----------------//
			cout.Write($"\n\nPress any buton to exit program...");
			_ = Console.ReadKey();
		}
	}
}