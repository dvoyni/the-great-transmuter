using UnityEngine;

[RequireComponent(typeof(Spawner))]
public class IntervalSpawner : MonoBehaviour {
    
    public float delay;
    public float interval;
    public Vector3 direction;
    public float speed;
    public ElementType[] types;

    private Spawner spawner;
    private int spawnIndex;
    
    private void Awake() {
        spawner = GetComponent<Spawner>();
    }

    private void Update() {
        var nextSpawnTime = spawnIndex * interval + delay;

        if (Moment.CurrentTime >= nextSpawnTime) {
            spawner.Spawn(types[spawnIndex % types.Length], direction, speed);
            spawnIndex++;
        }
    }
}
