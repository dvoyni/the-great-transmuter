using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CellAligned))]
public class Draggable : MonoBehaviour {
    
    public bool Dragging { get; private set; }
    
    private Vector3 lastPosition;
    private Vector3 lastMousePos;
    private CellAligned cellAligned;
    private Transmuter transmuter;
   
    private void Awake() {
        cellAligned = GetComponent<CellAligned>();
        transmuter = GetComponent<Transmuter>();
    }
    
    private void Start() {
        lastPosition = transform.position;
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit2D[] hits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity);
            
            for (var i = 0; i < hits.Length; i++) {
                if (hits[i].collider.gameObject == gameObject) {
                    lastMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Dragging = true;
                    break;
                }
            }
        }
        
        if (Dragging) {
            if (transmuter) {
                transmuter.Clear();
            }
            
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var delta = mousePos - lastMousePos;
            transform.position = lastPosition + delta;
            cellAligned.FixPosition();
        }
        
        if (Dragging && Input.GetMouseButtonUp(0)) {
            RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector2.zero, Mathf.Infinity);
            var cellExists = false;
            var blocked = false;

            for (var i = 0; i < hits.Length; i++) {
                var hit = hits[i];
                if (hit.collider.GetComponent<Cell>()) {
                    cellExists = true;
                }
                else if (!hit.collider.GetComponent<Element>() && (hit.collider.gameObject != gameObject)) {
                    blocked = true;
                }
            }
            if (cellExists && !blocked) {
                lastPosition = transform.position;
            }
            else {
                transform.position = lastPosition;
            }
            Dragging = false;
        }
    }	
}
