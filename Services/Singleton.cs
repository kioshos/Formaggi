using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Formaggi.Model;
public interface ISession
{
    User User { get; }
}
namespace Formaggi.Services
{
    public class Singleton
    {
        private static Singleton _instance;
        private Session _session;

        internal struct Session : ISession
        {
            public User User { get; }

            public Session(User authorizedUser)
            {
                User = authorizedUser;
            }
        }

        public ISession CurrentSession
        {
            get => _session;
        }

        private Singleton(User client)
        {
            _session = new Session(client);
        }

        public static Singleton GetInstance()
        {
            if (_instance == null)
                throw new InvalidOperationException("SingletonSession has not been initialized.");

            return _instance;
        }

        public static void Initialize(User client)
        {
            if (_instance != null)
                throw new InvalidOperationException("SingletonSession has already been initialized.");

            _instance = new Singleton(client);
        }
    }
}
