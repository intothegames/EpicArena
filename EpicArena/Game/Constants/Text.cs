namespace TimeToBeEpic.Game.Constants
{
    public record TextColor(string Text, ConsoleColor Color);
    static class Text
    {
        public static readonly ConsoleColor Background = ConsoleColor.Black;

        private static readonly ConsoleColor Hero = ConsoleColor.Green;
        private static readonly ConsoleColor Enemy = ConsoleColor.Red;
        private static readonly ConsoleColor Heading = ConsoleColor.DarkRed;
        private static readonly ConsoleColor Info = ConsoleColor.DarkGreen;
        private static readonly ConsoleColor Notification = ConsoleColor.DarkGray;
        private static readonly ConsoleColor Neutral = ConsoleColor.DarkGray;
        private static readonly ConsoleColor Loot = ConsoleColor.Cyan;
        private static readonly ConsoleColor InputWaiting = ConsoleColor.Yellow;
        private static readonly ConsoleColor Warning = ConsoleColor.DarkYellow;
        private static readonly ConsoleColor Question = ConsoleColor.DarkYellow;

        public static readonly TextColor WELCOME = new("WELCOME to EPIC ARENA", Heading);
        public static readonly TextColor START_ABILITIES = new("START ABILITIES", Notification);
        public static readonly TextColor RANDOM_STATS = new("  {0} Strenght    {1} Agility     {2} Stamina", Info);
        public static readonly TextColor CHOOSE_DESTINY = new("CHOOSE YOUR DESTINY", Question);
        public static readonly TextColor HERO_VARIANTS = new("  <- Rogue    v Warrior    -> Barbarian", InputWaiting);

        public static readonly TextColor LETS_EPIC_COMBAT_BEGIN = new("Let's EPIC COMBAT begin", Heading);
        //public static readonly TextColor AGILITY_COMPARE = new("{0} has {1} Agility and {2} has {3} Agility\n", Notification);
        public static readonly TextColor ROUND = new("ROUND {0}", Warning);
        public static readonly TextColor HERO_PRIORITY = new("{0} goes first!", Hero);
        public static readonly TextColor ENEMY_PRIORITY = new("{0} goes first!", Enemy);

        public static readonly TextColor HERO_BATTLE_STATS = new("{0}  {1}", Hero);
        public static readonly TextColor ENEMY_BATTLE_STATS = new("{0}  {1}", Enemy);
        public static readonly TextColor ATTACK_ZONE = new("   =====(!)=====   ", Neutral);

        public static readonly TextColor HERO_ATTACK = new("   =====({0})>>>>>   ", Hero);
        public static readonly TextColor HERO_MISS = new("   ===(MISS)>      ", Hero);
        public static readonly TextColor ENEMY_ATTACK = new("   <<<<<({0})=====   ", Enemy);
        public static readonly TextColor ENEMY_MISS = new("      <(MISS)===   ", Enemy);

        public static readonly TextColor CONGRATULATION = new("CONGRATULATION!!!", Warning);
        public static readonly TextColor ENEMY = new("{0}", Enemy);
        public static readonly TextColor HAS_BEEN_DEFEATED = new(" has been DEFEATED", Notification);

        public static readonly TextColor NEW_LEVEL_1_PART = new("Gained a new LEVEL!", Question);
        public static readonly TextColor NEW_LEVEL_2_PART = new("You can choose a new class", Notification);

        public static readonly TextColor NEW_WEAPON_1_PART = new("You found a ", Notification);
        public static readonly TextColor NEW_WEAPON_2_PART = new("{0}", Loot);
        public static readonly TextColor NEW_WEAPON_3_PART = new(" on the enemy's corpse!", Notification);
        public static readonly TextColor WANT_TO_CHANGE = new("Do you want to change your weapon to a new one?", Question);
        public static readonly TextColor NEW_WEAPON_CHOOSE = new("<- YES   -> NO", InputWaiting);

        public static readonly TextColor YOU_ARE_DEAD = new("YOU ARE DEAD", Heading);
        public static readonly TextColor PRESS_TO_RESTART = new("Press SPACE to one more try", InputWaiting);

        public static readonly TextColor WIN_GAME = new("AWESOME!!! You have defeated all the enemies", Warning);
        public static readonly TextColor GAME_OVER = new("GAME OVER", Heading);
    }
}