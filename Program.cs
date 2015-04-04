using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp;
using LeagueSharp.Common;

namespace HelloWorld
{
    class Program
    {
        private static Orbwalking.Orbwalker Orbwalker;
        private static Spell Q, W, E, R;
        private static Menu Menu;

        static void Main(string[] args)
        {
            CustomEvents.Game.OnGameLoad += Game_OngameLoad;
        }
        static void Game_OngameLoad(EventArgs args)
        {
            Q = new Spell(SpellSlot.Q, 950); // create Q spell with a range of 125 units
            W = new Spell(SpellSlot.W, 700); // create W spell with a range of 700 units
            E = new Spell(SpellSlot.E, 550); // create E spell with a range of 550 units
            R = new Spell(SpellSlot.R, 650); // create R spell with a range of 650 units
            Menu = new Menu(ObjectManager.Player.ChampionName, ObjectManager.Player.ChampionName, true);
            Menu orbwalkerMenu = Menu.AddSubMenu(new Menu("Orbwalker", "Orbwalker"));
            Orbwalker = new Orbwalking.Orbwalker(orbwalkerMenu);
            Menu ts = Menu.AddSubMenu(new Menu("Target Selector", "Target Selector")); ;
            TargetSelector.AddToMenu(ts);
            Menu spellMenu = Menu.AddSubMenu(new Menu("Spells", "Spells"));
            spellMenu.AddItem(new MenuItem("useQ", "Use Q").SetValue(true));
            Menu.AddToMainMenu();

            if (ObjectManager.Player.ChampionName != "Graves")
                return;

                Game.PrintChat("Graves 3.0");
        }

        static void Game_OnGameUpdate(EventArgs args)
        {
            if (Orbwalker.ActiveMode == Orbwalking.OrbwalkingMode.Combo)
            {
                Buckshot();
            }
        }

        private static void Buckshot()
        {
            // check if the player wants to use E
            //if (!Menu.Item("useE").GetValue<bool>())
            //   return;

            // gets best target in Dfg(750) / E(550)
            Obj_AI_Hero target = TargetSelector.GetTarget(750, TargetSelector.DamageType.Magical);

            // check if E ready
            if (Q.IsReady())
            {
                // check if we found a valid target in range
                if (target.IsValidTarget(Q.Range))
                {
                    // blast him
                    Q.CastOnUnit(target);
                }
            }
        }

    }
}
