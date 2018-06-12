using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Checkers.Logic.GUI;

namespace Checkers.GUI
{
    partial class GameUI
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

        private void UpdateBoard()
        {
            foreach (Square square in m_Squares)
            {
                square.Text = square.Cell.ToString();
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Controls.Clear();
            for (int i = 0; i < m_Game.Board.GetSize(); i++)
            {
                for (int j = 0; j < m_Game.Board.GetSize(); j++)
                {
                   
                    Square square = new Square((i + j) % 2 == 1, new Tuple<int, int>(i * Square.r_Size, 100 + j * Square.r_Size), m_Game.Board.GetCell(j, i));
                    square.Click += new EventHandler(this.Square_Click);
                    m_Squares.Add(square);
                    this.Controls.Add(square);
                }
            }

            

            this.Player1 = new System.Windows.Forms.Label();
            this.Player2 = new System.Windows.Forms.Label();
            //this.SuspendLayout();
            // 
            // Player1
            // 
            this.Player1.AutoSize = true;
            this.Player1.Font = new System.Drawing.Font("Segoe UI", 12.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            
            this.Player1.Name = "Player1";
            //this.Player1.Size = new System.Drawing.Size(111, 37);
            this.Player1.TabIndex = 0;
            this.Player1.Text = this.m_GameManager.Player1.ToString() + ": " + this.m_GameManager.Player1Score;
            // 
            // Player2
            // 
            this.Player2.AutoSize = true;
            this.Player2.Font = new System.Drawing.Font("Segoe UI", 12.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            
            this.Player2.Name = "Player2";
            //this.Player2.Size = new System.Drawing.Size(111, 37);
            this.Player2.TabIndex = 0;
            this.Player2.Text = this.m_GameManager.Player2.ToString() + ": " + this.m_GameManager.Player2Score; 

            


            this.Text = "Damka";
            this.AutoSize = true;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            this.Player1.Location = new System.Drawing.Point((this.Width - (Player1.Width + Player2.Width + 10)) / 2, 90 - Player1.Height);
            this.Player2.Location = new System.Drawing.Point(Player1.Location.X + Player1.Width + 10, Player1.Location.Y);

            this.Controls.Add(this.Player2);
            this.Controls.Add(this.Player1);




        }

        #endregion

        private System.Windows.Forms.Label Player1;
        private System.Windows.Forms.Label Player2;

    }
}