using System;

namespace ProjektarbeteV2
{
    class Program
    {
        static void Main(string[] args)
        {
            //"1, 1, 5 ; 2, 2, 10" "CIRCLE, 5, 3, 100 ; CIRCLE, 1, 1, 200; " "SQUARE, 5 ; CIRCLE, 10"
            string[] testArgs = {
                "1, 1,5 ;",
                "TEST , 5,3 ,10 ;CIRCLE, 1,1, 12;",
                " SQUARE, 5;CIRCLE,10;"
            };
            // "1, 1,5 ;" "SQUARE , 5,3 ,10 ;" " SQUARE, 5;"

            HitOrMissGame game = new HitOrMissGame(testArgs);
            Console.WriteLine(Math.Round(game.GetScore(), 0));
        }
    }
}
