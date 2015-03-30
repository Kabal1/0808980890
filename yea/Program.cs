using System;
using System.Linq;
using LeagueSharp;
using LeagueSharp.Common;
using Color = System.Drawing.Color;

class Program
{
    // declare shorthandle to access the player object
    // Properties http://msdn.microsoft.com/en-us/library/aa288470%28v=vs.71%29.aspx 
    private static Obj_AI_Hero Player { get { return ObjectManager.Player; } }

    // declare orbwalker class
    private static Orbwalking.Orbwalker Orbwalker;

    // declare  list of spells
    private static Spell W;


    // declare menu
    private static Menu Menu;


    /// <summary>
    /// Default programm entrypoint, gets called once on programm creation
    /// </summary>
    static void Main(string[] args)
    {
        // Events http://msdn.microsoft.com/en-us/library/edzehd2t%28v=vs.110%29.aspx
        // OnGameLoad event, gets fired after loading screen is over
        CustomEvents.Game.OnGameLoad += Game_OnGameLoad;
    }

    /// <summary>
    /// Game Loaded Method
    /// </summary>
    private static void Game_OnGameLoad(EventArgs args)
    {
        if (Player.ChampionName != "Twitch") // check if the current champion is Nunu
            return; // stop programm

        // the Spell class provides methods to check and cast Spells
        // Constructor Spell(SpellSlot slot, float range)
        W = new Spell(SpellSlot.W, 950); // create Q spell with a range of 125 units

        // set spells prediction values, not used on Nunu
        // Method Spell.SetSkillshot(float delay, float width, float speed, bool collision, SkillshotType type)
        // Q.SetSkillshot(0.25f, 80f, 1800f, false, SkillshotType.SkillshotLine);

        // create root menu
        // Constructor Menu(string displayName, string name, bool root)
        Menu = new Menu(Player.ChampionName, Player.ChampionName, true);

        // create and add submenu 'Orbwalker'
        // Menu.AddSubMenu(Menu menu) returns added Menu
        Menu orbwalkerMenu = Menu.AddSubMenu(new Menu("Orbwalker", "Orbwalker"));

        // creates Orbwalker object and attach to orbwalkerMenu
        // Constructor Orbwalking.Orbwalker(Menu menu);
        Orbwalker = new Orbwalking.Orbwalker(orbwalkerMenu);

        // create submenu for TargetSelector used by Orbwalker
        Menu ts = Menu.AddSubMenu(new Menu("Target Selector", "Target Selector")); ;

        // attach
        TargetSelector.AddToMenu(ts);

        //Spells menu
        Menu spellMenu = Menu.AddSubMenu(new Menu("Spells", "Spells"));

        // Menu.AddItem(MenuItem item) returns added MenuItem
        // Constructor MenuItem(string name, string displayName)
        // .SetValue(true) on/off button
        spellMenu.AddItem(new MenuItem("useW", "Use W").SetValue(true));

        // attach to 'Sift/F9' Menu
        Menu.AddToMainMenu();


        // subscribe to Update event gets called every game update around 10ms
        Game.OnUpdate += Game_OnUpdate;

        // print text in local chat
        Game.PrintChat("Welcome to Twitch2");
    }

    /// <summary>
    /// Main Update Method
    /// </summary>
    private static void Game_OnUpdate(EventArgs args)
    {
        // dont do stuff while dead
        if (Player.IsDead)
            return;

        // checks the current Orbwalker mode Combo/Mixed/LaneClear/LastHit
        if (Orbwalker.ActiveMode == Orbwalking.OrbwalkingMode.Combo)
        {
            // combo to kill the enemy
            VenomCask();
        }
    }

    /// <summary>
    /// Main Draw Method
    /// </summary

    /// <summary>
    /// Consume logic
    /// </summary>

    private static void VenomCask()
    {
        // check if the player wants to use R
        if (!Menu.Item("useQ").GetValue<bool>())
            return;

        // fast lane clear
        // use Nunu Q to clear the lane faster
        if (W.IsReady()) // check if Qready
        {
            W.CastOnUnit(Player);
        }
    }
}
