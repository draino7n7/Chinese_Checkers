using UnityEngine;

namespace Utilities
{
    public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;

        // Public accessor for the Singleton instance
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    // Find the instance in the scene if it hasn't been assigned
                    instance = FindObjectOfType<T>();

                    // If no instance exists, create one
                    if (instance == null)
                    {
                        GameObject singletonObject = new GameObject(typeof(T).Name);
                        instance = singletonObject.AddComponent<T>();
                        DontDestroyOnLoad(singletonObject);  // Optional: persist across scenes
                    }
                }
                return instance;
            }
        }

        // Ensure that only one instance of the Singleton exists
        protected virtual void Awake()
        {
            if (instance == null)
            {
                instance = this as T;
                DontDestroyOnLoad(gameObject);  // Optional: persist across scenes
            }
            else if (instance != this)
            {
                Destroy(gameObject);  // Destroy any duplicate instances
            }
        }
    }
}
