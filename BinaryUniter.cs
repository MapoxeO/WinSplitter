using System;
using System.IO;

namespace MapoxeO {
	public class BinaryUniter {
		public string[] Pathes { get; private set; } = null;
		public static const string DefaultFileExtension = ".spt";
		
		public delegate void WarningHandler(string path);
		public event WarningHandler Warning;
		
		public BinaryUniter(params string[] pathes) {
			Exists();
			Pathes = pathes;
		}
		
		private void Exists() {
			for (int i = 0; i < Pathes.Length; i++) {
				if (!File.Exists(Pathes[i]))
					throw new Exception($"File in path {Pathes[i]} doesn't exist.");
				if (Pathes[i].Substring(Pathes[i].Length - 4) != DefaultFileExtension)
					WarningHandler?.Invoke(path);
			}
		}
		
		public void Unite(string fileName = "outUniter.bin") {
			Exists();
			string newPath = Enviroment.CurrentDirectory;
			
			try {
				using (var fout = new BinaryWriter(File.Open($"{newPath}\\{fileName}", FileMode.Append))) {
					for(int i = 0; i < FilesPaths.Length; i++) {
						using (var fin = new BinaryReader(File.Open(FilesPaths[i], FileMode.Open))) {
							var finfo = new FileInfo(FilesPaths[i]);
							fout.Write(fin.ReadBytes((int) finfo.Length);
						}
					}
				}
			} catch (Exception e) {
				throew new Exception(e.Message);
			}
		}
	}
}