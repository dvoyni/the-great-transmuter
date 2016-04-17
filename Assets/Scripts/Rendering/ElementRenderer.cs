using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Element))]
[RequireComponent(typeof(SpriteRenderer))]
public class ElementRenderer : MonoBehaviour {
    public Sprite[] elementSprites;
    
    private SpriteRenderer spriteRenderer;
    private Element element;
    private ElementType type;
    
    private void Awake() {
        element = GetComponent<Element>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    private void Start() {
        Fill();
    }
	
    private void Update() {
        if (type != element.type) {
            Fill();
        }
    }
    
    private void Fill() {
        type = element.type;
        spriteRenderer.sprite = elementSprites[(int)type];
    }
}
