using UnityEngine;

public class Element : MonoBehaviour {
    [HideInInspector]
    public ElementType type;
    [HideInInspector]
    public Vector3 direction;
    [HideInInspector]
    public float speed;
    [HideInInspector]
    public Spawner spawner;
    [HideInInspector]
    public IConsumer consumer;
    
    private void Awake() {
        spawner = null;
        consumer = null;
    }
	
    private void Update() {
        if (consumer != null) {
            transform.position += (consumer.transform.position - transform.position).normalized * speed * Moment.Delta;
        }
        else {
            transform.position += direction * speed * Moment.Delta;
        }
    }
    
    public void Destroy() {
        Pool.Destroy(gameObject);
    }
    
    private void OnTriggerEnter2D(Collider2D collider) {
        if (this.consumer != null) {
            return;
        }
        
        var block = collider.GetComponent<Block>();
        if (block) {
            Destroy();
            return;
        }
        
        var spawner = collider.GetComponent<Spawner>();
        if (!spawner || spawner != this.spawner) {
            var consumer = collider.GetComponent<IConsumer>();
            if (consumer != null) {
                consumer.Consume(this);
                return;
            }
        }
        
        if (spawner && spawner != this.spawner) {
            Destroy();
            return;
        }
        
        var element = collider.GetComponent<Element>();
        if (element) {
			if (direction.x == element.direction.x || direction.y == element.direction.y) {
				element.Destroy ();
				Destroy ();
				return;
			}
        }
        
    }
}
