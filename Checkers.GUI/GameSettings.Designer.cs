namespace Checkers.GUI
{
    partial class GameSettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Radio6 = new System.Windows.Forms.RadioButton();
            this.Radio8 = new System.Windows.Forms.RadioButton();
            this.Radio10 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Player2CheckBox = new System.Windows.Forms.CheckBox();
            this.Player1TextBox = new System.Windows.Forms.TextBox();
            this.Player2TextBox = new System.Windows.Forms.TextBox();
            this.DoneButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Board Size:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 37);
            this.label2.TabIndex = 0;
            this.label2.Text = "Players:";
            // 
            // Radio6
            // 
            this.Radio6.AccessibleName = "";
            this.Radio6.AutoSize = true;
            this.Radio6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Radio6.Location = new System.Drawing.Point(48, 80);
            this.Radio6.Name = "Radio6";
            this.Radio6.Size = new System.Drawing.Size(83, 36);
            this.Radio6.TabIndex = 1;
            this.Radio6.TabStop = true;
            this.Radio6.Text = "6x6";
            this.Radio6.UseVisualStyleBackColor = true;
            // 
            // Radio8
            // 
            this.Radio8.AccessibleName = "";
            this.Radio8.AutoSize = true;
            this.Radio8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Radio8.Location = new System.Drawing.Point(203, 80);
            this.Radio8.Name = "Radio8";
            this.Radio8.Size = new System.Drawing.Size(83, 36);
            this.Radio8.TabIndex = 1;
            this.Radio8.TabStop = true;
            this.Radio8.Text = "8x8";
            this.Radio8.UseVisualStyleBackColor = true;
            // 
            // Radio10
            // 
            this.Radio10.AccessibleName = "";
            this.Radio10.AutoSize = true;
            this.Radio10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Radio10.Location = new System.Drawing.Point(360, 80);
            this.Radio10.Name = "Radio10";
            this.Radio10.Size = new System.Drawing.Size(109, 36);
            this.Radio10.TabIndex = 1;
            this.Radio10.TabStop = true;
            this.Radio10.Text = "10x10";
            this.Radio10.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(41, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 37);
            this.label3.TabIndex = 0;
            this.label3.Text = "Player 1:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(42, 269);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 37);
            this.label4.TabIndex = 0;
            // 
            // Player2CheckBox
            // 
            this.Player2CheckBox.AccessibleName = "Player2CheckBox";
            this.Player2CheckBox.AutoSize = true;
            this.Player2CheckBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Player2CheckBox.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Player2CheckBox.Location = new System.Drawing.Point(48, 276);
            this.Player2CheckBox.Name = "Player2CheckBox";
            this.Player2CheckBox.Size = new System.Drawing.Size(149, 41);
            this.Player2CheckBox.TabIndex = 2;
            this.Player2CheckBox.Text = "Player 2:";
            this.Player2CheckBox.UseVisualStyleBackColor = true;
            this.Player2CheckBox.CheckedChanged += new System.EventHandler(this.Player2CheckBox_CheckedChanged);
            // 
            // Player1TextBox
            // 
            this.Player1TextBox.AccessibleName = "Player1TextBox";
            this.Player1TextBox.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Player1TextBox.Location = new System.Drawing.Point(220, 192);
            this.Player1TextBox.Name = "Player1TextBox";
            this.Player1TextBox.Size = new System.Drawing.Size(249, 43);
            this.Player1TextBox.TabIndex = 3;
            // 
            // Player2TextBox
            // 
            this.Player2TextBox.AccessibleName = "Player2TextBox";
            this.Player2TextBox.Enabled = false;
            this.Player2TextBox.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Player2TextBox.Location = new System.Drawing.Point(220, 274);
            this.Player2TextBox.Name = "Player2TextBox";
            this.Player2TextBox.Size = new System.Drawing.Size(249, 43);
            this.Player2TextBox.TabIndex = 3;
            this.Player2TextBox.Text = "[Computer]";
            // 
            // DoneButton
            // 
            this.DoneButton.AccessibleName = "DoneButton";
            this.DoneButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.DoneButton.Location = new System.Drawing.Point(322, 358);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(147, 47);
            this.DoneButton.TabIndex = 4;
            this.DoneButton.Text = "Done";
            this.DoneButton.UseVisualStyleBackColor = true;
            this.DoneButton.Click += new System.EventHandler(this.DoneButton_Click);
            // 
            // GameSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 450);
            this.Controls.Add(this.DoneButton);
            this.Controls.Add(this.Player2TextBox);
            this.Controls.Add(this.Player1TextBox);
            this.Controls.Add(this.Player2CheckBox);
            this.Controls.Add(this.Radio10);
            this.Controls.Add(this.Radio8);
            this.Controls.Add(this.Radio6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Settings";
            this.Load += new System.EventHandler(this.GameSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton Radio6;
        private System.Windows.Forms.RadioButton Radio8;
        private System.Windows.Forms.RadioButton Radio10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox Player2CheckBox;
        private System.Windows.Forms.TextBox Player1TextBox;
        private System.Windows.Forms.TextBox Player2TextBox;
        private System.Windows.Forms.Button DoneButton;
    }
}