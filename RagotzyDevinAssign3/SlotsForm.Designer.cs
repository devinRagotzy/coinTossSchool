namespace RagotzyDevinAssign3
{
    partial class SlotsGameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.playerComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.addPlayerButton = new System.Windows.Forms.Button();
            this.remPlayerButton = new System.Windows.Forms.Button();
            this.numPlaysTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.playButton = new System.Windows.Forms.Button();
            this.totalButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.playerReportButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.displayLabel = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.coinPictureBox = new System.Windows.Forms.PictureBox();
            this.testButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.winnersComboBox = new System.Windows.Forms.ComboBox();
            this.fastPlayCheckBox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.exchangeButton = new System.Windows.Forms.Button();
            this.CurrencyComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coinPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // playerComboBox
            // 
            this.playerComboBox.FormattingEnabled = true;
            this.playerComboBox.Location = new System.Drawing.Point(21, 160);
            this.playerComboBox.Name = "playerComboBox";
            this.playerComboBox.Size = new System.Drawing.Size(101, 21);
            this.playerComboBox.TabIndex = 2;
            this.toolTip1.SetToolTip(this.playerComboBox, "If your name is not here type it in and click add player");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Player name";
            // 
            // addPlayerButton
            // 
            this.addPlayerButton.Location = new System.Drawing.Point(26, 199);
            this.addPlayerButton.Name = "addPlayerButton";
            this.addPlayerButton.Size = new System.Drawing.Size(75, 23);
            this.addPlayerButton.TabIndex = 3;
            this.addPlayerButton.Text = "&Add Player";
            this.addPlayerButton.UseVisualStyleBackColor = true;
            this.addPlayerButton.Click += new System.EventHandler(this.addPlayerButton_Click);
            // 
            // remPlayerButton
            // 
            this.remPlayerButton.Location = new System.Drawing.Point(26, 228);
            this.remPlayerButton.Name = "remPlayerButton";
            this.remPlayerButton.Size = new System.Drawing.Size(75, 23);
            this.remPlayerButton.TabIndex = 4;
            this.remPlayerButton.Text = "&Remove";
            this.remPlayerButton.UseVisualStyleBackColor = true;
            this.remPlayerButton.Click += new System.EventHandler(this.remPlayerButton_Click);
            // 
            // numPlaysTextBox
            // 
            this.numPlaysTextBox.Location = new System.Drawing.Point(22, 286);
            this.numPlaysTextBox.Name = "numPlaysTextBox";
            this.numPlaysTextBox.Size = new System.Drawing.Size(100, 20);
            this.numPlaysTextBox.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 270);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Number of Plays";
            // 
            // playButton
            // 
            this.playButton.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playButton.Location = new System.Drawing.Point(192, 286);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(83, 43);
            this.playButton.TabIndex = 9;
            this.playButton.Text = "&PLAY";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // totalButton
            // 
            this.totalButton.Location = new System.Drawing.Point(186, 335);
            this.totalButton.Name = "totalButton";
            this.totalButton.Size = new System.Drawing.Size(94, 34);
            this.totalButton.TabIndex = 10;
            this.totalButton.Text = "Prize Totals";
            this.totalButton.UseVisualStyleBackColor = true;
            this.totalButton.Click += new System.EventHandler(this.totalButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(700, 385);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(77, 53);
            this.exitButton.TabIndex = 17;
            this.exitButton.Text = "&Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(22, 346);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 7;
            this.saveButton.Text = "Save Info";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // playerReportButton
            // 
            this.playerReportButton.Location = new System.Drawing.Point(22, 385);
            this.playerReportButton.Name = "playerReportButton";
            this.playerReportButton.Size = new System.Drawing.Size(89, 23);
            this.playerReportButton.TabIndex = 8;
            this.playerReportButton.Text = "Player Report";
            this.playerReportButton.UseVisualStyleBackColor = true;
            this.playerReportButton.Click += new System.EventHandler(this.playerReportButton_Click);
            // 
            // displayLabel
            // 
            this.displayLabel.AutoSize = true;
            this.displayLabel.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayLabel.Location = new System.Drawing.Point(172, 25);
            this.displayLabel.Name = "displayLabel";
            this.displayLabel.Size = new System.Drawing.Size(103, 13);
            this.displayLabel.TabIndex = 18;
            this.displayLabel.Text = "displayLabel";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // coinPictureBox
            // 
            this.errorProvider1.SetIconAlignment(this.coinPictureBox, System.Windows.Forms.ErrorIconAlignment.TopLeft);
            this.coinPictureBox.Image = global::RagotzyDevinAssign3.Properties.Resources.coinflip;
            this.coinPictureBox.Location = new System.Drawing.Point(416, 176);
            this.coinPictureBox.Name = "coinPictureBox";
            this.coinPictureBox.Size = new System.Drawing.Size(105, 192);
            this.coinPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.coinPictureBox.TabIndex = 15;
            this.coinPictureBox.TabStop = false;
            // 
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(137, 415);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(75, 23);
            this.testButton.TabIndex = 11;
            this.testButton.Text = "&TEST";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(144, 242);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(192, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "Click to set up account";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // timer1
            // 
            this.timer1.Interval = 1400;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 30;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // winnersComboBox
            // 
            this.winnersComboBox.FormattingEnabled = true;
            this.winnersComboBox.Location = new System.Drawing.Point(571, 112);
            this.winnersComboBox.Name = "winnersComboBox";
            this.winnersComboBox.Size = new System.Drawing.Size(181, 21);
            this.winnersComboBox.TabIndex = 13;
            // 
            // fastPlayCheckBox
            // 
            this.fastPlayCheckBox.AutoSize = true;
            this.fastPlayCheckBox.Location = new System.Drawing.Point(21, 78);
            this.fastPlayCheckBox.Name = "fastPlayCheckBox";
            this.fastPlayCheckBox.Size = new System.Drawing.Size(120, 30);
            this.fastPlayCheckBox.TabIndex = 0;
            this.fastPlayCheckBox.Text = "Click to play without\r\ncoin animation.";
            this.fastPlayCheckBox.UseVisualStyleBackColor = true;
            this.fastPlayCheckBox.CheckedChanged += new System.EventHandler(this.fastPlayCheckBox_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(568, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "List of top scores";
            // 
            // exchangeButton
            // 
            this.exchangeButton.Location = new System.Drawing.Point(571, 213);
            this.exchangeButton.Name = "exchangeButton";
            this.exchangeButton.Size = new System.Drawing.Size(77, 29);
            this.exchangeButton.TabIndex = 16;
            this.exchangeButton.Text = "exchange";
            this.exchangeButton.UseVisualStyleBackColor = true;
            this.exchangeButton.Click += new System.EventHandler(this.exchangeButton_Click);
            // 
            // CurrencyComboBox
            // 
            this.CurrencyComboBox.FormattingEnabled = true;
            this.CurrencyComboBox.Location = new System.Drawing.Point(571, 186);
            this.CurrencyComboBox.Name = "CurrencyComboBox";
            this.CurrencyComboBox.Size = new System.Drawing.Size(121, 21);
            this.CurrencyComboBox.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(568, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 39);
            this.label5.TabIndex = 14;
            this.label5.Text = "Once you have won a prize\r\nyou could also exchange it \r\nfor any currency!";
            // 
            // SlotsGameForm
            // 
            this.AcceptButton = this.playButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CurrencyComboBox);
            this.Controls.Add(this.exchangeButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.fastPlayCheckBox);
            this.Controls.Add(this.winnersComboBox);
            this.Controls.Add(this.coinPictureBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.displayLabel);
            this.Controls.Add(this.playerReportButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.totalButton);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numPlaysTextBox);
            this.Controls.Add(this.remPlayerButton);
            this.Controls.Add(this.addPlayerButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.playerComboBox);
            this.Name = "SlotsGameForm";
            this.Text = "Best Ever Games of Chance";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.slotsForm_Closing);
            this.Load += new System.EventHandler(this.SlotsGameForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coinPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox playerComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addPlayerButton;
        private System.Windows.Forms.Button remPlayerButton;
        private System.Windows.Forms.TextBox numPlaysTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button totalButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button playerReportButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label displayLabel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox coinPictureBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ComboBox winnersComboBox;
        private System.Windows.Forms.CheckBox fastPlayCheckBox;
        private System.Windows.Forms.Button exchangeButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CurrencyComboBox;
    }
}

