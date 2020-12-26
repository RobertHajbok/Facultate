#region Using Statements
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
#endregion

namespace DiceGame
{
    public partial class Form1 : Form
    {
        #region Declaration

        Image[] diceImages; // Array used to hold the dice images
        Player player1, player2; // Create the reference variables that will point to our player objects

        #endregion

        #region Initialization

        public Form1()
        {
            InitializeComponent(); // Required method for Designer support (You can find this method in the Form1.Designer.cs file)
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            player1 = new Player("Player 1"); // Create a Player object with the name of Player 1 and point the player1 reference variable to this object 
            player2 = new Player("Player 2"); // Create a Player object with the name of Player 2 and point the player2 reference variable to this object

            lbl_p1Name.Text = player1.Name; // sets the text of the lbl_p1Name to the name of player1
            lbl_p2Name.Text = player2.Name; // sets the text of the lbl_p2Name to the name of player2

            // Initialize and store data in the diceImages array
            diceImages = new Image[7];
            diceImages[0] = Properties.Resources.dice_blank;
            diceImages[1] = Properties.Resources.dice_1;
            diceImages[2] = Properties.Resources.dice_2;
            diceImages[3] = Properties.Resources.dice_3;
            diceImages[4] = Properties.Resources.dice_4;
            diceImages[5] = Properties.Resources.dice_5;
            diceImages[6] = Properties.Resources.dice_6;
        }

        #endregion

        #region Private Methods

        // this sets what happens when we click the button to roll the dice for player 1
        private void btn_p1RollDice_Click(object sender, EventArgs e)
        {
            // if player 1 has not played
            if (!player1.Played)
            {
                player1.RollDice(); // roll the dice for player one

                // Here we set the images for the dice for player 1 after the roll.
                //
                // When we used the RollDice() method to roll the dice we stored the
                // results for each of them in the dice[] array located inside the player object.
                // We access this by using the getter Dice to return the values located in the private
                // dice array inside the player object.
                //
                // So we need to know which image in the diceImages array to set the label image to...
                // How do we do that? Well we take the dice result for each die using the Dice getter
                // which will be a 1, 2, 3, 4, 5, 6 and use that as the index of the diceImages array
                // to set the label image to the proper image to reflect the players roll.
                //
                // So if the first die player1 rolled was a 4 we would get this number by using player1.Dice[0]
                // we would use 0 because that is the first index of the array and this would return 4 to us. Now
                // we need to get the picture for a die showing side 4. If you notice that diceImages[0] is the blank
                // die image and then starting with 1 through 6 it is the images for a die showing 1 through 6. So we
                // would get this image simply by passing the diceImages array an index of the value rolled for each 
                // die. So diceImages[player1.Dice[0]] would simply be diceImages[4] since the first die rolled is 4
                // and this will set the label to the proper image.
                lbl_p1Dice1.Image = diceImages[player1.Dice[0]];
                lbl_p1Dice2.Image = diceImages[player1.Dice[1]];
                lbl_p1Dice3.Image = diceImages[player1.Dice[2]];
                lbl_p1Dice4.Image = diceImages[player1.Dice[3]];
                lbl_p1Dice5.Image = diceImages[player1.Dice[4]];
                lbl_p1DisplayResults.Text = player1.Result;

                // now that player1 has rolled set that they have played
                player1.Played = true;

                // this will check after each roll to see if both players have rolled
                // and if they have it will check their dice to see who wins or if it is a tie
                CheckWinner();
            }
        }

        // this is the same thing as the above button, except that this will set the information for
        // player 2 not player 1
        private void btn_p2RollDice_Click(object sender, EventArgs e)
        {
            if (!player2.Played)
            {
                player2.RollDice();

                lbl_p2Dice1.Image = diceImages[player2.Dice[0]];
                lbl_p2Dice2.Image = diceImages[player2.Dice[1]];
                lbl_p2Dice3.Image = diceImages[player2.Dice[2]];
                lbl_p2Dice4.Image = diceImages[player2.Dice[3]];
                lbl_p2Dice5.Image = diceImages[player2.Dice[4]];
                lbl_p2DisplayResults.Text = player2.Result;

                player2.Played = true;

                CheckWinner();
            }
        }

