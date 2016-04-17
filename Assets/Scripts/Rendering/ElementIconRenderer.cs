using UnityEngine;
using System.Collections;

[System.Serializable]
public class ElementIconInfo {
    public bool arrow;
    public Vector2 direction;
    public bool anyType;
    public ElementType type;
}

[RequireComponent(typeof(SpriteRenderer))]
public class ElementIconRenderer : MonoBehaviour {

    public Sprite[] elementSprites;
    public Sprite anyElement;
    public Sprite arrowSprite;
    public Sprite anyArrow;
    public ElementIconInfo info;

    private void Start() {
        Sprite sprite;
        if (info.arrow) {
            transform.rotation = Quaternion.identity;
            if (info.direction == Vector2.zero) {
                sprite = anyArrow;
            }
            else {
                sprite = arrowSprite;
                transform.Rotate(Vector3.forward, Mathf.Rad2Deg * Mathf.Atan2(info.direction.y, info.direction.x));
            }
        }
        else {
            if (info.anyType) {
                sprite = anyElement;
            }
            else {
                sprite = elementSprites[(int)info.type];
            }
        }
        GetComponent<SpriteRenderer>().sprite = sprite;
    }
}
