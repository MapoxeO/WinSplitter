using System;
using System.IO;

namespace MapoxeO {
	public class BinFileUniter {
		public string[] FilesPaths { get; private set; }

		public BinFileUniter(params string[] paths) {
			FilesPaths = paths;
		}

		public void Unite(string fileOut = "\\out.bin") {
			using(var fout = new BinaryWriter(File.Open(fileOut, FileMode.Append))) {
				for(int i = 0; i < FilesPaths.Length; i++) {
					using(var fin = new BinaryReader(File.Open(FilesPaths[i], FileMode.Open))) {
						fout.Write(fin.ReadBytes((int) new FileInfo(FilesPaths[i]).Length));
					}
				}
			}
		}
	}
}