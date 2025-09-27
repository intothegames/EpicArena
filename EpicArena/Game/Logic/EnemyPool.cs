//using TimeToBeEpic.Game.Constants;
//using TimeToBeEpic.Game.Services;

//namespace TimeToBeEpic.Game.Logic
//{
//    public class EnemyPool : IGameService
//    {
//        private readonly Random _rnd = new();
//        private readonly List<Enemy> _enemyPool;

//        public EnemyPool()
//        {
//            _enemyPool = CreateAllEnemies();
//        }

//        //public Enemy GetRandomEnemy() => _enemyPool[_rnd.Next(_enemyPool.Count)];
//        public T GetRandomEnum<T>() where T : Enum
//        {
//            var values = Enum.GetValues(typeof(T));
//            return (T)values.GetValue(Random.Shared.Next(values.Length));
//        }

//        public Enemy GetRandomEnemy()
//        {
//            var enemyClasses = Enum.GetValues(typeof(EnemyType));
//            return (EnemyType)enemyClasses.GetValue(Random.Shared.Next(enemyClasses.Length));
//        }

//        public void ResetEnemy(Enemy enemy)
//        {
//            enemy = new Enemy(enemy.Type);
//        }

//        private List<Enemy> CreateAllEnemies()
//        {
//            return Enum.GetValues<EnemyType>()
//                       .Select(type => new Enemy(type))
//                       .ToList();
//        }
//    }
//}