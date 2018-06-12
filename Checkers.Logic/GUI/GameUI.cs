using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Checkers.Logic;
using Checkers.Logic.GUI;

namespace Checkers.GUI
{
    public partial class GameUI : Form
    {
        
        private List<Square> m_Squares;
        private GameManager m_GameManager;
        private Game m_Game;

        private bool m_IsTargetClick = false;
        private Square m_OptionalSource;


        public GameUI(GameManager i_GameManager)
        {
            InitializeGameUI(i_GameManager); 
        }

        private void InitializeGameUI(GameManager i_GameManager)
        {
            this.m_Squares = new List<Square>();
            m_GameManager = i_GameManager;
            m_Game = m_GameManager.CurrentGame;
            m_Game.GameEnded += new Game.endGameHandler(gameEnded);
            InitializeComponent();
        }

        private void Square_Click(object sender, EventArgs e)
        {
            Square senderSquare = sender as Square;
            if (!m_IsTargetClick)
            {
                
                if (m_Game.isValidSource(senderSquare.Cell))
                {
                    senderSquare.Mark();
                    m_OptionalSource = senderSquare;
                    m_IsTargetClick = true;
                }

            }
            else
            {
                if (senderSquare.BackColor == Color.LightBlue)
                {
                    senderSquare.UnMark();
                    m_IsTargetClick = false;
                    m_OptionalSource = null;
                }
                else
                {

                    m_Game.MakeMove(m_OptionalSource.Cell, senderSquare.Cell);
                    
                    m_IsTargetClick = false;
                    m_OptionalSource.UnMark();
                    m_OptionalSource = null;
                }
            }
            UpdateBoard();
        }

        private void gameEnded()
        {
            DialogResult DialogResult;
            
            Tuple<IPlayer, int> gameResults = m_Game.calculateScore();


            if (gameResults.Item2 == 0)
            {
                DialogResult = MessageBox.Show("Tie!" + Environment.NewLine + "Another Round?", "Damka",
                    MessageBoxButtons.YesNo);
            }
            else
            {
                DialogResult = MessageBox.Show(gameResults.Item1 + " Won!" + Environment.NewLine + "Another Round?", "Damka",
                    MessageBoxButtons.YesNo);
            }

            if (DialogResult.Equals(DialogResult.Yes))
            {
                m_GameManager.StartNewGame();
                InitializeGameUI(m_GameManager);
            }
            else
            {
                Close();
            }

        }

    }
}

