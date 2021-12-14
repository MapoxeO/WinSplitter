using System;
using System.IO;

namespace MapoxeO {
	public class BinaryUniter {
		public string[]? Pathes { get; private set; } = null;
		
		public BinaryUniter(params string[] pathes) {
			Pathes = pathes;
		}
		
		public void Unite(string fileName = "outUniter.bin") {
			string currDirectory = Enviroment.CurrentDirectory;
			
			using(var fout = new BinaryWriter(File.Open($"{currDirectory}\\{fileName}", FileMode.Append))) {
				for(int i = 0; i < FilesPaths.Length; i++) {
					using(var fin = new BinaryReader(File.Open(FilesPaths[i], FileMode.Open))) {
						fout.Write(fin.ReadBytes((int) new FileInfo(FilesPaths[i]).Length));
					}
				}
			}
		}
	}
}