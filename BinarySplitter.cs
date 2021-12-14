using System;
using System.IO;
using System.Collections.Generic;

namespace MapoxeO {
	public class BinarySplitter {
		public string FilePath { get; private set; }
		public List<string>? OutPathes { get; private set; } = null;
		
		public BinarySplitter(string filePath) {
			FilePath = filePath;
		}
		
		public void Split(uint bytes, bool createDirectory = true) {
			if (File.Exists(FilePath) == false)
				throw new Exception($"File in path {FilePath} doesn't exist");
			var finfo = new FileInfo(FilePath);
			uint num_size = finfo.Size / bytes;
			uint ost = finfo.Size % bytes;
			
			OutPathes = new List<string>(num_size + ost);
			
			string newPath = null;
			string directoryPath = null;
			if (createDirectory) {
				directoryPath = $"{Environment.CurrentDirectory}\\{FilePath} - Splitted";
				Directory.CreateDirectory(directoryPath);
			} else {
				newPath = $"{FilePath.Enviroment}\\";
			}
			
			try {
				using (var fin = BinaryReader(File.Open(FilePath, FileMode.Open))) {
					if (num_size != 0) {
						for (uint i = 0; i < num_size; i++) {
							string fp = $"{directoryPath}\\{FilePath}-{i + 1}";
							OutPathes.Append(fp);
							using (var fout = new BinaryReader(File.Open(fp, FileMode.CreateNew)) {
								fout.Write(fin.ReadBytes(bytes));
							}
						}
					}
					if (ost != 0) {
						string fp = $"{directoryPath}\\{FilePath}-{num_size}";
						OutPathes.Append(fp);
						using (var fout = new BinaryReader(File.Open(fp, FileMode.CreateNew))) {
							fout.Write(fin.ReadBytes(ost));
						}
					}
				}
			} catch (Exception e) {
				if (Directory.Exists(directoryPath))
					Directory.Delete(directoryPath);
				throw new Exception(e.What);
			}
		}
	}
}