        // this will check to see if both players have played and give the
        // results of the game.
        private void CheckWinner()
        {
            // if both player 1 and player 2 have played
            if (player1.Played && player2.Played)
            {
                // if player1's handrank is higher than player2's
                // to understand the handranks and mod1/mod2/mod3 see the player.cs file comments
                if (player1.HandRank > player2.HandRank)
                {
                    lbl_winnerResult.Text = player1.Name + " Wins!"; // set the winnerResult label to show that player1 wins
                }
                else if (player2.HandRank > player1.HandRank) // else if player2's handrank is greater than player one's
                {
                    lbl_winnerResult.Text = player2.Name + " Wins!"; // set the winnerResult label to show that player2 wins
                }
                else if (player1.HandRank == 8 && player2.HandRank == 8) // else if both handranks equal 8
                {
                    // if player1 mod1 is greater than player2's mod1 and 2
                    if (player1.Mod1 > player2.Mod1 &&
                        player1.Mod1 > player2.Mod2)
                    {
                        lbl_winnerResult.Text = player1.Name + " Wins!"; // set the winnerResult label to show that player1 wins
                    }
                    // else if player1's mod2 is greater than player2's mod1 and mod2
                    else if (player1.Mod2 > player2.Mod1 &&
                             player1.Mod2 > player2.Mod2)
                    {
                        lbl_winnerResult.Text = player1.Name + " Wins!"; // set the winnerResult label to show that player1 wins
                    }
                    // else if player1's mod1 and mod2 are equal to player2's mod1 and mod2
                    // or player1's mod2 is equal to player2's mod1 and player1's mod1 is equal to player2's mod2
                    else if (player1.Mod1 == player2.Mod1 &&
                             player1.Mod2 == player2.Mod2 ||
                             player1.Mod2 == player2.Mod1 &&
                             player1.Mod1 == player2.Mod2)
                    {
                        // if player1's mod3 is greater than player2's mod3
                        if (player1.Mod3 > player2.Mod3)
                        {
                            lbl_winnerResult.Text = player1.Name + " Wins!"; // set the winnerResult label to show that player1 wins
                        }
                        // else if player2's mod3 is greater than player1's mod3
                        else if (player2.Mod3 > player1.Mod3)
                        {
                            lbl_winnerResult.Text = player2.Name + " Wins!"; // set the winnerResult label to show that player2 wins
                        }
                        // else the mod3's for both will be the same so its a tie
                        else
                        {
                            lbl_winnerResult.Text = player1.Name + " Ties " + player2.Name; // set the winnerResult label to show that it is a tie
                        }
                    }
                }
                // else if the handranks are the same
                else if (player1.HandRank == player2.HandRank)
                {
                    // if player1's mod1 is greater than player2's mod1
                    if (player1.Mod1 > player2.Mod1)
                        lbl_winnerResult.Text = player1.Name + " Wins!"; // set the winnerResult label to show that player1 wins
                    else if (player2.Mod1 > player1.Mod1) // else if player2's mod1 is greater than player1's mod1
                        lbl_winnerResult.Text = player2.Name + " Wins!"; // set the winnerResult label to show that player2 wins
                    else if (player1.Mod1 == player2.Mod1) // else if both player1 and player2 have an equal mod1
                    {
                        if (player1.Mod2 > player2.Mod2) // if player1's mod2 is greater than player2's mod2
                            lbl_winnerResult.Text = player1.Name + " Wins!"; // set the winnerResult label to show that player1 wins
                        else if (player2.Mod2 > player1.Mod2) // if player2's mod2 is greater than player1's mod2
                            lbl_winnerResult.Text = player2.Name + " Wins!"; // set the winnerResult label to show that player2 wins
                        else if (player1.Mod2 == player2.Mod2) // else if both players have the same mod2
                        {
                            if (player1.Mod3 > player2.Mod3) // if player1 has a greater mod3
                                lbl_winnerResult.Text = player1.Name + " Wins!"; // set the winnerResult label to show that player1 wins
                            else if (player2.Mod3 > player1.Mod3) // else if player2 has a greater mod3
                                lbl_winnerResult.Text = player2.Name + " Wins!"; // set the winnerResult label to show that player2 wins
                            else if (player1.Mod3 == player2.Mod3) // else if both players have an equal mod3
                                lbl_winnerResult.Text = player1.Name + " Ties " + player2.Name; // set the winnerResult label to show that it is a tie
                        }
                    }
                }

                // reset the players so that they can play again
                player1.ResetPlayer();
                player2.ResetPlayer();
            }
            else if (player1.Played && !player2.Played) // else if only player 1 has played
                lbl_winnerResult.Text = "Waiting for " + player2.Name + " to roll!"; // set winnerResult label to show that we are waiting on playe2 to roll
            else if (player2.Played && !player1.Played) // else if player 2 has played and player 1 has not played
                lbl_winnerResult.Text = "Waiting for " + player1.Name + " to roll!"; // set the winnerResult label to show that we are waiting on player1 to roll
        }

        #endregion
    }
}
