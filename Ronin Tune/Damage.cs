using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
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
using static RoninTune.Menus;
using static RoninTune.SpellsManager;

namespace RoninTune
{
    class Damage
    {

        public static float SmiteDamage(Obj_AI_Base target)
        {
            if (target.IsValidTarget() && Smite.IsReady())
            {
                if (target is AIHeroClient)
                {
                    if (SmiteManager.CanUseOnChamp)
                    {
                        return Player.Instance.GetSummonerSpellDamage(target, DamageLibrary.SummonerSpells.Smite);
                    }
                }
                else
                {
                    return (int)(new int[] { 390, 410, 430, 450, 480, 510, 540, 570, 600, 640, 680, 720, 760, 800, 850, 900, 950, 1000 }[Player.Instance.Level]);
                }
            }
            return 0;
        }
    }
        }

            
