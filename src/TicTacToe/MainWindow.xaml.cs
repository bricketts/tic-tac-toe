using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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
            // Create new blank array of free cells
            mResults = new MarkType[9];

            for (var i = 0; i < mResults.Length; i++)
            {
                mResults[i] = MarkType.Free;
            }

            mPlayer1Turn = true;

            // Iterate every button on the grid...
            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                // Change background, foreground and content to default values
                button.Content = string.Empty;
                button.Background = Brushes.White;
                button.Foreground = Brushes.Blue;
            });

            // Make sure the game hasn't finished
            mGameOver = false;
        }
    }
}
