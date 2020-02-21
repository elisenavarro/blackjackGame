using System;

namespace blackjackGame
{
  class Program
  {
    static void Main(string[] args)
    {
      //Declare Variables
      Console.WriteLine("Write your name here: ");
      string playerName = Console.ReadLine();
      bool playing = true;
      while (playing == true)
      {
        Game game = new Game();
        game.Playing(playerName);
        Console.WriteLine("Press 'ENTER' to continue");
        Console.ReadLine();
        Console.Clear();
        // Ask User To Play Again
        Console.WriteLine("Would you like to play again? Y/N");
        bool response = true;
        string isValidResponse = Console.ReadLine().ToLower();
        // Loop while correct response returned
        while (response)
        {
          if(isValidResponse == "y" || isValidResponse == "yes")
          {
            playing = true;
            response = false;
          }
          else if (isValidResponse == "n" || isValidResponse == "no")
          {
            playing = false;
            response = false;
          }
          else
          {
            Console.Write("Invalid Input. Enter 'Y' or 'N'");
            isValidResponse = Console.ReadLine();
          }
        }
      }
      Console.Clear();
    }
  }
}
