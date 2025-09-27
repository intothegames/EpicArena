namespace TimeToBeEpic.Game.Services
{
    public class GameServices
    {
        private Dictionary<Type, IGameService> _globalServices = new Dictionary<Type, IGameService>();

        public void AddService<T>(IGameService service) where T : IGameService
        {
            if (typeof(T) == null || service == null)
                throw new ArgumentNullException(typeof(T).ToString());

            _globalServices[typeof(T)] = service;
        }

        public IGameService? GetService<T>() where T : IGameService
        {
            _globalServices.TryGetValue(typeof(T), out IGameService? service);

            if (service == null)
            {
                _globalServices.TryGetValue(typeof(T), out IGameService? baseService);
                return baseService;
            }

            return service;
        }
    }
}