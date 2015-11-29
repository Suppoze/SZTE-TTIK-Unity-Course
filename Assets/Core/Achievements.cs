using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Core {
    public class Achievements {

        public const string FIRST_GAME = "Played your first game!";
        public const string FIRST_KILL = "Killed your first enemy!";
        public const string FIRST_LEVEL_COMPLETE = "Level 1 complete!";
        public const string FIRST_DEATH = "Experienced your first death!";

        private static List<string> achievementList = new List<string>();

        static Achievements() {
            achievementList.Add(FIRST_GAME);
            achievementList.Add(FIRST_KILL);
            achievementList.Add(FIRST_LEVEL_COMPLETE);
            achievementList.Add(FIRST_DEATH);
        }

        public static List<string> GetAchievements() {
            return achievementList;
        }

    }
}
