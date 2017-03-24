﻿using System;
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

        /// <summary>
        /// Start new game and clears all values and sets them to default.
        /// </summary>
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

        /// <summary>
        /// Handles a button click event
        /// </summary>
        /// <param name="sender">The button was clicked</param>
        /// <param name="e">The events of the click</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (mGameOver)
            {
                NewGame();
                return;
            }

            // Cast the sender to a button
            var button = (Button)sender;

            // finds the buttons position in the array
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            var index = column + (row * 3);

            // Dont do anything if the cell already has a value in it
            if (mResults[index] != MarkType.Free)
            {
                return;
            }

            // Set the cell value based on which players turn it is
            mResults[index] = mPlayer1Turn ? MarkType.Cross : MarkType.Nought;

            // Set button text to the result
            button.Content = mPlayer1Turn ? "X" : "O";

            // Change O color to green
            if (!mPlayer1Turn)
                button.Foreground = Brushes.Red;
            
            // Toggle the players turns
            mPlayer1Turn ^= true;

            // Check for Winner
            CheckForWinner();
        }

        private void CheckForWinner()
        {
            //Check for Horizontal Win
            var same = (mResults[0] & mResults[1] & mResults[2]) == mResults[0];

            if (mResults[0] != MarkType.Free && same)
            {
                // Game Ends
                mGameOver = true;

                // Hightlight Winning cells in green
                Button0_0.Background = Button1_0 = Button2_0 = Brushes.Green;
            }
        }
    }
}
