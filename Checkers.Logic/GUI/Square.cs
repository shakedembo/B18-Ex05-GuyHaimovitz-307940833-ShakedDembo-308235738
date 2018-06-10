using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Checkers.Logic.GUI
{
    class Square : Button
    {
        private readonly bool m_IsEnabled;
        private Tuple<int, int> m_Position;
        private Cell m_Cell;
        public static readonly int r_Size = 50;

        public Square(bool i_IsEnabled, Tuple<int, int> i_Position, Cell i_Cell)
        {
            m_Position = i_Position;
            m_IsEnabled = i_IsEnabled;
            m_Cell = i_Cell;
            InitializeComponent();
            
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Square
            // 
            this.BackColor = m_IsEnabled ? System.Drawing.Color.White : System.Drawing.Color.Black;
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Location = new System.Drawing.Point(m_Position.Item1, m_Position.Item2);
            this.Name = "Square" +"(" + m_Position.Item1 + "," + m_Position.Item2 + "";
            this.Size = new System.Drawing.Size(r_Size, r_Size);
            this.TabIndex = 0;
            this.Text = m_Cell.ToString();
            this.UseVisualStyleBackColor = false;
            this.Enabled = m_IsEnabled;

        }

        internal void Mark()
        {
            this.BackColor = Color.LightBlue;

        }
        internal void UnMark()
        {
            this.BackColor = Color.White;
        }



        public Cell Cell
        {
            get { return m_Cell; }
            set { m_Cell = value; }
        }

        public Tuple<int, int> Position
        {
            get { return m_Position; }
        }
    }
}
