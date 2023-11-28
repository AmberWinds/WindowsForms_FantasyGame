namespace GADE6112POE_Part1_v01
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
            this.lblDisplay = new System.Windows.Forms.Label();
            this.lblHeading = new System.Windows.Forms.Label();
            this.lblBorder = new System.Windows.Forms.Label();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.lblKey = new System.Windows.Forms.Label();
            this.lblHeroHealth = new System.Windows.Forms.Label();
            this.lblAttackStat = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SaveGameButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDisplay
            // 
            this.lblDisplay.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDisplay.Location = new System.Drawing.Point(54, 45);
            this.lblDisplay.Name = "lblDisplay";
            this.lblDisplay.Size = new System.Drawing.Size(436, 538);
            this.lblDisplay.TabIndex = 0;
            this.lblDisplay.Text = "Display Level Here";
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lblHeading.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblHeading.Location = new System.Drawing.Point(551, 45);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(258, 78);
            this.lblHeading.TabIndex = 1;
            this.lblHeading.Text = "WELCOME TO \r\nTHE GAME";
            this.lblHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBorder
            // 
            this.lblBorder.AutoSize = true;
            this.lblBorder.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblBorder.Location = new System.Drawing.Point(496, 19);
            this.lblBorder.Name = "lblBorder";
            this.lblBorder.Size = new System.Drawing.Size(17, 616);
            this.lblBorder.TabIndex = 2;
            this.lblBorder.Text = "|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n";
            // 
            // lblInstructions
            // 
            this.lblInstructions.AutoSize = true;
            this.lblInstructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lblInstructions.Location = new System.Drawing.Point(582, 150);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(211, 140);
            this.lblInstructions.TabIndex = 3;
            this.lblInstructions.Text = "Use the Arrow Keys and \r\nMake Your way to The Exit.\r\nWatch Out for Enemies \r\n(Use" +
    " WASD on them) and\r\n See if You Can \r\nBeat All Ten Levels\r\n\r\n";
            this.lblInstructions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.BackColor = System.Drawing.Color.PowderBlue;
            this.lblKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblKey.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblKey.Location = new System.Drawing.Point(623, 283);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(164, 242);
            this.lblKey.TabIndex = 4;
            this.lblKey.Text = "\r\n▒ - The exit\r\n█ - A wall tile \r\n▼ – The hero \r\n. – An empty tile \r\nϪ - Grunt En" +
    "emy\r\nᐂ - Warlock Enemy\r\n§ - Tyrant Enemy\r\n+ - Health PickUp\r\n\r\n\r\n";
            this.lblKey.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHeroHealth
            // 
            this.lblHeroHealth.AutoSize = true;
            this.lblHeroHealth.Font = new System.Drawing.Font("Palatino Linotype", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblHeroHealth.Location = new System.Drawing.Point(54, 611);
            this.lblHeroHealth.Name = "lblHeroHealth";
            this.lblHeroHealth.Size = new System.Drawing.Size(73, 24);
            this.lblHeroHealth.TabIndex = 5;
            this.lblHeroHealth.Text = "Health:";
            // 
            // lblAttackStat
            // 
            this.lblAttackStat.AutoSize = true;
            this.lblAttackStat.Font = new System.Drawing.Font("Palatino Linotype", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAttackStat.Location = new System.Drawing.Point(54, 644);
            this.lblAttackStat.Name = "lblAttackStat";
            this.lblAttackStat.Size = new System.Drawing.Size(83, 24);
            this.lblAttackStat.TabIndex = 6;
            this.lblAttackStat.Text = "Attack: 5";
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.PowderBlue;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnReset.Location = new System.Drawing.Point(623, 548);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(161, 35);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.PowderBlue;
            this.btnExit.CausesValidation = false;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnExit.Location = new System.Drawing.Point(623, 601);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(161, 34);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            // 
            // SaveGameButton
            // 
            this.SaveGameButton.BackColor = System.Drawing.Color.PowderBlue;
            this.SaveGameButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SaveGameButton.Location = new System.Drawing.Point(754, 12);
            this.SaveGameButton.Name = "SaveGameButton";
            this.SaveGameButton.Size = new System.Drawing.Size(94, 29);
            this.SaveGameButton.TabIndex = 9;
            this.SaveGameButton.Text = "Save";
            this.SaveGameButton.UseVisualStyleBackColor = false;
            this.SaveGameButton.Click += new System.EventHandler(this.SaveGameButton_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 686);
            this.Controls.Add(this.SaveGameButton);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lblAttackStat);
            this.Controls.Add(this.lblHeroHealth);
            this.Controls.Add(this.lblKey);
            this.Controls.Add(this.lblInstructions);
            this.Controls.Add(this.lblBorder);
            this.Controls.Add(this.lblHeading);
            this.Controls.Add(this.lblDisplay);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblDisplay;
        private Label lblHeading;
        private Label lblBorder;
        private Label lblInstructions;
        private Label lblKey;
        private Label lblHeroHealth;
        private Label lblAttackStat;
        private Button btnReset;
        private Button btnExit;
        private SaveFileDialog saveFileDialog1;
        private Button SaveGameButton;
    }
}