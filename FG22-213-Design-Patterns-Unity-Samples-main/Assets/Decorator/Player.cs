using System.Collections.Generic;
using UnityEngine;

namespace Decorator
{
    public class FileCacheDecorator : IFileLoader
    {
        private IFileLoader _fileLoader;

        public FileCacheDecorator(IFileLoader fileLoader)
        {
            _fileLoader = fileLoader;
        }

        private Dictionary<string, object> cache = new Dictionary<string, object>();

        public T LoadFile<T>(string path)
        {
            if (cache.TryGetValue(path, out var obj))
            {
                return (T)obj;
            }

            var result = _fileLoader.LoadFile<T>(path);
            cache[path] = result;
            return result;
        }
    }
    
    public class FileDownloader : IFileLoader
    {
        public T LoadFile<T>(string path)
        {
            // complex code of loading files
            return default;
        }
    }
    
    public class FileLoader : IFileLoader
    {
        public T LoadFile<T>(string path)
        {
            // complex code of loading files
            return default;
        }
    }
    
    public interface IFileLoader
    {
        T LoadFile<T>(string path);
    }

    public class Main : MonoBehaviour
    {
        void Awake()
        {
            var gameManager = new GameManager(
                fileLoader: new FileCacheDecorator(new FileLoader()),
                health: new HealthLogger(new Health(3)),
                broker: null
            );
        }
    }

    public class GameManager
    {
        private IFileLoader _fileLoader;
        private IHealth _health;
        private IBroker _broker;

        public GameManager(IFileLoader fileLoader, IHealth health, IBroker broker)
        {
            _fileLoader = fileLoader;
            _health = health;
            _broker = broker;
        }
    }
    
    public class Player : MonoBehaviour
    {
        public IHealth Health;

        void Start()
        {
            Health = new HealthLogger(new Health(3));
        }
    }
}