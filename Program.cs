using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp;

namespace HelloWorld
{
    class Program
    {
        private static Spell Q, W, E, R;

        static void Main(string[] args)
        {
            CustomEvents.Game.OnGameLoad += Game_OnGameLoad;
        }
        static void Game_OngameLoad(EventArgs args)
        {
            if (Player.ChampionName != "Graves")
            {
                return;
            }
            else
            {
                Game.PrintChat("Graves 1.0");
            }
        }
        
    }
}
