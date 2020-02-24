using System;

class Dealer : Player // Dealer inherits from Player base class
{
  public override void Hold() // overridden base method
  {
    CheckOverTwentyOne();
    if (Over)
    {
      Console.WriteLine("The Dealer's hand was over 21. Dealer Lost", total);
      total = 0; //set total value
    }
    else
    {
      Console.WriteLine("The Dealer holds at {0}", total);
    }
  }
}
