using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using LeagueSharp;
using LeagueSharp.Common;
using Color = System.Drawing.Color;

class Program
{
    private static Obj_AI_Hero Player { get { return ObjectManager.Player; } }

    private static Orbwalking.Orbwalker Orbwalker;

    private static Spell Q;

    private static Menu Menu;

    
        static void Main(string[] args)
        {
            CustomEvents.Game.OnGameLoad += Game_OnGameLoad;
        }

     private static void Game_OnGameLoad(EventArgs args)
        {
            if (Player.ChampionName != "Twitch")
                return;

           Q = new Spell(SpellSlot.Q, 950);


            Menu = new Menu(Player.ChampionName, Player.ChampionName, true);
            Menu orbwalkerMenu = Menu.AddSubMenu(new Menu("Orbwalker", "Orbwalker"));
            Orbwalker = new Orbwalking.Orbwalker(orbwalkerMenu);

            Menu ts = Menu.AddSubMenu(new Menu("Target Selector", "Target Selector")); ;
            TargetSelector.AddToMenu(ts);

            Menu spellMenu = Menu.AddSubMenu(new Menu("Spells", "Spells"));
            spellMenu.AddItem(new MenuItem("useQ", "Use Q").SetValue(true));

            Menu.AddToMainMenu();

            Drawing.OnDraw += Drawing_OnDraw;

            Game.OnUpdate += Game_OnUpdate;

            Game.PrintChat("lol");
        }


     private static void Game_OnUpdate(EventArgs args)
     {
         // dont do stuff while dead
         if (Player.IsDead)
             return;

         // checks the current Orbwalker mode Combo/Mixed/LaneClear/LastHit
         if (Orbwalker.ActiveMode == Orbwalking.OrbwalkingMode.Combo)
         {
             // combo to kill the enemy
             Ambush();
         }

         if (Orbwalker.ActiveMode == Orbwalking.OrbwalkingMode.Mixed)
         {
             // farm and harass
             Ambush();
         }
     }

            private static void Drawing_OnDraw(EventArgs args)
            {
                // dont draw stuff while dead
                if (Player.IsDead)
                    return;

                // check if E ready
                if (Q.IsReady())
                {
                    // draw Aqua circle around the player
                    Utility.DrawCircle(Player.Position, Q.Range, Color.Aqua);
                }
                else
                {
                    // draw DarkRed circle around the player while on cd
                    Utility.DrawCircle(Player.Position, Q.Range, Color.DarkRed);
                }
            }

            private static void Ambush()
            {
                // check if the player wants to use E
                if (!Menu.Item("useQ").GetValue<bool>())
                    return;

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
