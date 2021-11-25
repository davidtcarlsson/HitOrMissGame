using System;

namespace ProjektarbeteV2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Körexempel
            //"1, 1,5 ;" "SQUARE , 5,3 ,10 ;" " SQUARE, 5;"
            // Output: 6

            //"1, 1,5 ;" "SQUARE , 5,3 ,10 ;CIRCLE, 1,1, 12;" " SQUARE, 5;CIRCLE,10;" 
            // Output: 121

            //"1, 1,5 ;2,2,10" "SQUARE , 5,3 ,10 ;CIRCLE, 1,1, 12; TRIANGLE, 0, 0, 60;" " TRIANGLE, 3;SQUARE, 5;CIRCLE,10;"
            // Output: 1287

            //"1, 1,5 ;2,2,10" "SQUARE , 5,3 ,10 ;CIRCLE, 1,1, 12; TRIANGLE, 0, 0, 60;OCTAGON, 1,-20, 15" " TRIANGLE, 3;SQUARE, 5;OCTAGON, 7;CIRCLE,10;"
            // Output: 1313

            HitOrMissGame game = new HitOrMissGame(args);
            Console.WriteLine(Math.Round(game.GetScore(), 0));
        }
    }
}
