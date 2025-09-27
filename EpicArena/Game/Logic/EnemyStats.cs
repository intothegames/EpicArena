namespace TimeToBeEpic.Game.Logic
{
    public class EnemyStats
    {
        public int Health;
        public UnitStats? ClassUnitStats;
        public Weapon? ClassWeapon;
        public ILootable? ClassLoot;
        public List<IAbility>? ClassAbility;
    }
}