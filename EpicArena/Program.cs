using TimeToBeEpic.Game;

namespace TimeToBeEpic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BootStrap bootStrap = new BootStrap();

            bootStrap.Init();
            bootStrap.StartGame();
        }
    }
}