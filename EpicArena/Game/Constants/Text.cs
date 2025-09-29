using System.Diagnostics;
using System.Text.Json;

namespace TimeToBeEpic.Game.Constants
{
    public record TextColor(string Text, ConsoleColor Color);

    public class TextConfig
    {
        public Dictionary<string, string> Colors { get; set; } = new();
        public Dictionary<string, TextEntry> Texts { get; set; } = new();
    }

    public class TextEntry
    {
        public string Text { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
    }

    static class Text
    {
        private static readonly Dictionary<string, ConsoleColor> _colorMap = new();
        private static readonly Dictionary<string, TextColor> _texts = new();

        private static string TEXT_JSON_PATH = @"..\..\..\Game\Json\Text.json";

        static Text()
        {
            LoadTexts();
        }

        private static void LoadTexts()
        {
            try
            {
                string json = File.ReadAllText(TEXT_JSON_PATH);

                var config = JsonSerializer.Deserialize<TextConfig>(json);

                if (config?.Colors != null && config.Texts != null)
                {
                    foreach (var color in config.Colors)
                    {
                        if (Enum.TryParse<ConsoleColor>(color.Value, out ConsoleColor consoleColor))
                        {
                            _colorMap[color.Key] = consoleColor;
                        }
                    }

                    foreach (var text in config.Texts)
                    {
                        if (_colorMap.TryGetValue(text.Value.Color, out ConsoleColor color))
                        {
                            _texts[text.Key] = new TextColor(text.Value.Text, color);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Write($"Error loading texts: {ex.Message}");
            }
        }

        public static ConsoleColor Background => ConsoleColor.Black;

        public static TextColor WELCOME => GetText("WELCOME");
        public static TextColor START_ABILITIES => GetText("START_ABILITIES");
        public static TextColor RANDOM_STATS => GetText("RANDOM_STATS");
        public static TextColor CHOOSE_DESTINY => GetText("CHOOSE_DESTINY");
        public static TextColor HERO_VARIANTS => GetText("HERO_VARIANTS");
        public static TextColor LETS_EPIC_COMBAT_BEGIN => GetText("LETS_EPIC_COMBAT_BEGIN");
        public static TextColor ROUND => GetText("ROUND");
        public static TextColor HERO_PRIORITY => GetText("HERO_PRIORITY");
        public static TextColor ENEMY_PRIORITY => GetText("ENEMY_PRIORITY");
        public static TextColor HERO_BATTLE_STATS => GetText("HERO_BATTLE_STATS");
        public static TextColor ENEMY_BATTLE_STATS => GetText("ENEMY_BATTLE_STATS");
        public static TextColor ATTACK_ZONE => GetText("ATTACK_ZONE");
        public static TextColor HERO_ATTACK => GetText("HERO_ATTACK");
        public static TextColor HERO_MISS => GetText("HERO_MISS");
        public static TextColor ENEMY_ATTACK => GetText("ENEMY_ATTACK");
        public static TextColor ENEMY_MISS => GetText("ENEMY_MISS");
        public static TextColor CONGRATULATION => GetText("CONGRATULATION");
        public static TextColor ENEMY => GetText("ENEMY");
        public static TextColor HAS_BEEN_DEFEATED => GetText("HAS_BEEN_DEFEATED");
        public static TextColor NEW_LEVEL_1_PART => GetText("NEW_LEVEL_1_PART");
        public static TextColor NEW_LEVEL_2_PART => GetText("NEW_LEVEL_2_PART");
        public static TextColor NEW_WEAPON_1_PART => GetText("NEW_WEAPON_1_PART");
        public static TextColor NEW_WEAPON_2_PART => GetText("NEW_WEAPON_2_PART");
        public static TextColor NEW_WEAPON_3_PART => GetText("NEW_WEAPON_3_PART");
        public static TextColor WANT_TO_CHANGE => GetText("WANT_TO_CHANGE");
        public static TextColor NEW_WEAPON_CHOOSE => GetText("NEW_WEAPON_CHOOSE");
        public static TextColor YOU_ARE_DEAD => GetText("YOU_ARE_DEAD");
        public static TextColor PRESS_TO_RESTART => GetText("PRESS_TO_RESTART");
        public static TextColor WIN_GAME => GetText("WIN_GAME");
        public static TextColor GAME_OVER => GetText("GAME_OVER");

        private static TextColor GetText(string key)
        {
            return _texts.TryGetValue(key, out TextColor text) ?
                text : new TextColor($"MISSING: {key}", ConsoleColor.White);
        }
    }
}