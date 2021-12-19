using System;
using System.Windows.Forms;
using MapoxeO;
using System.IO;

namespace SplitterWin {
	public enum DataType : int {
		Byte = 0x1,
		KiloByte = 0x400,
		MegaByte = 0x100000,
//		GigaByte = 0x40000000
	}

	public partial class MainForm : Form {
		private readonly DataType[] Types = {DataType.Byte, DataType.KiloByte, DataType.MegaByte};
		private string filePathToSplit = string.Empty;
		private string[] filesPathesToUnite = null;
		private const string DefaultOnOutFileNameTextBox = "Имя файла";

		public MainForm() { InitializeComponent(); }

		private void Form1_Load(object sender, EventArgs e) {
			OutFileNameTextBox.Text = DefaultOnOutFileNameTextBox;
		}

		private void SplitButton_Click(object sender, EventArgs e) {
			if (!int.TryParse(InSize.Text, out int inSize)) {
				_ = MessageBox.Show($"  \"{InSize.Text}\" — не число!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (InTypeOfSize.SelectedIndex == -1) {
				_ = MessageBox.Show($"  Вы не выбрали единицу размера!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (inSize == 0) {
				_ = MessageBox.Show($"  Нельзя поделить файл на части по 0 {InTypeOfSize.Items[InTypeOfSize.SelectedIndex]}!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			if(!File.Exists(filePathToSplit)) {
				_ = MessageBox.Show($"  Файла по пути {filePathToSplit} не существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			var fsptr = new BinarySplitter(filePathToSplit);
			_ = fsptr.Split(inSize * (int)Types[this.InTypeOfSize.SelectedIndex], CreateDirectoryButton.Checked);
		}

		private void ChooseFileButton_Click(object sender, EventArgs e) {
			var openFileDialog = new OpenFileDialog() {
				Multiselect = false,
				CheckFileExists = true,
				CheckPathExists = true,
				Filter = "All files | *.*"
			};

			if(openFileDialog.ShowDialog() != DialogResult.OK)
				return;
			if (!File.Exists(openFileDialog.FileName)) {
				_ = MessageBox.Show($"  Файла по пути {openFileDialog.FileName} не существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			filePathToSplit = openFileDialog.FileName;
		}

		private void UniteButton_Click(object sender, EventArgs e) {
			if (filesPathesToUnite is null) {
				_ = MessageBox.Show($"  Вы не выбрали файлы!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			foreach(var filePath in filesPathesToUnite) {
				if(!File.Exists(filePath)) {
					_ = MessageBox.Show($"  Файла по пути {filePath} не существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}
			var funtr = new BinaryUniter(filesPathesToUnite);
			funtr.Unite(OutFileNameTextBox.Text == DefaultOnOutFileNameTextBox ?
				"outUniter.bin" : OutFileNameTextBox.Text);
			
		}

		private void ChooseFilesButton_Click(object sender, EventArgs e) {
			var openFileDialog = new OpenFileDialog() {
				Multiselect = true,
				CheckFileExists = true,
				CheckPathExists = true,
				Filter = "All files | *.*"
			};

			if(openFileDialog.ShowDialog() != DialogResult.OK)
				return;

			foreach (var filePath in openFileDialog.FileNames) {
				if(!File.Exists(filePath)) {
					_ = MessageBox.Show($"  Файла по пути {filePath} не существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}
			filesPathesToUnite = openFileDialog.FileNames;
		}
	}
}