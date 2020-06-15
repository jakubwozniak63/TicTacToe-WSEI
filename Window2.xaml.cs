using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TicTacToe2
{
    /// <summary>
    /// Logika interakcji dla klasy Window2.xaml
    /// </summary>
    public partial class Window2 : Window
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
        
        public Window2()
        {
            InitializeComponent();

            NewGame();
        }

        #endregion
        /// <summary>
        /// Starts a new game and clears all values back to the start
        /// </summary>

        private void NewGame()
        {
            //create a new blank array of free cells
            mResults = new MarkType[9];

            for (var i = 0; i < mResults.Length; i++)
            {
                mResults[i] = MarkType.Free;
            }

            //make sure that player 1 starts
            mPlayer1Turn = true;

            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {

                // Change background, foreground and content to default values
                button.Content = string.Empty;
                button.Background = Brushes.White;
                button.Foreground = Brushes.Blue;

            });

            //make sure game has not finished
            mGameEnded = false;
        }

        /// <summary>
        /// Handles a button click event 
        /// </summary>
        /// <param name="sender">The button that was clicked </param>
        /// <param name="e">The events of the click</param>

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //starts a new game on the click after it finished
            if (mGameEnded)
            {
                NewGame();
                return;
            }

            //Cast the sender to a button 
            var button = (Button)sender;

            //Find the button position in the array
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            var index = column + (row * 3);


            //Don't do anything if the cell already has a value in it
            if (mResults[index] != MarkType.Free)
            {
                return;
            }

            //set the cell value based on whcich palyer turn it is
            if (mPlayer1Turn)
            {
                mResults[index] = MarkType.Cross;
            }
            else
            {
                mResults[index] = MarkType.Nought;
            }

            //set button text to the result
            if (mPlayer1Turn)
            {
                button.Content = "X";
            }
            else
            {
                button.Content = "O";
            }

            //Changing noughts to green
            if (!mPlayer1Turn)
            {
                button.Foreground = Brushes.Red;
            }


            //Changing players turns
            if (mPlayer1Turn)
            {
                mPlayer1Turn = false;
            }
            else
            {
                mPlayer1Turn = true;
            }
            CheckForWinner();
        }
        private void CheckForWinner()
        {
            //check for horizontal wins  
            //Row 0
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[1] & mResults[2]) == mResults[0])
            {
                mGameEnded = true;

                //Highlight winning cells in green
                Button_0_0.Background = Button_1_0.Background = Button_2_0.Background = Brushes.Green;
            }

            //check for horizontal wins  
            //Row 1
            if (mResults[3] != MarkType.Free && (mResults[3] & mResults[4] & mResults[5]) == mResults[3])
            {
                mGameEnded = true;

                //Highlight winning cells in green
                Button_0_1.Background = Button_1_1.Background = Button_2_1.Background = Brushes.Green;
            }

            //check for horizontal wins  
            //Row 2
            if (mResults[6] != MarkType.Free && (mResults[6] & mResults[7] & mResults[8]) == mResults[6])
            {
                mGameEnded = true;

                //Highlight winning cells in green
                Button_0_2.Background = Button_1_2.Background = Button_2_2.Background = Brushes.Green;
            }

            //check for vertical wins  
            //Row 1
            if (mResults[1] != MarkType.Free && (mResults[1] & mResults[4] & mResults[7]) == mResults[1])
            {
                mGameEnded = true;

                //Highlight winning cells in green
                Button_1_0.Background = Button_1_1.Background = Button_1_2.Background = Brushes.Green;
            }

            //check for vertical wins  
            //Row 0
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[3] & mResults[6]) == mResults[0])
            {
                mGameEnded = true;

                //Highlight winning cells in green
                Button_0_0.Background = Button_0_1.Background = Button_0_2.Background = Brushes.Green;
            }

            //check for vertical wins  
            //Row 2
            if (mResults[2] != MarkType.Free && (mResults[2] & mResults[5] & mResults[8]) == mResults[2])
            {
                mGameEnded = true;

                //Highlight winning cells in green
                Button_2_0.Background = Button_2_1.Background = Button_2_2.Background = Brushes.Green;
            }

            //check for diagonal wins  
            //left to right
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[4] & mResults[8]) == mResults[0])
            {
                mGameEnded = true;

                //Highlight winning cells in green
                Button_0_0.Background = Button_1_1.Background = Button_2_2.Background = Brushes.Green;
            }

            //check for diagonal wins  
            //right to left
            if (mResults[2] != MarkType.Free && (mResults[2] & mResults[4] & mResults[6]) == mResults[2])
            {
                mGameEnded = true;

                //Highlight winning cells in green
                Button_0_2.Background = Button_1_1.Background = Button_2_0.Background = Brushes.Green;
            }




            //checking if all cells are taken and there is no winner
            if (!mResults.Any(results => results == MarkType.Free))
            {
                //game ended
                mGameEnded = true;

                //turn all cells orange
                Container.Children.Cast<Button>().ToList().ForEach(button =>
                {
                    button.Background = Brushes.Orange;
                });
            }
        }
    }
}

    
    
