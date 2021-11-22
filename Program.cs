using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjektarbeteV2
{
    class Program
    {
        static void Main(string[] args)
        {
            //"1, 1, 5 ; 2, 2, 10" "CIRCLE, 5, 3, 100 ; CIRCLE, 1, 1, 200; " "SQUARE, 5 ; CIRCLE, 10"
            string[] testArgs = {
                "1, 1, 5 ; 2, 2, 10",
                "CIRCLE, 5, 3, 100 ; CIRCLE, 1, 1, 200; ",
                "SQUARE, 5 ; CIRCLE, 10"
            };

            HitOrMissGame game = new HitOrMissGame(testArgs);
            game.Start();
        }
    }
}
