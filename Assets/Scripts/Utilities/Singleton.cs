namespace Utilities
{
    public class Singleton<T> where T : class, new()
    {
        private static readonly object lockObject = new object();
        private static T instance;

        // Public accessor for the Singleton instance
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new T();
                        }
                    }
                }
                return instance;
            }
        }

        // Optional: Protected constructor to prevent external instantiation
        protected Singleton() { }
    }
}
