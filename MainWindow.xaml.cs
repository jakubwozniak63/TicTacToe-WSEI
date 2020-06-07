
using System;
using System.Windows;

namespace TicTacToe
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Private Members
        /// <summary>
        /// Holds the current results of cells in the active game
        /// </summary>
        private MarkType[] mResults;

        /// <summary>
        /// True if it is player 1's turn (X) or player 2's turn (0)
        /// </summary>
        private bool mPlayer1Turn;

        /// <summary>
        /// True if game has ended
        /// </summary>
        private bool mGameEnded;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>

        public MainWindow()
        {
            InitializeComponent();

            NewGame()
        }

        #endregion

        private void NewGame()
        {
            throw new NotImplementedException();
        }
    }
}
