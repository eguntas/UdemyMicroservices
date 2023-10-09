using StackExchange.Redis;

namespace Basket.API.Services
{
    public class RedisService
    {
        private readonly string _host;
        private readonly int _port;
        private ConnectionMultiplexer _Conmultiplexer;
        public RedisService(string host , int port)
        {
            _host = host;
            _port = port;            
        }

        public void Connect() => _Conmultiplexer = ConnectionMultiplexer.Connect($"{_host}:{_port}");

        public IDatabase GetDb(int db = 1) => _Conmultiplexer.GetDatabase(db);  
    }
}

