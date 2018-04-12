using System.Collections.Generic;

namespace Assets.Core
{
    public class Achievements
    {
        public const string FirstGame = "Played your first game!";
        public const string FirstKill = "Killed your first enemy!";
        public const string FirstLevelComplete = "Level 1 complete!";
        public const string FirstDeath = "Experienced your first death!";

        private static readonly List<string> achievementList = new List<string>();

        static Achievements()
        {
            achievementList.Add(FirstGame);
            achievementList.Add(FirstKill);
            achievementList.Add(FirstLevelComplete);
            achievementList.Add(FirstDeath);
        }

        public static List<string> GetAchievements()
        {
            return achievementList;
        }
    }
}