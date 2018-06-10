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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                   
                    Square square = new Square((i + j) % 2 == 1, new Tuple<int, int>(i * Square.r_Size, 100 + j * Square.r_Size), new Cell(new Tuple<int, int>( i,j)) );
                    square.Click += new EventHandler(this.Square_Click);
                    m_Squares.Add(square);
                    this.Controls.Add(square);
                }
            }

            this.AutoSize = true;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;




        }

        #endregion

        
    }
}