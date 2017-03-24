using System;
using System.Windows;


namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Private Members

        /// <summary>
        /// Holds the current results of the cells in the active game
        /// </summary>
        private MarkType[] mResults;

        /// <summary>
        /// Ture if it is player 1's turn (X), False if player 2's turn (O)
        /// </summary>
        private bool mPlayer1Turn;

        /// <summary>
        /// True if Game over
        /// </summary>
        private bool mGameOver;

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>

        public MainWindow()
        {
            InitializeComponent();

            NewGame();
        }

        #endregion

        private void NewGame()
        {
            throw new NotImplementedException();
        }
    }
}
