
namespace SplitterWin {
	partial class MainForm {
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.InSize = new System.Windows.Forms.TextBox();
			this.SplitButton = new System.Windows.Forms.Button();
			this.SplitterPanel = new System.Windows.Forms.Panel();
			this.ChooseFileButton = new System.Windows.Forms.Button();
			this.CreateDirectoryButton = new System.Windows.Forms.CheckBox();
			this.InTypeOfSize = new System.Windows.Forms.ComboBox();
			this.SplitterLabel = new System.Windows.Forms.Label();
			this.UniterPanel = new System.Windows.Forms.Panel();
			this.OutFileNameTextBox = new System.Windows.Forms.TextBox();
			this.ChooseFilesButton = new System.Windows.Forms.Button();
			this.UniteButton = new System.Windows.Forms.Button();
			this.UniterLabel = new System.Windows.Forms.Label();
			this.SplitterPanel.SuspendLayout();
			this.UniterPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// InSize
			// 
			this.InSize.Location = new System.Drawing.Point(36, 15);
			this.InSize.Name = "InSize";
			this.InSize.Size = new System.Drawing.Size(100, 20);
			this.InSize.TabIndex = 0;
			this.InSize.Text = "Размер";
			// 
			// SplitButton
			// 
			this.SplitButton.Location = new System.Drawing.Point(79, 92);
			this.SplitButton.Name = "SplitButton";
			this.SplitButton.Size = new System.Drawing.Size(141, 23);
			this.SplitButton.TabIndex = 3;
			this.SplitButton.Text = "Разделить";
			this.SplitButton.UseVisualStyleBackColor = true;
			this.SplitButton.Click += new System.EventHandler(this.SplitButton_Click);
			// 
			// SplitterPanel
			// 
			this.SplitterPanel.Controls.Add(this.ChooseFileButton);
			this.SplitterPanel.Controls.Add(this.CreateDirectoryButton);
			this.SplitterPanel.Controls.Add(this.InTypeOfSize);
			this.SplitterPanel.Controls.Add(this.SplitButton);
			this.SplitterPanel.Controls.Add(this.InSize);
			this.SplitterPanel.Location = new System.Drawing.Point(12, 38);
			this.SplitterPanel.Name = "SplitterPanel";
			this.SplitterPanel.Size = new System.Drawing.Size(301, 155);
			this.SplitterPanel.TabIndex = 1;
			// 
			// ChooseFileButton
			// 
			this.ChooseFileButton.Location = new System.Drawing.Point(170, 42);
			this.ChooseFileButton.Name = "ChooseFileButton";
			this.ChooseFileButton.Size = new System.Drawing.Size(99, 23);
			this.ChooseFileButton.TabIndex = 4;
			this.ChooseFileButton.Text = "Выбрать файл";
			this.ChooseFileButton.UseVisualStyleBackColor = true;
			this.ChooseFileButton.Click += new System.EventHandler(this.ChooseFileButton_Click);
			// 
			// CreateDirectoryButton
			// 
			this.CreateDirectoryButton.AutoSize = true;
			this.CreateDirectoryButton.Checked = true;
			this.CreateDirectoryButton.CheckState = System.Windows.Forms.CheckState.Checked;
			this.CreateDirectoryButton.Location = new System.Drawing.Point(36, 46);
			this.CreateDirectoryButton.Name = "CreateDirectoryButton";
			this.CreateDirectoryButton.Size = new System.Drawing.Size(100, 17);
			this.CreateDirectoryButton.TabIndex = 2;
			this.CreateDirectoryButton.Text = "Создать папку";
			this.CreateDirectoryButton.UseVisualStyleBackColor = true;
			// 
			// InTypeOfSize
			// 
			this.InTypeOfSize.FormattingEnabled = true;
			this.InTypeOfSize.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.InTypeOfSize.Items.AddRange(new object[] {
            "Байт",
            "КБайт",
            "МБайт"});
			this.InTypeOfSize.Location = new System.Drawing.Point(184, 15);
			this.InTypeOfSize.Name = "InTypeOfSize";
			this.InTypeOfSize.Size = new System.Drawing.Size(75, 21);
			this.InTypeOfSize.TabIndex = 2;
			// 
			// SplitterLabel
			// 
			this.SplitterLabel.AutoSize = true;
			this.SplitterLabel.Location = new System.Drawing.Point(129, 22);
			this.SplitterLabel.Name = "SplitterLabel";
			this.SplitterLabel.Size = new System.Drawing.Size(68, 13);
			this.SplitterLabel.TabIndex = 5;
			this.SplitterLabel.Text = "Разделение";
			// 
			// UniterPanel
			// 
			this.UniterPanel.Controls.Add(this.OutFileNameTextBox);
			this.UniterPanel.Controls.Add(this.ChooseFilesButton);
			this.UniterPanel.Controls.Add(this.UniteButton);
			this.UniterPanel.Location = new System.Drawing.Point(361, 39);
			this.UniterPanel.Name = "UniterPanel";
			this.UniterPanel.Size = new System.Drawing.Size(300, 154);
			this.UniterPanel.TabIndex = 6;
			// 
			// OutFileNameTextBox
			// 
			this.OutFileNameTextBox.Location = new System.Drawing.Point(36, 39);
			this.OutFileNameTextBox.Name = "OutFileNameTextBox";
			this.OutFileNameTextBox.Size = new System.Drawing.Size(100, 20);
			this.OutFileNameTextBox.TabIndex = 5;
			this.OutFileNameTextBox.Text = "Имя файла";
			// 
			// ChooseFilesButton
			// 
			this.ChooseFilesButton.Location = new System.Drawing.Point(179, 39);
			this.ChooseFilesButton.Name = "ChooseFilesButton";
			this.ChooseFilesButton.Size = new System.Drawing.Size(99, 23);
			this.ChooseFilesButton.TabIndex = 5;
			this.ChooseFilesButton.Text = "Выбрать файлы";
			this.ChooseFilesButton.UseVisualStyleBackColor = true;
			this.ChooseFilesButton.Click += new System.EventHandler(this.ChooseFilesButton_Click);
			// 
			// UniteButton
			// 
			this.UniteButton.Location = new System.Drawing.Point(90, 93);
			this.UniteButton.Name = "UniteButton";
			this.UniteButton.Size = new System.Drawing.Size(140, 21);
			this.UniteButton.TabIndex = 5;
			this.UniteButton.Text = "Объединить";
			this.UniteButton.UseVisualStyleBackColor = true;
			this.UniteButton.Click += new System.EventHandler(this.UniteButton_Click);
			// 
			// UniterLabel
			// 
			this.UniterLabel.AutoSize = true;
			this.UniterLabel.Location = new System.Drawing.Point(486, 22);
			this.UniterLabel.Name = "UniterLabel";
			this.UniterLabel.Size = new System.Drawing.Size(76, 13);
			this.UniterLabel.TabIndex = 7;
			this.UniterLabel.Text = "Объединение";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(677, 207);
			this.Controls.Add(this.UniterLabel);
			this.Controls.Add(this.UniterPanel);
			this.Controls.Add(this.SplitterLabel);
			this.Controls.Add(this.SplitterPanel);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "FileSplitter";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.SplitterPanel.ResumeLayout(false);
			this.SplitterPanel.PerformLayout();
			this.UniterPanel.ResumeLayout(false);
			this.UniterPanel.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox InSize;
		private System.Windows.Forms.Button SplitButton;
		private System.Windows.Forms.Panel SplitterPanel;
		private System.Windows.Forms.ComboBox InTypeOfSize;
		private System.Windows.Forms.CheckBox CreateDirectoryButton;
		private System.Windows.Forms.Button ChooseFileButton;
		private System.Windows.Forms.Label SplitterLabel;
		private System.Windows.Forms.Panel UniterPanel;
		private System.Windows.Forms.Label UniterLabel;
		private System.Windows.Forms.TextBox OutFileNameTextBox;
		private System.Windows.Forms.Button ChooseFilesButton;
		private System.Windows.Forms.Button UniteButton;
	}
}

