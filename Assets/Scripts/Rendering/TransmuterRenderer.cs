using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Transmuter))]
public class TransmuterRenderer : MonoBehaviour {

    public MultiRuleRenderer multiruleRenderer;
    
    private void Awake() {
        multiruleRenderer.info = GetComponent<Transmuter>().rules;
    }
}
