using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
    
    public Element elementPrefab;
    
    public void Spawn(ElementType type, Vector3 direction, float speed) {
        var elementObject = Pool.Instantiate(elementPrefab.gameObject);
        var element = elementObject.GetComponent<Element>();
        element.direction = direction;
        element.speed = speed;
        element.type = type;
        element.spawner = this;
        element.transform.position = transform.position;
    }
}
