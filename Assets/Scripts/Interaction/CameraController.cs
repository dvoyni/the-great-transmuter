using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour {

    private Vector2 size;
    private Vector2 offset;
    
	private void Start() {
        var cells = GameObject.FindObjectsOfType<Cell>();
        
        var min = new Vector2(float.MaxValue, float.MaxValue);
        var max = new Vector2(float.MinValue, float.MinValue);
        for (var i = 0; i < cells.Length; i++) {
            min = Vector2.Min(min, cells[i].transform.position);
            max = Vector2.Max(max, cells[i].transform.position);
        }
        
        var extents = (Vector2)cells[0].GetComponent<SpriteRenderer>().bounds.extents;
        min -= extents;
        max += extents;
        
        size = max - min;
        offset = Vector2.Lerp(max, min, .5f);
    }
    
    private void Update() {
        float length = size.y;
        float calculatedWidth = length * Screen.width / Screen.height;
        if (calculatedWidth < size.x) {
            length = size.x * Screen.height / Screen.width;
        }
        
        var camera = GetComponent<Camera>();
        camera.orthographicSize = length * .5f;
        var pos = camera.transform.position;
        pos.x = +offset.x;
        pos.y = +offset.y;
        camera.transform.position = pos;
	}
}
