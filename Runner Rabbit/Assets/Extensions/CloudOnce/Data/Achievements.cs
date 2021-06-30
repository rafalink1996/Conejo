// <copyright file="Achievements.cs" company="Jan Ivar Z. Carlsen, Sindri Jóelsson">
// Copyright (c) 2016 Jan Ivar Z. Carlsen, Sindri Jóelsson. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace CloudOnce
{
    using System.Collections.Generic;
    using Internal;

    /// <summary>
    /// Provides access to achievements registered via the CloudOnce Editor.
    /// This file was automatically generated by CloudOnce. Do not edit.
    /// </summary>
    public static class Achievements
    {
        private static readonly UnifiedAchievement s_dungeonBone = new UnifiedAchievement("DungeonBone",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "com.DungeonBone.Magicbound"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            "CgkInLWCwIIQEAIQAw"
#else
            "DungeonBone"
#endif
            );

        public static UnifiedAchievement DungeonBone
        {
            get { return s_dungeonBone; }
        }

        private static readonly UnifiedAchievement s_libraryFlame = new UnifiedAchievement("LibraryFlame",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "com.LibraryFlame.Magicbound"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            "CgkInLWCwIIQEAIQAg"
#else
            "LibraryFlame"
#endif
            );

        public static UnifiedAchievement LibraryFlame
        {
            get { return s_libraryFlame; }
        }

        private static readonly UnifiedAchievement s_frostCrystal = new UnifiedAchievement("FrostCrystal",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "com.FrostCrystal.Magicound"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            "CgkInLWCwIIQEAIQBA"
#else
            "FrostCrystal"
#endif
            );

        public static UnifiedAchievement FrostCrystal
        {
            get { return s_frostCrystal; }
        }

        private static readonly UnifiedAchievement s_sharpLeaf = new UnifiedAchievement("SharpLeaf",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "com.SharpLeaf.Magicbound"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            "CgkInLWCwIIQEAIQBQ"
#else
            "SharpLeaf"
#endif
            );

        public static UnifiedAchievement SharpLeaf
        {
            get { return s_sharpLeaf; }
        }

        private static readonly UnifiedAchievement s_spinningCog = new UnifiedAchievement("SpinningCog",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "com.SpinningCog.Magicbound"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            "CgkInLWCwIIQEAIQBg"
#else
            "SpinningCog"
#endif
            );

        public static UnifiedAchievement SpinningCog
        {
            get { return s_spinningCog; }
        }

        private static readonly UnifiedAchievement s_endGame = new UnifiedAchievement("EndGame",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "com.EndGame.Magicbound"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            "CgkInLWCwIIQEAIQBw"
#else
            "EndGame"
#endif
            );

        public static UnifiedAchievement EndGame
        {
            get { return s_endGame; }
        }

        private static readonly UnifiedAchievement s_monsterHunter = new UnifiedAchievement("MonsterHunter",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "com.MonsterHunter.Magicbound"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            "550426942108"
#else
            "MonsterHunter"
#endif
            );

        public static UnifiedAchievement MonsterHunter
        {
            get { return s_monsterHunter; }
        }

        private static readonly UnifiedAchievement s_rich = new UnifiedAchievement("Rich",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "com.Rich.Magicbound"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            "CgkInLWCwIIQEAIQCA"
#else
            "Rich"
#endif
            );

        public static UnifiedAchievement Rich
        {
            get { return s_rich; }
        }

        private static readonly UnifiedAchievement s_necessaryExpenses = new UnifiedAchievement("NecessaryExpenses",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "com.NecessaryExpenses.Magicbound"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            "CgkInLWCwIIQEAIQDg"
#else
            "NecessaryExpenses"
#endif
            );

        public static UnifiedAchievement NecessaryExpenses
        {
            get { return s_necessaryExpenses; }
        }

        private static readonly UnifiedAchievement s_poweredUp = new UnifiedAchievement("PoweredUp",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "com.PoweredUp.Magicbound"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            "CgkInLWCwIIQEAIQCQ"
#else
            "PoweredUp"
#endif
            );

        public static UnifiedAchievement PoweredUp
        {
            get { return s_poweredUp; }
        }

        private static readonly UnifiedAchievement s_thatsNotHowItHappened = new UnifiedAchievement("ThatsNotHowItHappened",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "com.notHowItHappened.Magicbound"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            "CgkInLWCwIIQEAIQDw"
#else
            "ThatsNotHowItHappened"
#endif
            );

        public static UnifiedAchievement ThatsNotHowItHappened
        {
            get { return s_thatsNotHowItHappened; }
        }

        private static readonly UnifiedAchievement s_flawlessBoss = new UnifiedAchievement("FlawlessBoss",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "com.FlawlessBoss.Magicbound"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            "CgkInLWCwIIQEAIQEA"
#else
            "FlawlessBoss"
#endif
            );

        public static UnifiedAchievement FlawlessBoss
        {
            get { return s_flawlessBoss; }
        }

        private static readonly UnifiedAchievement s_crystalHoarder = new UnifiedAchievement("CrystalHoarder",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "com.CrystalHoarder.Magicbound"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            "CgkInLWCwIIQEAIQCg"
#else
            "CrystalHoarder"
#endif
            );

        public static UnifiedAchievement CrystalHoarder
        {
            get { return s_crystalHoarder; }
        }

        private static readonly UnifiedAchievement s_spellMaster = new UnifiedAchievement("SpellMaster",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "com.SpellMaster.Magicbound"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            "CgkInLWCwIIQEAIQCw"
#else
            "SpellMaster"
#endif
            );

        public static UnifiedAchievement SpellMaster
        {
            get { return s_spellMaster; }
        }

        private static readonly UnifiedAchievement s_ultimateMage = new UnifiedAchievement("UltimateMage",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "com.UltimateMage.Magicbound"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            "CgkInLWCwIIQEAIQDA"
#else
            "UltimateMage"
#endif
            );

        public static UnifiedAchievement UltimateMage
        {
            get { return s_ultimateMage; }
        }

        public static readonly UnifiedAchievement[] All =
        {
            s_dungeonBone,
            s_libraryFlame,
            s_frostCrystal,
            s_sharpLeaf,
            s_spinningCog,
            s_endGame,
            s_monsterHunter,
            s_rich,
            s_necessaryExpenses,
            s_poweredUp,
            s_thatsNotHowItHappened,
            s_flawlessBoss,
            s_crystalHoarder,
            s_spellMaster,
            s_ultimateMage,
        };

        public static string GetPlatformID(string internalId)
        {
            return s_achievementDictionary.ContainsKey(internalId)
                ? s_achievementDictionary[internalId].ID
                : string.Empty;
        }

        private static readonly Dictionary<string, UnifiedAchievement> s_achievementDictionary = new Dictionary<string, UnifiedAchievement>
        {
            { "DungeonBone", s_dungeonBone },
            { "LibraryFlame", s_libraryFlame },
            { "FrostCrystal", s_frostCrystal },
            { "SharpLeaf", s_sharpLeaf },
            { "SpinningCog", s_spinningCog },
            { "EndGame", s_endGame },
            { "MonsterHunter", s_monsterHunter },
            { "Rich", s_rich },
            { "NecessaryExpenses", s_necessaryExpenses },
            { "PoweredUp", s_poweredUp },
            { "ThatsNotHowItHappened", s_thatsNotHowItHappened },
            { "FlawlessBoss", s_flawlessBoss },
            { "CrystalHoarder", s_crystalHoarder },
            { "SpellMaster", s_spellMaster },
            { "UltimateMage", s_ultimateMage }
        };
    }
}
