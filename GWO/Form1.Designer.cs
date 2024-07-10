namespace GWO
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            startButton = new Button();
            populationSizeBox = new TextBox();
            maxIterationsBox = new TextBox();
            lowerBoundBox = new TextBox();
            upperBoundBox = new TextBox();
            pictureBox = new PictureBox();
            functionSelector = new ComboBox();
            stopButton = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 10);
            label1.Name = "label1";
            label1.Size = new Size(114, 15);
            label1.TabIndex = 0;
            label1.Text = "Размер популяции:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 40);
            label2.Name = "label2";
            label2.Size = new Size(64, 15);
            label2.TabIndex = 1;
            label2.Text = "Итераций:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 70);
            label3.Name = "label3";
            label3.Size = new Size(102, 15);
            label3.TabIndex = 2;
            label3.Text = "Нижняя граница:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(10, 100);
            label4.Name = "label4";
            label4.Size = new Size(103, 15);
            label4.TabIndex = 3;
            label4.Text = "Верхняя граница:";
            // 
            // startButton
            // 
            startButton.Location = new Point(10, 158);
            startButton.Name = "startButton";
            startButton.Size = new Size(83, 23);
            startButton.TabIndex = 4;
            startButton.Text = "Начать";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // populationSizeBox
            // 
            populationSizeBox.Location = new Point(130, 10);
            populationSizeBox.Name = "populationSizeBox";
            populationSizeBox.Size = new Size(51, 23);
            populationSizeBox.TabIndex = 5;
            populationSizeBox.Text = "20";
            // 
            // maxIterationsBox
            // 
            maxIterationsBox.Location = new Point(130, 40);
            maxIterationsBox.Name = "maxIterationsBox";
            maxIterationsBox.Size = new Size(51, 23);
            maxIterationsBox.TabIndex = 6;
            maxIterationsBox.Text = "100";
            // 
            // lowerBoundBox
            // 
            lowerBoundBox.Location = new Point(130, 70);
            lowerBoundBox.Name = "lowerBoundBox";
            lowerBoundBox.Size = new Size(51, 23);
            lowerBoundBox.TabIndex = 7;
            lowerBoundBox.Text = "-10";
            // 
            // upperBoundBox
            // 
            upperBoundBox.Location = new Point(130, 100);
            upperBoundBox.Name = "upperBoundBox";
            upperBoundBox.Size = new Size(51, 23);
            upperBoundBox.TabIndex = 8;
            upperBoundBox.Text = "10";
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(12, 184);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(760, 400);
            pictureBox.TabIndex = 9;
            pictureBox.TabStop = false;
            // 
            // functionSelector
            // 
            functionSelector.DropDownStyle = ComboBoxStyle.DropDownList;
            functionSelector.FormattingEnabled = true;
            functionSelector.Items.AddRange(new object[] { "Сферическая функция", "Функция Растригина", "Функция Розенброка", "Функция Акли", "Функция Гриванка" });
            functionSelector.Location = new Point(10, 129);
            functionSelector.Name = "functionSelector";
            functionSelector.Size = new Size(171, 23);
            functionSelector.TabIndex = 10;
            // 
            // stopButton
            // 
            stopButton.Location = new Point(98, 158);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(83, 23);
            stopButton.TabIndex = 11;
            stopButton.Text = "Стоп";
            stopButton.UseVisualStyleBackColor = true;
            stopButton.Click += stopButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 585);
            Controls.Add(stopButton);
            Controls.Add(functionSelector);
            Controls.Add(pictureBox);
            Controls.Add(upperBoundBox);
            Controls.Add(lowerBoundBox);
            Controls.Add(maxIterationsBox);
            Controls.Add(populationSizeBox);
            Controls.Add(startButton);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Алгоритм серых волков";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button startButton;
        private TextBox populationSizeBox;
        private TextBox maxIterationsBox;
        private TextBox lowerBoundBox;
        private TextBox upperBoundBox;
        private PictureBox pictureBox;
        private ComboBox functionSelector;
        private Button stopButton;
    }
}
