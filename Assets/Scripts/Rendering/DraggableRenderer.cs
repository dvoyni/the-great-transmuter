using UnityEngine;

[RequireComponent(typeof(Draggable))]
public class DraggableRenderer : MonoBehaviour {
    public GameObject decoratorPrefab;

    private void Start() {
        Instantiate(decoratorPrefab).transform.SetParent(transform, false);
    }
}
