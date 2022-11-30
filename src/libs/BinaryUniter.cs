using System;
using System.IO;

namespace MapoxeO {
	public class BinaryUniter {
		public string[] Pathes { get; private set; } = null;
		public string FileOut { get; private set; } = null;
		public static string DefaultFileExtension { get; } = ".spt";

		public delegate void WarningHandler(string path, string cause);
		public event WarningHandler Warning;

		public BinaryUniter(params string[] pathes) {
			Pathes = pathes;
			Exists();
		}

		private void Exists() {
			for(int i = 0; i < Pathes.Length; i++) {
				if(!File.Exists(Pathes[i]))
					throw new Exception($"File in path {Pathes[i]} doesn't exist.");
				if(Pathes[i].Substring(Pathes[i].Length - 4) != DefaultFileExtension)
					Warning?.Invoke(Pathes[i], "file is in incorrect extension");
			}
		}

		public void Unite(string fileName = "outUniter.bin") {
			Exists();
			string newPath = Environment.CurrentDirectory;

			try {
				using(var fout = new BinaryWriter(File.Open($"{newPath}\\{fileName}", FileMode.Create))) {
					for(int i = 0; i < Pathes.Length; i++) {
						using(var fin = new BinaryReader(File.Open(Pathes[i], FileMode.Open))) {
							var finfo = new FileInfo(Pathes[i]);
							fout.Write(fin.ReadBytes((int) finfo.Length));
						}
					}
				}
			}
			catch(Exception e) {
				throw new Exception(e.Message);
			}
			FileOut = $"{newPath}\\{fileName}";
		}
	}
}