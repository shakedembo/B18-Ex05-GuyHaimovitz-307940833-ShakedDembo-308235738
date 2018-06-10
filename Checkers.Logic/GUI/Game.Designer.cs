namespace Checkers.GUI
{
    partial class Game
    {
        private int boardSize;

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
            this.Cell = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Cell)).BeginInit();
            this.SuspendLayout();
            // 
            // Cell
            // 
            this.Cell.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Cell.Location = new System.Drawing.Point(34, 49);
            this.Cell.Name = "Cell";
            this.Cell.Size = new System.Drawing.Size(85, 83);
            this.Cell.TabIndex = 0;
            this.Cell.TabStop = false;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 715);
            this.Controls.Add(this.Cell);
            this.Name = "Game";
            this.Text = "Game";
            ((System.ComponentModel.ISupportInitialize)(this.Cell)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Cell;
    }
}