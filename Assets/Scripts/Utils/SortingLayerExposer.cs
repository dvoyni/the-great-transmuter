using UnityEngine;

[ExecuteInEditMode]
public class SortingLayerExposer: MonoBehaviour {
    public string sortingLayerName = "Default";
    public int sortingOrder = 0;
    
    private string currentLayerName;
    private int currentOrder;

    public void Start() {
        SetLayer();
        SetOrder();
    }
    
    public void Update() {
        if (currentLayerName != sortingLayerName) {
            SetLayer();
        }
        
        if (currentOrder != sortingOrder) {
            SetOrder();
        }
    }
    
    private void SetLayer() {
        gameObject.GetComponent<MeshRenderer>().sortingLayerName = sortingLayerName;
        currentLayerName = sortingLayerName;
    }
    
    private void SetOrder() {
        gameObject.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;
        currentOrder = sortingOrder;
    }
}
