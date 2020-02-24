using System;
using System.Collections.Generic;

class Player // set the player
{
  public string Name {get; set; }
  public List<int> hand = new List<int>();
  public bool Over = false;
  public bool isHolding = false;
  public int total;
  public Player(string name = "") // set player name
  {
    Name = name;
    total = 0;
  }

  // Get total value of cards in hand
  public int GetTotal()
  {
    total = 0; //set initial total to zero
    foreach (int card in hand)
    {
      total += card; //add value of each card to total
    }
    return total;
  }

  // check if player has Blackjack
  public bool HasBlackjack()
  {
    return (total == 21) ? true : false;
  }

  // Check is player/dealer hand is over 21
  public bool CheckOverTwentyOne()
  {
    GetTotal();
    return Over = (total > 21) ? true : false;
  }

  // Ask player to Hold or Draw another card
  public virtual void Hold()
  {
    CheckOverTwentyOne();
    if (!Over)
    {
      Console.WriteLine("{0} holds at {1}", Name, total);
    }
    isHolding = true;
  }

  // Allow player to view hand
  public virtual void ViewHand()
  {
    Console.WriteLine("{0}'s cards are {1}", Name, total);
  }

  // Update the value of Ace card
  public void UpdateAces()
  {
    while (!Over && hand.Constains(11)) // Ace value = 11
    {
      hand[hand.FindIndex(index => index.Equals(11))] = 1; // update Ace value to 1
      CheckOverTwentyOne();
    }
  }
}
