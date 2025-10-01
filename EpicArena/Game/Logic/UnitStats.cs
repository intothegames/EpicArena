namespace EpicArena.Game.Logic
{
    public enum StatsType
    {
        Strength,
        Agility,
        Stamina
    }

    public class UnitStats
    {
        private int[] _stats = new int[Enum.GetValues(typeof(StatsType)).Length];

        public int this[StatsType stat]
        {
            get => _stats[(int)stat];
            set => _stats[(int)stat] = value;
        }
    }
}