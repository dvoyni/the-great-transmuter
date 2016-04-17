using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class CellAligned : MonoBehaviour {
    
    public Vector3 step = Vector3.one;

    private void Start() {
        FixPosition();
    }
    
    #if UNITY_EDITOR
	private void Update() {
        if (!Application.isPlaying) {
            FixPosition();
        }
	}
    #endif
    
    public void FixPosition() {
        var position = transform.position;
        position.x = Mathf.Round(position.x / step.x) * step.x;
        position.y = Mathf.Round(position.y / step.y) * step.y;
        position.z = Mathf.Round(position.z / step.z) * step.z;
        transform.position = position;
    }
}
