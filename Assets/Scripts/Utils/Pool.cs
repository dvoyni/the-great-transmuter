using UnityEngine;

public static class Pool {

    public static T Instantiate<T>(T prefab) where T: Object {
        return Object.Instantiate(prefab);
    }
    
    public static void Destroy<T>(T instance) where T: Object {
        if (instance) {
            Object.Destroy(instance);
        }
    }
}
