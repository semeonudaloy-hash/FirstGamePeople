using FirstGamePeople.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGamePeople
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //123
            SGame game = new SGame();
            string error = game.Initialize();
            if (error != "")
            {
                Console.WriteLine($"ERROR!!! {error}");
                return;
            }   

            game.Start();
        }
    }
}
