using System;
using System.IO;

namespace MapoxeO {
	public class BinFileSplitter {
		public string FilePath { get; private set; }
		public BinFileSplitter(string filePath) {
			FilePath = filePath;
		}

		public void Split(uint number, bool createDirectory = false) {
			var directoryPath = "";

			if (createDirectory) {
				directoryPath = $"{Environment.CurrentDirectory}\\{FilePath} - Splitted";
				Directory.CreateDirectory(directoryPath);
			}
			try {
				using (BinaryReader br = new BinaryReader(File.Open(FilePath, FileMode.Open))) {
					long fileSize = new FileInfo(FilePath).Length;
					long eachNewFileSize = fileSize / number;

					if (eachNewFileSize <= 1) {
						for (long i = 0; i < fileSize; i++)
							using (BinaryWriter bw = new BinaryWriter(File.Open($"{directoryPath}\\{i}-{FilePath}", FileMode.CreateNew)))
								bw.Write(br.ReadByte());
					}
					else {
						for (uint i = 0; i < number; i++)
							using (BinaryWriter bw = new BinaryWriter(File.Open($"{directoryPath}\\{i}-{FilePath}", FileMode.CreateNew))) {
								if ((float) fileSize / number != eachNewFileSize && i == 0)
									bw.Write(br.ReadBytes((int) eachNewFileSize + 1));
								else
									bw.Write(br.ReadBytes((int) eachNewFileSize));
							}
					}
				}
			} catch (Exception e) {
				if (Directory.Exists(directoryPath))
					Directory.Delete(directoryPath);
				throw new Exception(e.Message);
			}
		}
	}
}