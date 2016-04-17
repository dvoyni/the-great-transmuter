using UnityEngine;
using System.Collections;

public class RuleRenderer : MonoBehaviour {
    public ElementIconRenderer elementIconPrefab;
    public ElementIconInfo[] info;
    public SpriteRenderer background;
    public Transform childHolder;
    
    private bool built;
	
	private void Start() {
        if (!built) {
            Build();
        }
    }
    
    private void Build() {
        var offset = 0f;
        var totalWidth = 0f;
        var maxHeight = 0f;
        
        for (var i = 0; i < info.Length; i++) {
            var elementIconObject = Instantiate(elementIconPrefab.gameObject);
            var elementIcon = elementIconObject.GetComponent<ElementIconRenderer>();
            elementIcon.info = info[i];
            
            var size = elementIconObject.GetComponent<SpriteRenderer>().bounds.size;
            var width = size.x;
            maxHeight = Mathf.Max(maxHeight, size.y);
            if (i == 0) {
                offset += .5f * width;
            }
            
            elementIconObject.transform.SetParent(childHolder);
            elementIconObject.transform.localPosition = new Vector3(offset, 0, 0);
            offset += width;
            totalWidth += width;
        }
        
        background.transform.localScale = new Vector3(
            (totalWidth + 0.06f) / background.sprite.texture.width * 100,
            (maxHeight + 0.06f) / background.sprite.texture.height * 100,
            1);
        
        var e = childHolder.GetEnumerator();
        totalWidth *= .5f;
        while (e.MoveNext()) {
            var tf = e.Current as Transform;
            var pos = tf.localPosition;
            pos.x -= totalWidth;
            tf.localPosition = pos;
        }
        
        built = true;
	}
    
    public Vector2 Size {
        get {
            if (!built) {
                Build();
            }
            return background.bounds.size;
        }
    }
}
