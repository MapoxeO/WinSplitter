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
		private const string GeneralInfoCaption = "Общее";
		private const string SplitterInfoCaption = "О Разделителе";
		private const string UniterInfoCaption = "Об Объединителе";
		private const string GeneralInfoText = 
			"Это приложение создано для того,\n" +
			"чтобы разделить ваш файл на равные по размеру части.\t\n\n" +
			"Также оно может соединять файлы в цельный файл.";
		private const string SplitterInfoText =
			"Левая часть приложения посвещена разделителю.\n\n" +
			"После того, как вы нажали кнопку \"Выбрать файл\",\n" +
			"вы можете задать размер файлов, на которые\n" +
			"данный файл будет разбит, в поле \"Размер\",\n" +
			"правее которой есть список, в котором вы выберете\n" +
			"единицу измерения.\n" +
			"По умолчанию всегда стоит галочка в чекбоксе \"Создать папку\",\n" +
			"из-за чего после разделения будет создана папка в той папке,\n" +
			"где находится это приложение. Имя папки будет соответствовать\n" +
			"имени разделяемого файла.\n\n" +
			"Нажимая кнопку \"Разделить\", программа разделит выбранный\n" +
			"файл соответственно выбранными вами настройками.";
		private const string UniterInfoText =
			"Правая часть приложения посвещена объединителю.\n\n" +
			"Нажав кнопку \"Выбрать файлы\", в появившемся окне вы выбираете\n" +
			"некий список файлов, которые вы хотите соединить.\n" +
			"Список файлов будет отсортирован по той сортировке,\n" +
			"какая у вас имеется в \"Проводнике\", то есть стандартная.\n" +
			"Поле \"Имя файла\" содержит в себе название будущего файла.\n" +
			"По умолчанию имя выходного файла будет \"outUniter.bin\".\n" +
			"Вы можете объединить файлы под конкретным расширением:\n" +
			"написав нужное вам расширение в поле \"Имя файла\".\n" +
			"Примечание: всегда стоит записывать расширение выходного\n" +
			"файла, если вы выбираете произвольное имя.\n" +
			"Иначе будет создан файл без конкретного расширения,\n" +
			"но с определёным типом: &Enqueue in KMP.\n\n" +
			"Нажав кнопку \"Объединить\", программа объединит выбранные\n" +
			"файлы в один соответственно выбранными вами настройками.";

		public MainForm() { InitializeComponent(); }

		private void MainForm_Load(object sender, EventArgs e) {
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
			try {
				var fsptr = new BinarySplitter(filePathToSplit);
				var count = fsptr.Split(inSize * (int)Types[this.InTypeOfSize.SelectedIndex], CreateDirectoryButton.Checked);
				_ = MessageBox.Show($"Выбранный файл был разделён на {count} {(count > 1 ? "частей" : "часть")}", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.None);
			} catch (Exception ex) {
				_ = MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
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
			_ = MessageBox.Show($"Был создан файл по пути {funtr.FileOut}.", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.None);
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

		private void MenuInfoItemGeneral_Click(object sender, EventArgs e) {
			_ = MessageBox.Show( GeneralInfoText, GeneralInfoCaption,
								 MessageBoxButtons.OK,MessageBoxIcon.Information);
		}

		private void MenuInfoItemSplitter_Click(object sender, EventArgs e) {
			_ = MessageBox.Show( SplitterInfoText, SplitterInfoCaption,
								 MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void MenuInfoItemUniter_Click(object sender, EventArgs e) {
			_ = MessageBox.Show( UniterInfoText, UniterInfoCaption,
								 MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
}