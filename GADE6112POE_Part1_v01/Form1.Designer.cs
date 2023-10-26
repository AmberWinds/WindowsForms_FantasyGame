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
            label1 = new Label();
            lblHeroHealth = new Label();
            lblAttackStat = new Label();
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
            // 
            // lblHeading
            // 
            lblHeading.AutoSize = true;
            lblHeading.Font = new Font("Gill Sans Ultra Bold", 19.8000011F, FontStyle.Italic, GraphicsUnit.Point);
            lblHeading.ForeColor = Color.DarkSlateGray;
            lblHeading.Location = new Point(551, 45);
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
            lblInstructions.Location = new Point(582, 150);
            lblInstructions.Name = "lblInstructions";
            lblInstructions.Size = new Size(234, 133);
            lblInstructions.TabIndex = 3;
            lblInstructions.Text = "Use the Arrow Keys and \r\nMake Your way to The Exit.\r\nWatch Out for Enemies \r\n(Use WASD on them) and\r\n See if You Can \r\nBeat All Ten Levels\r\n\r\n";
            lblInstructions.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.PowderBlue;
            label1.Font = new Font("Lucida Bright", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(623, 330);
            label1.Name = "label1";
            label1.Size = new Size(161, 168);
            label1.TabIndex = 4;
            label1.Text = "\r\n▒ - The exit\r\n█ - A wall tile \r\n▼ – The hero \r\n. – An empty tile \r\nϪ - Grunt Enemy\r\n\r\n\r\n";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblHeroHealth
            // 
            lblHeroHealth.AutoSize = true;
            lblHeroHealth.Font = new Font("Palatino Linotype", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblHeroHealth.Location = new Point(54, 611);
            lblHeroHealth.Name = "lblHeroHealth";
            lblHeroHealth.Size = new Size(73, 24);
            lblHeroHealth.TabIndex = 5;
            lblHeroHealth.Text = "Health:";
            lblHeroHealth.Click += lblHeroHealth_Click;
            // 
            // lblAttackStat
            // 
            lblAttackStat.AutoSize = true;
            lblAttackStat.Font = new Font("Palatino Linotype", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblAttackStat.Location = new Point(54, 644);
            lblAttackStat.Name = "lblAttackStat";
            lblAttackStat.Size = new Size(83, 24);
            lblAttackStat.TabIndex = 6;
            lblAttackStat.Text = "Attack: 5";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(860, 686);
            Controls.Add(lblAttackStat);
            Controls.Add(lblHeroHealth);
            Controls.Add(label1);
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
        private Label label1;
        private Label lblHeroHealth;
        private Label lblAttackStat;
    }
}