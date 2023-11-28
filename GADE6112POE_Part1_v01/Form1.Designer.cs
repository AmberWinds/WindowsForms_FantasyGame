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
            lblDisplay = new Label();
            lblHeading = new Label();
            lblBorder = new Label();
            lblInstructions = new Label();
            lblKey = new Label();
            lblHeroHealth = new Label();
            lblLevelNumber = new Label();
            btnReset = new Button();
            btnExit = new Button();
            btnSaveGame = new Button();
            btnLoadGame = new Button();
            SuspendLayout();
            // 
            // lblDisplay
            // 
            lblDisplay.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblDisplay.Location = new Point(54, 45);
            lblDisplay.Name = "lblDisplay";
            lblDisplay.Size = new Size(436, 538);
            lblDisplay.TabIndex = 0;
            lblDisplay.Text = "Display Level Here";
            lblDisplay.Click += lblDisplay_Click;
            // 
            // lblHeading
            // 
            lblHeading.AutoSize = true;
            lblHeading.Font = new Font("Gill Sans Ultra Bold", 19.8000011F, FontStyle.Italic, GraphicsUnit.Point);
            lblHeading.ForeColor = Color.DarkSlateGray;
            lblHeading.Location = new Point(547, 34);
            lblHeading.Name = "lblHeading";
            lblHeading.Size = new Size(301, 96);
            lblHeading.TabIndex = 1;
            lblHeading.Text = "WELCOME TO \r\nTHE GAME";
            lblHeading.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBorder
            // 
            lblBorder.AutoSize = true;
            lblBorder.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblBorder.Location = new Point(496, 19);
            lblBorder.Name = "lblBorder";
            lblBorder.Size = new Size(17, 616);
            lblBorder.TabIndex = 2;
            lblBorder.Text = "|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n";
            // 
            // lblInstructions
            // 
            lblInstructions.AutoSize = true;
            lblInstructions.Font = new Font("Lucida Bright", 10.2F, FontStyle.Italic, GraphicsUnit.Point);
            lblInstructions.Location = new Point(582, 130);
            lblInstructions.Name = "lblInstructions";
            lblInstructions.Size = new Size(234, 133);
            lblInstructions.TabIndex = 3;
            lblInstructions.Text = "Use the Arrow Keys and \r\nMake Your way to The Exit.\r\nWatch Out for Enemies \r\n(Use WASD on them) and\r\n See if You Can \r\nBeat All Ten Levels\r\n\r\n";
            lblInstructions.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblKey
            // 
            lblKey.AutoSize = true;
            lblKey.BackColor = Color.PowderBlue;
            lblKey.Font = new Font("Lucida Bright", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            lblKey.ForeColor = SystemColors.ControlText;
            lblKey.Location = new Point(612, 263);
            lblKey.Name = "lblKey";
            lblKey.Size = new Size(175, 252);
            lblKey.TabIndex = 4;
            lblKey.Text = "\r\n▒ - The exit\r\n█ - A wall tile \r\n▼ – The hero \r\n. – An empty tile \r\nϪ - Grunt Enemy\r\nᐂ - Warlock Enemy\r\n§ - Tyrant Enemy\r\n+ - Health PickUp\r\n* - Attack Buff\r\n\r\n\r\n";
            lblKey.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblHeroHealth
            // 
            lblHeroHealth.AutoSize = true;
            lblHeroHealth.Font = new Font("Palatino Linotype", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblHeroHealth.Location = new Point(12, 654);
            lblHeroHealth.Name = "lblHeroHealth";
            lblHeroHealth.Size = new Size(73, 24);
            lblHeroHealth.TabIndex = 5;
            lblHeroHealth.Text = "Health:";
            lblHeroHealth.Click += lblHeroHealth_Click;
            // 
            // lblLevelNumber
            // 
            lblLevelNumber.AutoSize = true;
            lblLevelNumber.Font = new Font("Palatino Linotype", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblLevelNumber.Location = new Point(342, 654);
            lblLevelNumber.Name = "lblLevelNumber";
            lblLevelNumber.Size = new Size(65, 24);
            lblLevelNumber.TabIndex = 6;
            lblLevelNumber.Text = "Level: ";
            lblLevelNumber.Click += lblAttackStat_Click;
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.PowderBlue;
            btnReset.Font = new Font("Lucida Bright", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnReset.Location = new Point(547, 643);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(123, 35);
            btnReset.TabIndex = 7;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += btnReset_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.PowderBlue;
            btnExit.CausesValidation = false;
            btnExit.Font = new Font("Lucida Bright", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnExit.Location = new Point(720, 644);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(128, 34);
            btnExit.TabIndex = 8;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // btnSaveGame
            // 
            btnSaveGame.BackColor = Color.PowderBlue;
            btnSaveGame.CausesValidation = false;
            btnSaveGame.Font = new Font("Lucida Bright", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnSaveGame.Location = new Point(612, 530);
            btnSaveGame.Name = "btnSaveGame";
            btnSaveGame.Size = new Size(175, 34);
            btnSaveGame.TabIndex = 9;
            btnSaveGame.Text = "Save Game";
            btnSaveGame.UseVisualStyleBackColor = false;
            btnSaveGame.Click += btnSaveGame_Click;
            // 
            // btnLoadGame
            // 
            btnLoadGame.BackColor = Color.PowderBlue;
            btnLoadGame.CausesValidation = false;
            btnLoadGame.Font = new Font("Lucida Bright", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnLoadGame.Location = new Point(612, 570);
            btnLoadGame.Name = "btnLoadGame";
            btnLoadGame.Size = new Size(175, 34);
            btnLoadGame.TabIndex = 10;
            btnLoadGame.Text = "Load Game";
            btnLoadGame.UseVisualStyleBackColor = false;
            btnLoadGame.Click += btnLoadGame_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(860, 686);
            Controls.Add(btnLoadGame);
            Controls.Add(btnSaveGame);
            Controls.Add(btnExit);
            Controls.Add(btnReset);
            Controls.Add(lblLevelNumber);
            Controls.Add(lblHeroHealth);
            Controls.Add(lblKey);
            Controls.Add(lblInstructions);
            Controls.Add(lblBorder);
            Controls.Add(lblHeading);
            Controls.Add(lblDisplay);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDisplay;
        private Label lblHeading;
        private Label lblBorder;
        private Label lblInstructions;
        private Label lblKey;
        private Label lblHeroHealth;
        private Label lblLevelNumber;
        private Button btnReset;
        private Button btnExit;
        private Button btnSaveGame;
        private Button btnLoadGame;
    }
}