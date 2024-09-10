# Simple Object Pool

This package aims to add a simple object pool interface.
It uses a Factory interface that is used in the Object Pool to create more objects if needed (This means that this object pool can be expanded).

## Usage

1. Create a Scriptable Object which will be used by the Factory.

Example:
```C#
public class NoteConfig : ScriptableObject {
    public string note;
    public float volume;
}
```

2. Create a factory, which has to implement the interface `IFactory`:

Example:
```C#
public class NoteFactory : IFactory<NoteConfig>
    {
        private NoteConfig _creationConfig;

        public void SetConfig(NoteConfig config)
        {
            _creationConfig = config;
        }

        public GameObject CreateObject() 
        {
            GameObject instantiatedObject = GameObject.Instantiate();

            // Note in this example is just a script that uses the config
            instantiatedObject.AddComponent<Note>();
            Note note = instantiatedObject.getComponent<Note>();

            note.UseConfig(_creationConfig);

            return instantiatedObject;
        }
    }
```

3. Create a class that inherits the object pool, using a scriptable object config and a Factory.

Example:
```C#
public class NotePool : ObjectPool<NoteConfig, JumpCoinFactory> {}
```

4. Add the pool to an empty object in the scene. This object will now be a Singleton that will create Objects on demand.

Anywhere, you can use these methods to get or return an object to the pool:
```C#
GameObject note = NotePool.Instance.GetPooledObject();
NotePool.Instance.ReturnToPool(note);
```
