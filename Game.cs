using System;
using System.Configuration;

// Set game results/status
enum Status
{
  GameOn,
  PlayerWin,
  DealerWin,
  Draw,
  Blackjack
}

class Game
{
  Status status = Status.GameOn; //set start of game
  Dealer dealer = new Dealer(); //new instance of Dealer
  Player player = new Player(""); //new instance of player
  Card deck = new Card(); // new deck
  //Player calls for card while score < 21
  public void PlayerCall() // PlayerCall does not have a return value
  {
    player.CheckOverTwentyOne();
    if (!player.Over)
    {
      Console.Write("{0} Call", player.Name);
      player.hand.Add(deck.DealCard(false));
      player.GetTotal();
    }
  }
  //Set Cards
  public void InitialCall() // method doesn't have a return value
  {
    PlayerCall();
    PlayerCall();

    dealer.CheckOverTwentyOne();
    if (!dealer.Over)
    {
      Console.Write("The Dealers Call");
      dealer.hand.Add(deck.DealCard(false));
      Console.WriteLine("Dealer gets second card");
      dealer.hand.Add(deck.DealCard(true));
      dealer.CheckOverTwentyOne();
    }
  }

  //Dealer calls for card until 16
  public int DealerCall() // / method returns integer
  {
    while (dealer.total < 16)
    {
      Console.Write("Dealers Call");
      dealer.hand.Add(deck.DealCard(false));
      dealer.CheckOverTwentyOne();
    }
    dealer.Hold();
    return dealer.total;
  }

//First Round of Cards
  public void Playing(string playerName) // method doesn't have a return value
  {
    player.Name = playerName;
    player.CheckOverTwentyOne();
    deck.CreateDeck(); // From Card Class
    InitialCall();
    //Player Wins if Cards = 21
    if (player.HasBlackjack() == true) // Est in Player Class
    {
      Console.WriteLine($"Congrats {player.Name} you've got a Blackjack!");
      byte status = (byte)Status.blackjack;
    }
    else
    {
    //Loop Player Call for Cards While < 21 and not holding
      while (!player.Over && !player.isHolding) // Est in Player Class
      //Promt Player to call card
      {
        Console.WriteLine("Press C to CALL another card OR press H to HOLD." + "\nPress V to VIEW your cards");
        //Get Player Input
        string input = Console.ReadLine().ToLower();
        if (input == "c")
        {
          PlayerCall();
        }
        else if (input == "h")
        {
          player.Hold();
        }
        else if (input == "v")
        {
          player.ViewHand(); //Est in Player Class
        }
        else
        {
          Console.Write("Invalid Input. Type a valid entry C/H/V");
          input = Console.ReadLine().ToLower();
        }
        player.CheckOverTwentyOne();
      }
    if (player.Over)
    {
      Console.Write("{0}'s cards are {1} so its a bust", player.Name, player.total);
    }
    DealerCall();
    }
  }
  //Return Winner
  public void GetWinner() // method does not have a return value
  {
    switch (status) // alternative to if..else
    {
      case Status.PlayerWin:
        Console.WriteLine($"{player.Name} Won!");
        break;
      case Status.DealerWin:
        Console.WriteLine("Dealer Won");
        break;
      case Status.Draw:
        Console.WriteLine("It's a draw");
        break;
      case Status.Blackjack:
        Console.WriteLine($"{player.Name} got Blackjack!");
        break;
    }
  }

  //Count Card Total & Compare Dealer vs Player
  void CompareCards() // method does not have a return value
  {
    if (player.total > 21)
        player.total = 0;
    if (dealer.total > 21)
        dealer.total = 0;
    if (player.total > dealer.total)
    {
      status = (byte)Status.PlayerWin;
    }
    else if (dealer.total > player.total)
    {
      status = (byte)Status.DealerWin;
    }
    else
    {
      status = (byte)Status.Draw;
    }
    if (player.Over && dealer.Over)
    {
      status = (byte)Status.Draw;
    }
  }
}
