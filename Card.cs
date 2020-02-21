using System;
using System.Collections.Generic;

class Card
{
  private readonly Random randomCard = new Random(DateTime.Now);
  public List<string> Deck = new List<string>();

  // List all possible card values
  public void CreateDeck()
  {
    List<string> values = new List<string>
    {
      "2",
      "3",
      "4",
      "5",
      "6",
      "7",
      "8",
      "9",
      "10",
      "Jack",
      "Queen",
      "King",
      "Ace"
    };
    // List all card suites
    List<string> suits = new List<string>
    {
      "Spades",
      "Diamonds",
      "Hearts",
      "Clubs"
    };
    foreach (string suit in suits)
    {
        Deck.Add($"{value} of {suit}");
    }
  }

  public int DealCard(bool secret)
  {
    int value = 0;
    int randomCard = randomCard.Next(Deck.Count);
    string card = Deck[randomCard];
    Deck.RemoveCardAt(randomCard); // remove drawn card from deck

    if (!secret)
    {
      Console.Write(" was dealt the {0}\n", card);
    }
    // Get Value of Card @ Index 0
    // Assign Values to # Other Than Ten
    if (card[0] == '2' || card[0] == '3' || card[0] == '4' || card[0] == '5'|| card[0] == '6' || card[0] == '7' || card[0] == '8' || card[0] == '9')
    {
      value = int.Parse(card[0].ToString());
    }
    //Assign Values to Face & Ten Cards
    else if (card[0] == '1' || card[0] == 'J' || card[0] == 'Q'|| card[0] == 'K')
    {
      value = 10;
    }
    //Assign Value to Ace = 11
    else if (card[0] == 'A')
    {
      value = 11;
    }
    return value;
  }
}
