using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(CellAligned))]
[RequireComponent(typeof(Cell))]
public class CellRenderer : MonoBehaviour {

    public Sprite[] sprites;

    private void Start() {
        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
    }
}
