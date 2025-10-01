using EpicArena.Game.Constants;
using EpicArena.Game.Logic;

namespace EpicArena.Game.Services
{
    public class ConsoleUI : UI
    {
        private readonly int consoleWidth = Console.WindowWidth;

        public override void Init()
        {
            Console.CursorVisible = false;
            Console.BackgroundColor = Text.Background;
            Console.Clear();
        }

        public override void ShowMainMenuScreen(UnitStats unitStats)
        {
            WriteLineOnCenter(Text.WELCOME);
            Console.WriteLine();
            WriteLineOnCenter(Text.START_ABILITIES);
            WriteLineOnCenter((Text.RANDOM_STATS, new object[] { unitStats[StatsType.Strength], unitStats[StatsType.Agility], unitStats[StatsType.Stamina]}));
            Console.WriteLine();
            WriteLineOnCenter(Text.CHOOSE_DESTINY);
            WriteLineOnCenter(Text.HERO_VARIANTS);
        }

        public override void ShowStartFightScreen(Hero hero, Enemy enemy, bool _isPlayerFirst, int round)
        {
            WriteLineOnCenter(Text.LETS_EPIC_COMBAT_BEGIN);

            Console.WriteLine();

            WriteLineOnCenter((Text.ROUND, new object[] { round }));

            if (_isPlayerFirst)
            {
                WriteLineOnCenter((Text.HERO_PRIORITY, new object[] { hero.HeroClasses[0].GetType().Name }));
                Console.WriteLine();
            }
            else
            {
                WriteLineOnCenter((Text.ENEMY_PRIORITY, new object[] { enemy.Type }));
                Console.WriteLine();
            }

            WriteLineOnCenter(
                (Text.HERO_BATTLE_STATS, new object[] { hero.Health, hero.HeroClasses[0].GetType().Name }),
                Text.ATTACK_ZONE,
                (Text.ENEMY_BATTLE_STATS, new object[] { enemy.Type, enemy.Health })
                );
            Console.WriteLine();

            PauseBetweenAttacks();
        }

        public override void ShowHeroAttack(Hero hero, int damage, Enemy enemy)
        {
            WriteLineOnCenter(
                (Text.HERO_BATTLE_STATS, new object[] { hero.Health, hero.HeroClasses[0].GetType().Name }),
                (Text.HERO_ATTACK, new object[] { damage }),
                (Text.ENEMY_BATTLE_STATS, new object[] { enemy.Type, enemy.Health })
                );

            PauseBetweenAttacks();
        }

        public override void ShowHeroMiss(Hero hero, Enemy enemy)
        {
            WriteLineOnCenter(
                (Text.HERO_BATTLE_STATS, new object[] { hero.Health, hero.HeroClasses[0].GetType().Name }),
                Text.HERO_MISS,
                (Text.ENEMY_BATTLE_STATS, new object[] { enemy.Type, enemy.Health })
                );

            PauseBetweenAttacks();
        }

        public override void ShowEnemyAttack(Hero hero, int damage, Enemy enemy)
        {
            WriteLineOnCenter(
                (Text.HERO_BATTLE_STATS, new object[] { hero.Health, hero.HeroClasses[0].GetType().Name }),
                (Text.ENEMY_ATTACK, new object[] { damage }),
                (Text.ENEMY_BATTLE_STATS, new object[] { enemy.Type, enemy.Health })
                );

            PauseBetweenAttacks();
        }

        public override void ShowEnemyMiss(Hero hero, Enemy enemy)
        {
            WriteLineOnCenter(
                (Text.HERO_BATTLE_STATS, new object[] { hero.Health, hero.HeroClasses[0].GetType().Name }),
                Text.ENEMY_MISS,
                (Text.ENEMY_BATTLE_STATS, new object[] { enemy.Type, enemy.Health })
                );

            PauseBetweenAttacks();
        }

        public override void ShowRoundWinScreen(Enemy enemy)
        {
            Console.WriteLine();
            WriteLineOnCenter(Text.CONGRATULATION);
            WriteLineOnCenter(
                (Text.ENEMY, new object[] { enemy.Type }),
                Text.HAS_BEEN_DEFEATED
                );
            Console.WriteLine();
        }

        public override void ShowGameWinScreen()
        {
            WriteLineOnCenter(Text.WIN_GAME);
            Console.WriteLine();
            WriteLineOnCenter(Text.PRESS_TO_RESTART);
        }

        public override void ShowGameOverScreen()
        {
            Console.WriteLine();
            WriteLineOnCenter(Text.GAME_OVER);
        }

        public override void ShowLevelUp()
        {
            WriteLineOnCenter(Text.NEW_LEVEL_1_PART);
            WriteLineOnCenter(Text.NEW_LEVEL_2_PART);
            Console.WriteLine();
            WriteLineOnCenter(Text.HERO_VARIANTS);
            Console.WriteLine();
        }

        public override void ShowWeaponChoose(Weapon weapon)
        {
            WriteLineOnCenter(
                Text.NEW_WEAPON_1_PART,
                (Text.NEW_WEAPON_2_PART, new object[] { weapon.GetType().Name }),
                Text.NEW_WEAPON_3_PART
                );
            WriteLineOnCenter(Text.WANT_TO_CHANGE);
            Console.WriteLine();
            WriteLineOnCenter(Text.NEW_WEAPON_CHOOSE);
        }

        public override void ShowRoundDefeatScreen()
        {
            Console.WriteLine();
            WriteLineOnCenter(Text.YOU_ARE_DEAD);
            Console.WriteLine();
            WriteLineOnCenter(Text.PRESS_TO_RESTART);
        }

        private void WriteLineOnCenter(params object[] items)
        {
            if (items == null || items.Length == 0) return;

            var segments = new List<(TextColor textColor, object[] args)>();

            foreach (var item in items)
            {
                switch (item)
                {
                    case TextColor textColor:
                        segments.Add((textColor, Array.Empty<object>()));
                        break;

                    case ValueTuple<TextColor, object[]> tuple:
                        segments.Add((tuple.Item1, tuple.Item2 ?? Array.Empty<object>()));
                        break;

                    default:
                        throw new ArgumentException($"Unsupported type: {item.GetType()}");
                }
            }

            string fullText = string
                .Join("", segments
                .Select(s => string
                .Format(s.textColor.Text, s.args ?? Array.Empty<object>())));

            int positionX = GetCenterForTextX(fullText);
            int positionY = Console.CursorTop;

            Console.SetCursorPosition(positionX, positionY);

            foreach (var (textColor, args) in segments)
            {
                string segmentText = string.Format(textColor.Text, args ?? Array.Empty<object>());
                Console.ForegroundColor = textColor.Color;
                Console.Write(segmentText);
            }

            Console.Write("\n");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private int GetCenterForTextX(string text)
        {
            int positionX = consoleWidth / 2 - text.Length / 2;
            return positionX;
        }

        private void PauseBetweenAttacks()
        {
            Thread.Sleep(Values.PAUSE_BETWEEN_ATTACKS * Values.IN_MILLISECONDS);
        }
    }
}