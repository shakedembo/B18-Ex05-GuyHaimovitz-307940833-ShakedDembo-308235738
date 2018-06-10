using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Checkers.GUI
{
    public partial class GameSettings : Form
    {
        public GameSettings()
        {
            InitializeComponent();
        }

        private void Player2CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Player2TextBox.Enabled = Player2CheckBox.CheckState == CheckState.Checked;
            Player2TextBox.Text = string.Empty;
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        public string Player1
        {
            get { return Player1TextBox.Text; }
        }
        public string Player2
        {
            get { return Player2CheckBox.Checked ? Player2TextBox.Text : "PC"; }
        }

        public int NumberOfPlayers
        {
            get { return Player2CheckBox.Checked ? 2 : 1; }
        }

        public int BoardSize
        {
            get
            {
                if (Radio6.Checked)
                {
                    return 6;
                }
                else if (Radio8.Checked)
                {
                    return 8;
                }
                else
                {
                    return 10;
                }
            }
        }
    }
}
