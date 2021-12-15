using System;
using System.IO;

namespace MapoxeO {
	public class BinarySplitter {
		public string FilePath { get; private set; } = null;

		public BinarySplitter(string filePath) {
			if (!File.Exists(filePath))
				throw new Exception($"File in path {filePath} doesn't exist");
			FilePath = filePath;
		}

		public int Split(int bytes, bool createDirectory = true) {
			if(File.Exists(FilePath) == false)
				throw new Exception($"File in path {FilePath} doesn't exist");
			var finfo = new FileInfo(FilePath);
			long num_size = finfo.Length / bytes;
			long ost = finfo.Length % bytes;

			string newPath = $"{Environment.CurrentDirectory}";
			if(createDirectory) {
				newPath += $"\\{finfo.Name} - Splitted";
				Directory.CreateDirectory(newPath);
			}

			try {
				using(var fin = new BinaryReader(File.Open(FilePath, FileMode.Open))) {
					if(num_size != 0) {
						for(long i = 0; i < num_size; i++) {
							using (var fout = new BinaryWriter(File.Open($"{newPath}\\{finfo.Name} - {i}.spt", FileMode.CreateNew))) {
								fout.Write(fin.ReadBytes(bytes));
							}
						}
					}

					if(ost != 0) {
						using (var fout = new BinaryWriter(File.Open($"{newPath}\\{finfo.Name} - {num_size}.spt", FileMode.CreateNew))) {
							fout.Write(fin.ReadBytes((int) ost));
						}
					}
				}
			}
			catch(Exception e) {
				if(Directory.Exists(newPath))
					Directory.Delete(newPath);
				throw new Exception(e.Message);
			}
			return (int) num_size + (ost > 0 ? 1 : 0);
		}
	}
}