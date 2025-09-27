using TimeToBeEpic.Game.Logic;

namespace TimeToBeEpic.Game.Services
{
    public class ConsoleInput : Input
    {
        public override HeroClassType WaitForSelectHeroClass()
        {
            bool isInputAwaiting = true;

            ConsoleKeyInfo playerInput;
            HeroClassType heroSelected = HeroClassType.Unknown;

            while (isInputAwaiting)
            {
                if (Console.KeyAvailable)
                {
                    playerInput = Console.ReadKey(true);

                    switch (playerInput.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            heroSelected = HeroClassType.Rogue;
                            isInputAwaiting = false;
                            break;

                        case ConsoleKey.DownArrow:
                            heroSelected = HeroClassType.Warrior;
                            isInputAwaiting = false;
                            break;

                        case ConsoleKey.RightArrow:
                            heroSelected = HeroClassType.Barbarian;
                            isInputAwaiting = false;
                            break;

                        default:
                            Console.WriteLine("Wrong button pressed. Try again!");
                            break;
                    }

                }
            }
            return heroSelected;
        }

        public override bool WaitForRestart()
        {
            bool isInputAwaiting = true;
            bool isRestart = false;

            ConsoleKeyInfo playerInput;

            while (isInputAwaiting)
            {
                if (Console.KeyAvailable)
                {
                    playerInput = Console.ReadKey(true);

                    switch (playerInput.Key)
                    {
                        case ConsoleKey.Spacebar:
                            isRestart = true;
                            break;

                        default:
                            break;
                    }
                    isInputAwaiting = false;
                }
            }
            return isRestart;
        }
        public override bool WaitForChooseNewWeapon()
        {
            bool isInputAwaiting = true;
            bool isNew = false;

            ConsoleKeyInfo playerInput;

            while (isInputAwaiting)
            {
                if (Console.KeyAvailable)
                {
                    playerInput = Console.ReadKey(true);

                    switch (playerInput.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            isNew = true;
                            isInputAwaiting = false;
                            break;

                        case ConsoleKey.RightArrow:
                            isInputAwaiting = false;
                            break;

                        default:
                            Console.WriteLine("Wrong button pressed. Try again!");
                            break;
                    }
                }
            }
            return isNew;
        }
    }
}
