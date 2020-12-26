#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
#endregion

namespace DiceGame
{
    public class Player
    {

        #region Declaration

        int[] dice; // array to hold our dice
        int[] diceResults; // array to hold diceResults
        static Random rand; // random used to get dice results
        bool played = false; // bool value to tell if player has played or is ready to play
        int handRank, mod1, mod2, mod3; // used to hold handRank and mod information
        string result, name; // strings to hold hand result and the player's name

        #endregion

        #region Properties

        /// <summary>
        /// Getter to allow outside files to get the values stored in our private dice[]
        /// </summary>
        public int[] Dice
        {
            get { return dice; }
        }

        /// <summary>
        /// Getter / Setter to allow outside files to get and set the value stored in the private string name
        /// </summary>
        public string Name
        {
            set { name = value; }
            get { return name; }
        }

        /// <summary>
        /// Getter / Setter to allow outside files to get and set if the player has played
        /// </summary>
        public bool Played
        {
            set { played = value; }
            get { return played; }
        }

        /// <summary>
        /// Getter to allow outside files to get the value stored in the private string result
        /// </summary>
        public string Result
        {
            get { return result; }
        }

        /// <summary>
        /// Getter to allow outside files to get the value stored in the private int handRank
        /// </summary>
        public int HandRank
        {
            get { return handRank; }
        }

        /// <summary>
        /// Getter to allow outside files to get the value stored in the private int mod1
        /// </summary>
        public int Mod1
        {
            get { return mod1; }
        }

        /// <summary>
        /// Getter to allow outside files to get the value stored in the private int mod2
        /// </summary>
        public int Mod2
        {
            get { return mod2; }
        }

        /// <summary>
        /// Getter to allow outside files to get the value stored in the private int mod3
        /// </summary>
        public int Mod3
        {
            get { return mod3; }
        }

        #endregion

        #region Intialization

