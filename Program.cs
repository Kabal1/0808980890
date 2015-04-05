using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp;
using LeagueSharp.Common;
using LeagueSharp.Common.Data;
using SharpDX;
using Color = System.Drawing.Color;

namespace Draven
{
    class Program
    {
        private static Obj_AI_Hero Player { get { return ObjectManager.Player; } }

        public static Orbwalking.Orbwalker Orbwalker;

        public static Spell Q, W, E, R;

        public static Menu Menu;


        public static float Rcount;
        static void Main(string[] args)
        {
            CustomEvents.Game.OnGameLoad += Game_OnGameLoad;
        }
        private static void Game_OnGameLoad(EventArgs args)
        {
            if (Player.ChampionName != "Graves")
                return;

            Q = new Spell(SpellSlot.Q);
            W = new Spell(SpellSlot.W);
            E = new Spell(SpellSlot.E, 1050);
            R = new Spell(SpellSlot.R);
            Q.SetSkillshot(250, 130, 1400, false, SkillshotType.SkillshotLine);
            R.SetSkillshot(400, 160, 2000, false, SkillshotType.SkillshotLine);

            Menu = new Menu(Player.ChampionName, Player.ChampionName, true);
            Menu orbwalkerMenu = new Menu("Orbwalker", "Orbwalker");
            Orbwalker = new Orbwalking.Orbwalker(orbwalkerMenu);
            Menu.AddSubMenu(orbwalkerMenu);
            Menu ts = Menu.AddSubMenu(new Menu("Target Selector", "Target Selector")); ;
            TargetSelector.AddToMenu(ts);
            Menu spellMenu = Menu.AddSubMenu(new Menu("Spells", "Spells"));

            Menu Harass = spellMenu.AddSubMenu(new Menu("Harass", "Harass"));

            Menu Combo = spellMenu.AddSubMenu(new Menu("Combo", "Combo"));

            Menu LaneClear = spellMenu.AddSubMenu(new Menu("LaneClear", "LaneClear"));

            Menu JungClear = spellMenu.AddSubMenu(new Menu("JungClear", "JungClear"));

            Combo.AddItem(new MenuItem("Use Q Combo", "Use Q Combo").SetValue(true));
            Menu.AddToMainMenu();

            Game.OnUpdate += Game_OnGameUpdate;
            Game.PrintChat("11d");
        }

        public static void Game_OnGameUpdate(EventArgs args)
        {
            //checkbuff();
            if (Orbwalker.ActiveMode == Orbwalking.OrbwalkingMode.Combo)
            {
                Combo();
                Game.PrintChat("2");
            }
            if (Orbwalker.ActiveMode == Orbwalking.OrbwalkingMode.Mixed)
            {

            }
            if (Orbwalker.ActiveMode == Orbwalking.OrbwalkingMode.LaneClear)
            {

            }
        }

        static void Combo()
        {
            Q.Cast(Game.CursorPos)
            Game.PrintChat("e");
        }
    }

}
