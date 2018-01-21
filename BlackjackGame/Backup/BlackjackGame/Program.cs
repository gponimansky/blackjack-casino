using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackjackGame
{
    class Program
    {

        static void Main(string[] args)
        {
            // Declaring Array
            string[] deck = new string[] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"};
            // Declaring Important Variables
            double money = 200;
            double moneyBet = 0;

            bool isPlaying = false;
            bool quit = false;


            // Writes a Welcome To Game Message while playing a cool song
            Console.WriteLine("\n\n\tThe");
            Console.Beep(220, 250);
            Console.Beep(523, 250);
            Console.Beep(261, 250);
            Console.WriteLine("\t\tBlackjack");
            Console.Beep(294, 250);
            Console.Beep(587, 250);
            Console.Beep(261, 250);
            Console.WriteLine("\t\t\t\tGame");
            Console.Beep(440, 250);
            Console.Beep(523, 250);
            Console.Beep(587, 250);
            Console.Beep(658, 500);
            // Clears Screen
            Console.Clear();

            // Game's While Loop
            while (!quit)
            {
                if (isPlaying)
                {
                    Console.WriteLine("You have $" + money + "\n");
                    moneyBet = dealerWelcome(money);
                    money += playGame(deck, moneyBet, money);
                    // Waits For User Input to Countinue 
                    Console.ReadKey();
                    // Beep For Cool Sound Effects
                    Console.Beep(294, 150);
                    // Clears Screen
                    Console.Clear();
                    // Checks If Player Has Money if He Does Goes Back to Menu Else Inform Message and Quit
                    if (money > 0)
                    {
                        isPlaying = false;
                    }
                    else
                    {
                        quit = true;
                        // Goodbye Message
                        Console.WriteLine("\nYou Have Ran Out Of Money!\nThanks For Playing...");
                        // Waits For User Input to Countinue 
                        Console.ReadKey();
                        // Beep For Cool Sound Effects
                        Console.Beep(294, 150);
                        // Clears Screen
                        Console.Clear();
                    }
                }
                else
                {
                    quit = displayChoices(money);
                    if (quit)
                    {
                        // Goodbye Message
                        Console.WriteLine("\nThanks For Playing...");
                        // Waits For User Input to Countinue 
                        Console.ReadKey();
                        // Beep For Cool Sound Effects
                        Console.Beep(294, 150);
                        // Clears Screen
                        Console.Clear();
                    }
                    isPlaying = true;
                }
            }

       
        }

        /// <summary>
        /// Displays the Menu, and Gives Choices
        /// </summary>
        /// <returns>Returns bool of Quiting the Game Or Not</returns>
        static private bool displayChoices(double moneyHolding)
        {
            // Delcares Quit Variable
            bool quit = false;
            // Declares While Variable
            bool NoOption = true;
            // Starts While Loop
            while (NoOption)
            {
                // Shows How Much Money You Have...
                Console.WriteLine("You have $" + moneyHolding + "\n");
                // Writes a User Friendly Line on what choices you have
                Console.WriteLine("\n1.Bet\n2.Quit\n");
                // Declares Choice Variables and Gets Input from User
                string choice = Console.ReadLine();
                // Checks Choices Avaliable
                switch (choice)
                {
                    case "1":
                        // Clears Console For The Next Output Statements
                        Console.Clear();
                        // Beep For Cool Sound Effects
                        Console.Beep(294, 150);
                        // Gets Out of While Loop
                        NoOption = false;
                        break;
                    case "2":
                        // Clears Console For Cleaness
                        Console.Clear();
                        // If Quiting make Quit True
                        quit = true;
                        // Gets Out of While Loop
                        NoOption = false;
                        break;
                    default:
                        Console.WriteLine("\nYou Didnt Pick An Option");
                        // Waits For The User to Countinue 
                        Console.ReadKey();
                        // Clears Screen 
                        Console.Clear();
                        break;
                }
            }
            // Returns Quit
            return quit;
        }

        /// <summary>
        /// Welcomes Player to the Casino, and askes how much you would like to bet, Check if you have amount, sends moneybet left back to player
        /// </summary>
        /// <param name="moneyHave"></param>
        /// <returns></returns>
        static private double dealerWelcome(double moneyHave)
        {
            // Declares Boolean Variable to Check If player Has Enough Money (Default false)
            bool moneyHas = false;
            // Delcares Bet Variable Here (Default Value = -1)
            double moneyBet = -1;
            // Writes User Friendly Sentence on What to Do, Meanwhile delcaring how much money you have and how much you will like to bet
            Console.WriteLine("\nWelcome To Mr.Poni's Casino, You Have $" + moneyHave + "\nHow much will you like to Bet?");
            // Declares and Reads Money Bet from User and Checks if it Works and Inputs it to Bet Value if it does.
            try
            {
                moneyBet = Convert.ToDouble(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Error");
            }
            while (moneyHas == false)
            {
                // Subtracts Total Money by MoneyBet
                moneyHave = moneyHave - moneyBet;
                if (moneyBet == 0)
                {
                    // Goodbye Message
                    Console.WriteLine("\nThanks For Playing...");
                    // Waits for User to Press any Key
                    Console.ReadKey();
                    // Beep For Cool Sound Effects
                    Console.Beep(294, 150);
                    // Exits Program
                    Environment.Exit(0);
                }
                else if (moneyBet < 0)
                {
                    // Reinstates the old Value
                    moneyHave = moneyHave + moneyBet;
                    // Writes Invalid Value Messages, if moneyBet is Below 0 or is 
                    Console.WriteLine("\nInvalid Value, Please Enter a New Value, You Have $" + moneyHave);
                    // Reads Money Bet from User and Checks if it Works and Inputs it to Bet Value if it does.
                    try
                    {
                        moneyBet = Convert.ToDouble(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Error");
                    }
                    // Clears The Screen for the Next Input 
                    Console.Clear();
                }
                // If You have more Money then 0 or equal to 0 after bet, allow the transaction else change back to the orginal value and Askes for another value
                else if (moneyHave >= 0)
                {
                    Console.WriteLine("\n\nThanks For Betting $" + moneyBet + ", You now have $" + moneyHave);
                    moneyHas = true;
                    Console.Write("\nPress Any Key To Countinue. . . \n");
                    // Clears The Screen for the Next Input 
                    Console.Clear();

                }
                else
                {
                    // Reinstates the Old Value
                    moneyHave = moneyHave + moneyBet;
                    // Writes User Friendly Sentence on What to Do, Meanwhile delcaring that you dont have enough money and asks how much you would like to bet instead
                    Console.WriteLine("\nYou Dont Have Enough Money, Please Bet Another Sum... You Have $" + moneyHave);
                    // Reads Money Bet from User and Checks if it Works and Inputs it to Bet Value if it does.
                    try
                    {
                        moneyBet = Convert.ToDouble(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Error");
                    }
                    // Clears The Screen for the Next Input 
                    Console.Clear();
                }
            }
            return moneyBet; 
        }

        /// <summary>
        /// Plays The Game 
        /// </summary>
        /// <param name="deck">The Deck thats Being Played With</param>
        /// <param name="moneyBet">The Amount of Money that was bet</param>
        /// <returns>Returns the Amount of Money Lost or Won</returns>
        static private double playGame(string[] deck, double moneyBet, double moneyHave)
        {
            // Declaring Important Variables
            bool errorSave = false;
            bool insurance = false;
            bool firstTurn = true;
            bool splitlost = false;
            bool lost = false;
            bool win = false;
            bool isPlayingGame = true;
            bool playersTurn = true;
            bool splitavailable = false;
            bool spliting = false;
            bool hasSplit = false;

            string choice;

            double moneyInsured = 0;
            int card = 51;
            int dealerValueOfCards = 0;
            int playerValueOfCards = 0;
            int playerSplitValueOfCards = 0;
            string[] playerCards = new string[100];
            string[] playerSplitCards = new string[100];
            string[] dealerCards = new string[100];

            // Beep For Cool Sound Effects
            Console.Beep(294, 150);
            // Clears The Screen for the Next Input 
            Console.Clear();
            // Waiting For User To Start The Game, waiting for any Key Press
            Console.WriteLine("\nLets Begin. . . Shuffling and Handing Out Cards. . .\n");
            deck = shuffle(deck);
            Console.ReadKey();
            // Another Beep For Cool Sound Effects
            Console.Beep(294, 150);
            // Clears Game Screen
            Console.Clear();
            int i = 0;

            for (; i < 2; i++)
            {
                // Hands Out Two Cards For Player
                playerCards[i] = deck[card]; 
                Console.WriteLine("You Got a " + deck[card]);
                if (playerValueOfCards + convertToInt(deck, card) > 21)
                {
                        playerCards[0] = "A - One";
                        playerValueOfCards -= 10;
                }
                playerValueOfCards += convertToInt(deck, card); 
                card--;
                // Hands Out Two Cards For Dealer
                dealerCards[i] = deck[card]; 
                if (dealerValueOfCards + convertToInt(deck, card) > 21)
                {
                    dealerCards[1] = "A - One";
                    dealerValueOfCards -= 10;
                }
                dealerValueOfCards += convertToInt(deck, card); 
                card--;
            }
            // Dealer's Open Card
            Console.WriteLine("\nDealer's Cards are a " + dealerCards[0] + " and * ");
            // If Dealer's Open Card is a Ace allow Insurance
            if (dealerCards[0] == "A") insurance = true;
            // Allow Player to make a Insurance Side Bet if avaliable
            while(insurance)
            {
                // Askes Question of Insuring or No
                Console.WriteLine("\nWould You Like To Make an Insurance Bet?\n1.Yes\n2.No");
                // Reads User's Choice
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        while (insurance)
                        {
                            // Clears Screen
                            Console.Clear();
                            // Shows How much the player has and askes, How Much Insurance does he want to bet with...
                            Console.WriteLine("You have $" + (moneyHave - moneyBet) + " and betting $" + moneyBet + " currently\nHow much money would you like to Insure?\n(Remember You can only Insure Half your Bet at most)\tTo Quit: Bet 0");
                            // Reads Money Insured from User and Checks if it Works and Inputs it to Money Insured Value if it does.
                            try
                            {
                                moneyInsured = Convert.ToDouble(Console.ReadLine());
                            }
                            catch
                            {
                                Console.WriteLine("\nError");
                                moneyInsured = -1;
                            }

                            if (moneyInsured > 0 && moneyHave - (moneyInsured + moneyBet) >= 0 && moneyInsured <= moneyBet / 2)
                            {
                                Console.WriteLine("\nThanks For Insuring $" + moneyInsured + "\n\n . . . Checking Dealer's Cards . . .");
                                // Waits For The User to Countinue 
                                Console.ReadKey();
                                // Checks if Dealer has a 21
                                if (dealerValueOfCards == 21)
                                {
                                    Console.WriteLine("\n\nThe Dealer has a Blackjack!");
                                    // Waits For The User to Countinue 
                                    Console.ReadKey();
                                    // Clears Screen 
                                    Console.Clear();
                                    isPlayingGame = false;
                                    if (playerValueOfCards != 21)
                                    {
                                        lost = true;
                                        insurance = false;
                                        moneyBet = moneyBet - (moneyInsured * 2);
                                        moneyInsured = 0;
                                        if (moneyBet == 0)
                                        {
                                            win = true;
                                        }
                                    }
                                    else
                                    {
                                        win = true;
                                        moneyBet = moneyInsured;
                                        moneyInsured = 0;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\n\nThe Dealer doesn't have a Blackjack Continuing with the game.. \nYou Have Lost $" + moneyInsured);
                                    // Waits For The User to Countinue 
                                    Console.ReadKey();
                                    // Clears Screen 
                                    Console.Clear();
                                    insurance = false;
                                }

                            }
                            else if (moneyInsured == 0)
                            {
                                Console.WriteLine("\nYou Didnt Insure Anything. . .");
                                // Waits For The User to Countinue 
                                Console.ReadKey();
                                // Clears Screen 
                                Console.Clear();
                                insurance = false;
                            }
                            else
                            {
                                Console.WriteLine("Invalid Value.. Check Again...");
                                // Waits For The User to Countinue 
                                Console.ReadKey();
                            }
                        }
                        break;
                    case "2":
                        // User Friendly Sentence
                        Console.WriteLine("\nYou Didnt Insure Anything. . . Continuing with the game..");
                        // Waits For The User to Countinue 
                        Console.ReadKey();
                        // Clears Screen 
                        Console.Clear();
                        insurance = false;
                        break;
                    default:
                        // User Friendly Sentence
                        Console.WriteLine("\nYou Didnt Pick An Option");
                        // Waits For The User to Countinue 
                        Console.ReadKey();
                        // Clears Screen 
                        Console.Clear();
                        break;
                }
            }
            // If Player Has 21 Inform Player Then Skip Game and Check if Tie Or Not After Player Presses Any Key
            if (playerValueOfCards == 21)
            {
                Console.WriteLine("\nYou Have 21 on the First Hand!");
                // Waits For The User to Countinue 
                Console.ReadKey();
                isPlayingGame = false;
                moneyBet = moneyBet * 1.5;

            }
            // If Dealer Has 21 and Player Didn't Insure inform Player After Player Presses Any Key
            if (dealerValueOfCards == 21 && win == false && lost == false)
            {
                Console.WriteLine("\nDealer Has 21 on the First Hand!");
                // Waits For The User to Countinue 
                Console.ReadKey();
                isPlayingGame = false;
            }
            // If Player Has Two of the Same Card Types, Allow Split
            if (playerCards[0] == playerCards[1] || playerCards[1] == "A - One" && playerCards[0] == "A") splitavailable = true;
            // Turns On Game Loop
            while (isPlayingGame)
            {
                if (playersTurn)
                {
                    // Shows How much Player has, if splitting shows current deck
                    if (!spliting) Console.WriteLine("\nThe Value Of Your Cards is " + playerValueOfCards);
                    else Console.WriteLine("\nThe Value Of Your Cards in the Other Hand is " + playerSplitValueOfCards);
                    // Askes Player if He Would Like to Hit or Stand
                    Console.WriteLine("\nWhat Would You Like To Do?\n1.Hit\n2.Stand");
                    if (firstTurn && splitavailable) Console.WriteLine("3.DoubleDown\n4.Surrender\n5.Split");
                    else if (firstTurn) Console.WriteLine("3.DoubleDown\n4.Surrender");
                    choice = Console.ReadLine();
                    if (spliting)
                    {
                        switch (choice)
                        {
                            // If Hits
                            case "1":
                                // If next card is an ace with value of 11 and player's other deck goes over 21 with the addition make it value of one
                                if (convertToInt(deck, card) == 11 && playerSplitValueOfCards + convertToInt(deck, card) > 21)
                                {
                                    // Move up player's other hand
                                    i++;
                                    // Player's other deck add ace with value of one
                                    playerSplitCards[i] = "A - One";
                                    // Increase player's split value of cards to value of 1
                                    playerSplitValueOfCards += 1;
                                    // User Friendly Sentence
                                    Console.WriteLine("\nYou Hit! You got a " + deck[card] + ", You have " + playerSplitValueOfCards);
                                    // Move Down Deck
                                    card--;
                                }
                                else
                                {
                                    // Move up player's other hand
                                    i++;
                                    // Add card to player's other hand's deck
                                    playerSplitCards[i] = deck[card];
                                    // Add card  value to player's other hand's card values
                                    playerSplitValueOfCards += convertToInt(deck, card);
                                    // User Friendly Sentence
                                    Console.WriteLine("\nYou Hit! You got a " + deck[card] + ", You have " + playerSplitValueOfCards);
                                    // Move Down the deck
                                    card--;
                                }
                                // If Players split value of cards goes over 21 then
                                if (playerSplitValueOfCards > 21)
                                {
                                    // Check if player's split deck has an ace
                                    int index = checkIfHasAce(playerSplitCards);
                                    // if has ace with value of 11 then change it to ace with the value of 1
                                    if (playerSplitCards[index] == "A")
                                    {
                                        // Changes the name to value of one
                                        playerSplitCards[index] = "A - One";
                                        // Subtracts 10 from player split value of cards
                                        playerSplitValueOfCards -= 10;
                                        // User friendly sentence
                                        Console.WriteLine("\nPlayer Had An Ace.. Ace's Value Changed to One, Player has " + playerSplitValueOfCards);
                                    }
                                    else
                                    {
                                        // else go to other hand and lose this hand
                                        splitlost = true;
                                        spliting = false;
                                        // change other hand's deck starting value to 0
                                        i = 0;
                                    }
                                }
                                
                                // Waits For The User to Countinue 
                                Console.ReadKey();
                                // Clears Screen 
                                Console.Clear();
                                break;
                            // If Stands
                            case "2":
                                // User Friendly Sentence
                                Console.WriteLine("\nYou Stand with " + playerSplitValueOfCards);
                                // Waits For The User to Countinue 
                                Console.ReadKey();
                                // Clears Screen
                                Console.Clear();
                                // Go to Next Hand
                                spliting = false;
                                // Start at 0 for player's hand
                                i = 0;
                                break;
                            // If No Value is given
                            case "":
                                // User Friendly Sentence
                                Console.WriteLine("\nPlease Enter A Choice");
                                // If First Turn, Dont Turn Off Options
                                if (firstTurn)
                                {
                                    errorSave = true;
                                }
                                // Waits For The User to Countinue 
                                Console.ReadKey();
                                // Clears Screen 
                                Console.Clear();
                                break;
                        }
                }
                else
                {
                    // Checks Choice in an Switch Cards on main deck
                    switch (choice)
                    {
                            // If Case "1" Then Hit The Player
                        case "1":
                            // If The Next Card is an Ace with a value of 11 and The Player Goes Over 21 then Convert it to 1
                            if (convertToInt(deck, card) == 11 && playerValueOfCards + convertToInt(deck, card) > 21)
                            {
                                // Countinues Up The Players Deck
                                i++;
                                // Adds an Ace Value Of One to Player's Deck
                                playerCards[i] = "A - One";
                                // Increases Player Card value by 1
                                playerValueOfCards += 1;
                                Console.WriteLine("\nYou Hit! You got a " + deck[card] + ", You have " + playerValueOfCards);
                                // Moves Down The Deck
                                card--;
                            }
                            // Else Hit The Player
                            else
                            {
                                // Countinues Up The Players Deck
                                i++;
                                // Adds Card to Player's Deck
                                playerCards[i] = deck[card];
                                // Adds The Card Value to the Player's Cards Value
                                playerValueOfCards += convertToInt(deck, card);
                                // User Friendly Output..
                                Console.WriteLine("\nYou Hit! You got a " + deck[card] + ", You have " + playerValueOfCards);
                                // Moves Down The Deck
                                card--;
                            }
                            // If Player has over 21 Do..
                            if (playerValueOfCards > 21)
                            {
                                // Check If Has a valid ace of a value of 11
                                int index = checkIfHasAce(playerCards);
                                // If Has Ace Do .. Else End Game Unless has a 2nd deck which didnt lose 
                                if (playerCards[index] == "A")
                                {
                                    playerCards[index] = "A - One";
                                    playerValueOfCards -= 10;
                                    Console.WriteLine("\nPlayer Had An Ace.. Ace's Value Changed to One, Player has " + playerValueOfCards);
                                }
                                else
                                {
                                    // Declare this hand has lost
                                    lost = true;
                                    // End game unless player has a 2nd deck which didnt lose then end players turn and go to dealer's turn
                                    if (!hasSplit || hasSplit && splitlost)
                                    {
                                        isPlayingGame = false;
                                    }
                                    else
                                    {
                                        playersTurn = false;
                                    }
                                }
                            }
                            
                            // Waits For The User to Countinue 
                            Console.ReadKey();
                            // Clears Screen 
                            Console.Clear();
                            break;
                        // If Stands Do this...
                        case "2":
                            // User Friendly Sentence
                            Console.WriteLine("\nYou Stand with " + playerValueOfCards);
                            // Waits For The User to Countinue 
                            Console.ReadKey();
                            // Ends Player's Turn
                            playersTurn = false;
                            break;
                        // If Didnt Enter a Choice 
                        case "":
                            // User Friendly Sentence
                            Console.WriteLine("\nPlease Enter A Choice");
                            // If First Turn, Dont Turn Off Options
                            if (firstTurn)
                            {
                                errorSave = true;
                            }
                            // Waits For The User to Countinue 
                            Console.ReadKey();
                            // Clears Screen 
                            Console.Clear();
                            break;
                    }
                }
                    // Allow FirstTurn Choices to be Used if it's the First Turn.
                    if (firstTurn)
                    {
                        switch (choice)
                        {
                            // If DoubleDown do....
                            case "3":
                                // Checks if player has enough money to double down if not tell player he doesnt have
                                if (moneyHave - moneyBet * 2 >= 0)
                                {
                                    // If The Next Card is an Ace with a value of 11 and The Player Goes Over 21 then Convert it to 1
                                    if (convertToInt(deck, card) == 11 && playerValueOfCards + convertToInt(deck, card) > 21)
                                    {
                                        // Countinues Up The Players Deck
                                        i++;
                                        // Adds an Ace Value Of One to Player's Deck
                                        playerCards[i] = "A - One";
                                        // Increases Player Card value by 1
                                        playerValueOfCards += 1;
                                        // User Friendly Sentence
                                        Console.WriteLine("\nYou Hit! You got a " + deck[card] + ", You have " + playerValueOfCards);
                                        // Moves Down The Deck
                                        card--;
                                    }
                                    // Else Hit The Player
                                    else
                                    {
                                        // Countinues Up The Players Deck
                                        i++;
                                        // Adds Card to Player's Deck
                                        playerCards[i] = deck[card];
                                        // Adds The Card Value to the Player's Cards Value
                                        playerValueOfCards += convertToInt(deck, card);
                                        // User Friendly Output..
                                        Console.WriteLine("\nYou Hit! You got a " + deck[card] + ", You have " + playerValueOfCards);
                                        // Moves Down The Deck
                                        card--;
                                    }
                                    // If Player has over 21 Do..
                                    if (playerValueOfCards > 21)
                                    {
                                        // Checks if has Ace in Hand with the value of 11 
                                        int index = checkIfHasAce(playerCards);
                                        // If Has Ace in hand with the value off 11 
                                        if (playerCards[index] == "A")
                                        {
                                            // Give Ace the Value of One From 11
                                            playerCards[index] = "A - One";
                                            // Subtract 10 from player value of Cards
                                            playerValueOfCards -= 10;
                                            // User Friendly Sentence
                                            Console.WriteLine("\nPlayer Had An Ace.. Ace's Value Changed to One, Player has " + playerValueOfCards);
                                        }
                                        else
                                        {
                                            // Else End Game and Lose
                                            lost = true;
                                            isPlayingGame = false;
                                        }
                                    }
                                    // Waits For The User to Countinue 
                                    Console.ReadKey();
                                    // Ends Players Turn 
                                    playersTurn = false;
                                    // Multiplies MoneyBet by Two
                                    moneyBet = moneyBet * 2;
                                }
                                else
                                {
                                    // User Friendly Sentence
                                    Console.WriteLine("\nYou Don't Have Enough Money to Double Down");
                                    // Do Not Turn Off Options
                                    errorSave = true;
                                    // Waits For The User to Countinue 
                                    Console.ReadKey();
                                    // Clears Screen 
                                    Console.Clear();
                                }
                                break;
                            // If Surrender 
                            case "4":
                                // Divid MoneyBet by 2
                                moneyBet = moneyBet / 2;
                                // User Friendly Sentence
                                Console.WriteLine("\nYou Have Surrendered! (You have Lost Only Half of What You Betted)");
                                // Waits For The User to Countinue 
                                Console.ReadKey();
                                // Clears Screen 
                                Console.Clear();
                                // Lose The Game
                                lost = true;
                                isPlayingGame = false;
                                break;
                        }
                    }
                    // If Split Available Allow Choice To Be Used.
                    if (splitavailable)
                    {
                        switch (choice)
                        {
                            // If Player Picked to Split
                            case "5":
                                // Checks If Player has enough money if not Tell them
                                if (moneyHave - moneyBet * 2 >= 0)
                                {
                                    // Enable and add Value to the Second Deck.. Also make Has Split true
                                    spliting = true;
                                    hasSplit = true;
                                    // If Player is Splitting Two Aces make the ace with the value of 1 into Ace witha  value of 11 in players deck.
                                    if (playerCards[1] == "A - One" && playerCards[0] == "A")
                                    {
                                        playerCards[1] = "A";
                                        playerValueOfCards += 10;
                                    }
                                    // Adds and Changes Value in both decks
                                    playerSplitCards[0] = playerCards[1];
                                    playerValueOfCards -= convertToInt(playerCards, 1);
                                    playerSplitValueOfCards += convertToInt(playerCards, 1);
                                    playerCards[1] = "";
                                    // Increases the Money Bet
                                    moneyBet = moneyBet * 2;
                                    // Change to i Value to 0 so cards start at value 1 to dealing with other cards
                                    i = 0;
                                    // Clears Screen 
                                    Console.Clear();
                                }
                                else
                                {
                                    // You Dont Have Enough Money To Split...
                                    Console.WriteLine("\nYou Don't Have Enough Money to Split");
                                    // Saves Other Options if there isnt Enough Money
                                    errorSave = true;
                                    // Waits For The User to Countinue 
                                    Console.ReadKey();
                                    // Clears Screen 
                                    Console.Clear();
                                }
                                break;
                        }
                    }
                    // If Player Didn't Do The FirstTurn Availiable Options Then Disable Them or If Player Already split dont show option again.
                    if (splitavailable || firstTurn )
                    {
                        if (!errorSave)
                        {
                            firstTurn = false;
                            splitavailable = false;
                        }
                        else errorSave = false;
                    }
                }
                else
                {
                    // Start Count at 1 on dealer's hand
                    i = 1;
                    // If Dealer is over 16 make the dealer stand
                    if (dealerValueOfCards > 16)
                    {
                        // User Friendly Sentence
                        Console.WriteLine("\nThe Dealer Stands with " + dealerValueOfCards);
                        // Waits For The User to Countinue 
                        Console.ReadKey();
                        isPlayingGame = false;
                    }
                    else
                    {
                        // if next card is 11 and it sends them over 21 do this else just hit
                        if (convertToInt(deck, card) == 11 && dealerValueOfCards + convertToInt(deck, card) > 21)
                        {
                            // Moves Up The Dealers Cards
                            i++;
                            // Changes Dealer Card to a Ace with value of one
                            dealerCards[i] = "A - One";
                            // Adds 1 to the dealers value
                            dealerValueOfCards += 1;
                            // User Friendly Sentence
                            Console.WriteLine("\nDealer Hit! Dealer got a " + deck[card] + ", Dealer has " + dealerValueOfCards);
                            // Moves Down The Deck
                            card--;
                        }
                        // Else Hit The Dealer
                        else
                        {
                            // Moves Up The Dealers Cards
                            i++;
                            // Adds the card to the dealers Deck
                            dealerCards[i] = deck[card];
                            // Adds the card value to the Dealer's value of cards
                            dealerValueOfCards += convertToInt(deck, card);
                            // User Friendly Sentence
                            Console.WriteLine("\nDealer Hit! Dealer got a " + deck[card] + ", Dealer has " + dealerValueOfCards);
                            // Moves Down The Deck
                            card--;
                        }
                        // If Dealer Goes over 21 do this
                        if (dealerValueOfCards > 21)
                        {
                            // Checks to see if dealer has an Ace of 11 in the deck
                            int index = checkIfHasAce(playerCards);
                            // If Dealer has ace in his deck do this else dealer busts
                            if (dealerCards[index] == "A")
                            {
                                // Changes Dealer's A to Ace with the value of one
                                dealerCards[index] = "A - One";
                                // Subtracts 10 from dealers value of cards
                                dealerValueOfCards -= 10;
                                // User Friendly Sentence
                                Console.WriteLine("\nDealer Had An Ace.. Ace's Value Changed to One, Dealer has " + dealerValueOfCards);
                            }
                            else
                            {
                                // End game with a win
                                win = true;
                                isPlayingGame = false;
                            }
                        }
                        // Waits For The User to Countinue 
                        Console.ReadKey();
                    }
                }
            }

            // If Has Split Different Results Occur and Checks 
            if (hasSplit)
            {
                // If Won on both hands win the money bet
                if (lost == false && splitlost == false && dealerValueOfCards < playerValueOfCards && dealerValueOfCards < playerSplitValueOfCards 
                    || win == true && lost == false && splitlost == false)
                {
                    // Winning Song
                    Console.Beep(370, 500);
                    Console.Beep(392, 250);
                    Console.Beep(330, 250);
                    Console.Beep(440, 500); 
                    Console.WriteLine("\nYou Won $" + moneyBet);
                    return moneyBet - moneyInsured;
                }
                // If Both pushed then no money gained or lost
                else if (dealerValueOfCards == playerValueOfCards && dealerValueOfCards == playerSplitValueOfCards || win == true && lost == true && splitlost == true)
                {
                    // Tie Song
                    Console.Beep(587, 333);
                    Console.Beep(261, 334);
                    Console.Beep(658, 333);
                    Console.Write("\nBoth Hands Have Pushed..No Money Gained or Lost");
                    return 0 - moneyInsured;
                }
                // If one has lost while another one has won then no money gained or lost
                else if (lost == false && splitlost == true && dealerValueOfCards < playerValueOfCards || 
                    lost == true && splitlost == false && dealerValueOfCards < playerSplitValueOfCards ||
                    lost == false && splitlost == false && playerSplitValueOfCards < dealerValueOfCards && dealerValueOfCards < playerValueOfCards ||
                    lost == false && splitlost == false && playerValueOfCards < dealerValueOfCards && dealerValueOfCards < playerSplitValueOfCards ||
                    lost == false && splitlost == true && win == true || lost == true && splitlost == false && win == true)
                {
                    // Tie Song
                    Console.Beep(587, 333);
                    Console.Beep(261, 334);
                    Console.Beep(658, 333);
                    Console.WriteLine("\nOne Of Your Hands has Lost, While the Other Won.. No Money Gained or Lost");
                    return 0 - moneyInsured;
                }
                // If One has pushed and the other has won win half of the money betted
                else if (dealerValueOfCards == playerValueOfCards && dealerValueOfCards < playerSplitValueOfCards && lost == false && splitlost == false ||
                    dealerValueOfCards == playerSplitValueOfCards && dealerValueOfCards < playerValueOfCards && lost == false && splitlost == false)
                {
                    // Winning Song
                    Console.Beep(370, 500);
                    Console.Beep(392, 250);
                    Console.Beep(330, 250);
                    Console.Beep(440, 500); 
                    moneyBet = moneyBet / 2;
                    Console.WriteLine("\nOne of Your Hands Has Pushed, while One Has Won.. You Have Won $" + moneyBet);
                    return moneyBet - moneyInsured;
                }
                // If One of the hands was pushed and one lost lose half the money betted
                else if (dealerValueOfCards == playerValueOfCards && splitlost == true || 
                    dealerValueOfCards == playerSplitValueOfCards && lost == true ||
                    dealerValueOfCards == playerValueOfCards && dealerValueOfCards > playerSplitValueOfCards && lost == false && splitlost == false ||
                    dealerValueOfCards == playerSplitValueOfCards && dealerValueOfCards > playerValueOfCards && lost == false && splitlost == false)
                {
                    // Losing Sound
                    Console.Beep(261, 400);
                    Console.Beep(174, 600);
                    moneyBet = moneyBet / 2;
                    Console.WriteLine("\nOne of Your Hands Has Pushed, while One Has Lost.. You Have Lost $" + moneyBet);
                    return -moneyBet - moneyInsured;
                }
                // If Lost lose moneybet
                else if (lost == true && splitlost == true && win == false ||
                    dealerValueOfCards > playerValueOfCards && dealerValueOfCards > playerSplitValueOfCards && lost == false && splitlost == false ||
                    dealerValueOfCards > playerValueOfCards && splitlost == true ||
                    dealerValueOfCards > playerSplitValueOfCards && lost == true)
                {
                    // Losing Sound
                    Console.Beep(261, 400);
                    Console.Beep(174, 600);
                    Console.WriteLine("\nYou Lost $" + moneyBet);
                    return -moneyBet - moneyInsured;
                }
                // Just For Problems to fall back on
                else
                {
                    return moneyBet;
                }
            }
            // Regular Lose and Win/Push for a single hand play
            else
            {
                // If Won
                if (lost == false && dealerValueOfCards < playerValueOfCards || win == true && lost == false)
                {
                    // Winning Song
                    Console.Beep(370, 500);
                    Console.Beep(392, 250);
                    Console.Beep(330, 250);
                    Console.Beep(440, 500); 
                    Console.WriteLine("\nYou Won $" + moneyBet);
                    return (moneyBet - moneyInsured);
                }
                // If Push
                else if (dealerValueOfCards == playerValueOfCards || win == true && lost == true)
                {
                    // Tie Song
                    Console.Beep(587, 333);
                    Console.Beep(261, 334);
                    Console.Beep(658, 333);
                    Console.WriteLine("\nPush... No Money Won or Lost");
                    moneyBet = 0 - moneyInsured;
                    return moneyBet;
                }
                // If Lose
                else if (lost == true && win == false || dealerValueOfCards > playerValueOfCards)
                {
                    // Losing Sound
                    Console.Beep(261, 400);
                    Console.Beep(174, 600);
                    Console.WriteLine("\nYou Lost $" + moneyBet);
                    moneyBet = -moneyBet - moneyInsured;
                    return moneyBet;
                }
                // Just For Problems to Fall Back On...
                else
                {
                    return moneyBet;
                }
            }

        }
        
        /// <summary>
        /// Shuffles the Deck 
        /// </summary>
        /// <param name="deck">The Deck thats being Shuffled</param>
        /// <returns>Returns The New Shuffled Deck</returns>
        static private string[] shuffle(string[] deck)
        {
            // Declaring Randomizer 
            Random shuffler = new Random();

            // Declaring Variables
            int shuffleIndex;
            int shuffleIndexTwo;
            string temp;

            for (int i = 0; i < 10000; i++)
            {
                shuffleIndex = shuffler.Next(0, deck.Length);
                shuffleIndexTwo = shuffler.Next(0, deck.Length);
                temp = deck[shuffleIndex];
                deck[shuffleIndex] = deck[shuffleIndexTwo];
                deck[shuffleIndexTwo] = temp;
            }

            // Returning Shuffled Deck
            return deck;
        }

        /// <summary>
        /// Checks if theDeck has an Ace, returns index value of Ace if you do...
        /// </summary>
        /// <param name="theDeck">The Deck Thats given, and needs to be checked</param>
        /// <returns>Index Value Of Index</returns>
        static private int checkIfHasAce(string[] theDeck)
        {
            // Declaring Index Variable
            int index = -1;

            // Declaring Bool Variable
            bool isDoneChecking = false;

            // Implementing While Loop
            while (!isDoneChecking)
            {
                index++;
                if (theDeck[index] == "A")
                {
                    isDoneChecking = true;
                }
                else if (index == theDeck.Length - 1)
                {
                    isDoneChecking = true;
                }
            }
            
            // Returning Index Value of Ace Location, if no Ace Location, returns the Last Index of Deck
            return index;
        }

        /// <summary>
        /// Converts a card in the deck to a int.
        /// </summary>
        /// <param name="deck">The Given Deck</param>
        /// <param name="index">The Given Index</param>
        /// <returns>Returns Int Value of the Card in the Deck</returns>
        static private int convertToInt(string[] deck, int index)
        {
            int returnValue = 0;
            switch (deck[index])
            {
                case "A":
                    returnValue = 11;
                    break;
                case "K":
                    returnValue = 10;
                    break;
                case "Q":
                    returnValue = 10;
                    break;
                case "J":
                    returnValue = 10;
                    break;
                case "10":
                    returnValue = 10;
                    break;
                case "9":
                    returnValue = 9;
                    break;
                case "8":
                    returnValue = 8;
                    break;
                case "7":
                    returnValue = 7;
                    break;
                case "6":
                    returnValue = 6;
                    break;
                case "5":
                    returnValue = 5;
                    break;
                case "4":
                    returnValue = 4;
                    break;
                case "3":
                    returnValue = 3;
                    break;
                case "2":
                    returnValue = 2;
                    break;
            }
            return returnValue;
        }
    }
}

