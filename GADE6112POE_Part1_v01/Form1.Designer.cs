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
            SuspendLayout();
            // 
            // lblDisplay
            // 
            lblDisplay.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblDisplay.Location = new Point(54, 45);
            lblDisplay.Name = "lblDisplay";
            lblDisplay.Size = new Size(436, 544);
            lblDisplay.TabIndex = 0;
            lblDisplay.Text = "Display Level Here";
            // 
            // lblHeading
            // 
            lblHeading.AutoSize = true;
            lblHeading.Font = new Font("Microsoft Sans Serif", 19.8000011F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lblHeading.ForeColor = Color.DarkSlateGray;
            lblHeading.Location = new Point(553, 45);
            lblHeading.Name = "lblHeading";
            lblHeading.Size = new Size(269, 78);
            lblHeading.TabIndex = 1;
            lblHeading.Text = "WELCOME TO \r\nTHE GAME";
            lblHeading.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBorder
            // 
            lblBorder.AutoSize = true;
            lblBorder.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblBorder.Location = new Point(509, 9);
            lblBorder.Name = "lblBorder";
            lblBorder.Size = new Size(17, 616);
            lblBorder.TabIndex = 2;
            lblBorder.Text = "|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n";
            // 
            // lblInstructions
            // 
            lblInstructions.AutoSize = true;
            lblInstructions.Font = new Font("Lucida Bright", 10.2F, FontStyle.Italic, GraphicsUnit.Point);
            lblInstructions.Location = new Point(569, 173);
            lblInstructions.Name = "lblInstructions";
            lblInstructions.Size = new Size(234, 114);
            lblInstructions.TabIndex = 3;
            lblInstructions.Text = "Use the Arrow Keys and \r\nMake Your way to The Exit.\r\nWatch Out for Grunts and\r\n See if You Can \r\nBeat All Ten Levels\r\n\r\n";
            lblInstructions.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.PowderBlue;
            label1.Font = new Font("Lucida Bright", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(610, 314);
            label1.Name = "label1";
            label1.Size = new Size(161, 168);
            label1.TabIndex = 4;
            label1.Text = "\r\n▒ - The exit\r\n█ - A wall tile \r\n▼ – The hero \r\n. – An empty tile \r\nϪ - Grunt Enemy\r\n\r\n\r\n";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(864, 636);
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
    }
}