        /// <summary>
        /// Constructor
        /// </summary>
        public Player(string playerName)
        {
            name = playerName; // sets the players name

            dice = new int[5] { 0, 0, 0, 0, 0 }; // initialize and populate the dice[]

            diceResults = new int[6] { 0, 0, 0, 0, 0, 0 }; // initialize and populate the diceResults[]

            result = "Roll the Dice!"; // set the initial value for the result string array

            rand = new Random(); // setup our random

            handRank = 0; // set initial handRank value
            mod1 = 0; // set initial mod1 value
            mod2 = 0; // set initial mod2 value
            mod3 = 0; // set initial mod3 value

            played = false; // set initial value of the played to false (player has not yet played)
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// This method will be used to simulate a dice roll for the player and store the results of the roll
        /// in the dice[] and diceResults[]
        /// </summary>
        public void RollDice()
        {
            // for loop to run through each of the die
            for (int i = 0; i < dice.Length; i++)
            {
                // here we get a random number from 1 to 6 (we add a plus 1 here because the max would be 5)
                // you could write this as rand.Next(1,7), but it is easier to read at a glance like we have it here
                dice[i] = rand.Next(1, 6 + 1);

                // add to the amount of the current die in our hand after rolling each die (counts how many 1s, 2s, 3s, 4s, 5s and 6s in the players hand)
                switch (dice[i])
                {
                    case 1:
                        diceResults[0]++;
                        break;
                    case 2:
                        diceResults[1]++;
                        break;
                    case 3:
                        diceResults[2]++;
                        break;
                    case 4:
                        diceResults[3]++;
                        break;
                    case 5:
                        diceResults[4]++;
                        break;
                    case 6:
                        diceResults[5]++;
                        break;
                }
            }
            // call the GetResults method here to go through and set the handrank and
            // mod values
            GetResults();
        }

        // this resets the player back to the initial state and has them ready to play
        // again
        public void ResetPlayer()
        {
            // loop through the diceResults[] and set all values back to the initial 0
            for (int i = 0; i < diceResults.Length; i++)
                diceResults[i] = 0;
            // loop through the dice[] and set all values back to the initial 0
            for (int i = 0; i < dice.Length; i++)
                dice[i] = 0;
            // set that the player has not played (is ready to play again)
            played = false;
            // reset the mod values
            mod1 = 0;
            mod2 = 0;
            mod3 = 0;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Get the results of the roll
        /// </summary>
        private void GetResults()
        {
            // set all the kinds of hands to false for the start
            bool fiveKind = false, fourKind = false, highStraight = false,
                lowStraight = false, fullHouse = false, threeKind = false,
                twoPair = false, onePair = false, haveSix = false, haveFive = false,
                haveFour = false, haveThree = false, haveTwo = false, haveOne = false;

            // loop through the diceResults[] which holds how many of each die type we have
            for (int i = 0; i < diceResults.Length; i++)
            {
                if (diceResults[i] == 5) // if you have 5 of the same kind of die
                {
                    fiveKind = true; // set that you have a five of a kind
                    mod1 = i; // check to see what they have five of a kind of (which will be the i value)
                }
                else if (diceResults[i] == 4) // else if you have 4 of the same kind of die
                {
                    fourKind = true; // set that you have four of a kind
                    mod1 = i; // check to see what they have four of a kind of (which will be the i value)
                }
                // else if you have a 2, 3, 4, 5, 6
                else if (diceResults[1] == 1 &&
                         diceResults[2] == 1 &&
                         diceResults[3] == 1 &&
                         diceResults[4] == 1 &&
                         diceResults[5] == 1)
                    highStraight = true; // set that you have a high straight
                // else if you have a 1, 2, 3, 4, 5
                else if (diceResults[0] == 1 &&
                         diceResults[1] == 1 &&
                         diceResults[2] == 1 &&
                         diceResults[3] == 1 &&
                         diceResults[4] == 1)
                    lowStraight = true; // set that you have a low straight
                // else if you have three of the same kind of dice
                else if (diceResults[i] == 3)
                {
                    threeKind = true; // set that you have three of a kind
                    mod1 = i; // check to see what they have three of a kind of (which will be the i value)
                    // loop through the dice again
                    for (int j = 0; j < diceResults.Length; j++)
                    {
                        // if you also have a pair (with the three of a kind)
                        if (diceResults[j] == 2)
                        {
                            fullHouse = true; // set that you have a full house
                            mod2 = j; // check to see what they have a pair of (which will be the i value)
                        }
                    }
                }
                else if (diceResults[i] == 2) // else if you have a pair (2 of the same kind)
                {
                    onePair = true; // set that you have a pair
                    if (mod1 == 0) // check to make sure nothing has been put into mod1 yet (stop it from overriding your first pair with a second pair if you have one)
                        mod1 = i; // check to see what they have a pair of (which will be the i value)
                    // loop through the dice again (starting after the number you already found a pair of)
                    for (int j = i + 1; j < diceResults.Length; j++)
                    {
                        // if you have another pair
                        if (diceResults[j] == 2)
                        {
                            twoPair = true; // set that you have two pair
                            if (mod2 == 0) // make sure nothing has been put into mod2 yet
                                mod2 = j; // check to see what their second pair is of (which will be the i value)
                        }
                    }
                }
            }
            // loop through the dice and calculate the total of the dice
            // this will be used to incase you need to see who has the highest dice
            // left over and to verify ties if needed.
            for (int i = 0; i < dice.Length; i++)
            {
                // depending on the die value add to the mod3 total and set that they have
                // this die type
                switch (dice[i])
                {
                    case 6:
                        haveSix = true;
                        mod3 += 6;
                        break;
                    case 5:
                        haveFive = true;
                        mod3 += 5;
                        break;
                    case 4:
                        haveFour = true;
                        mod3 += 4;
                        break;
                    case 3:
                        haveThree = true;
                        mod3 += 3;
                        break;
                    case 2:
                        haveTwo = true;
                        mod3 += 2;
                        break;
                    case 1:
                        haveOne = true;
                        mod3 += 1;
                        break;
                }
            }
            // now set the result string and the handRank for the roll
            if (fiveKind)
            {
                result = "Five of a Kind";
                handRank = 14;
            }
            else if (fourKind)
            {
                result = "Four of a Kind";
                handRank = 13;
            }
            else if (highStraight)
            {
                result = "High Straight";
                handRank = 12;
            }
            else if (lowStraight)
            {
                result = "Low Straight";
                handRank = 11;
            }
            else if (fullHouse)
            {
                result = "Full House";
                handRank = 10;
            }
            else if (threeKind)
            {
                result = "Three of a Kind";
                handRank = 9;
            }
            else if (twoPair)
            {
                result = "Two Pair";
                handRank = 8;
            }
            else if (onePair)
            {
                result = "One Pair";
                handRank = 7;
            }
            else if (haveSix)
            {
                result = "Six High";
                handRank = 6;
            }
            else if (haveFive)
            {
                result = "Five High";
                handRank = 5;
            }
            else if (haveFour)
            {
                result = "Four High";
                handRank = 4;
            }
            else if (haveThree)
            {
                result = "Three High";
                handRank = 3;
            }
            else if (haveTwo)
            {
                result = "Two High";
                handRank = 2;
            }
            else if (haveOne)
            {
                result = "One High";
                handRank = 1;
            }
        }

        #endregion
    }
}
