using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Constants;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Rendering;
using SharpDX;
using Mario_s_Lib;
using static RoninKassadin.Menus;
using EloBuddy.SDK.Menu;
using static RoninKassadin.SpellsManager;

//using Settings = RoninTune.Modes.Flee

namespace RoninKassadin.Modes
{
    internal class Flee
    {
        public static readonly AIHeroClient Player = ObjectManager.Player;
        public static void Execute()
        {

            if (R.IsReady())
            {
                R.Cast(Game.CursorPos);
            }
            //if (R.IsReady())
            //{
            //    R.Cast(Player.ServerPosition.Extend(Game.CursorPos, W.Range).To3D());
            //}
        }
    }
}



