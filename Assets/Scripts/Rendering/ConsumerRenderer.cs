using UnityEngine;

[RequireComponent(typeof(Consumer))]
public class ConsumerRenderer : MonoBehaviour {
    public TextMesh text;
    public RuleRenderer ruleRenderer;
    
    private Consumer consumer;
    private float value;
        
    private void Awake() {
        consumer = GetComponent<Consumer>();
        
        ruleRenderer.info = new ElementIconInfo[consumer.items.Length];
        for (var i = 0; i < consumer.items.Length; i++) {
            ruleRenderer.info[i] = new ElementIconInfo {
                type = consumer.items[i].type
            };
        }
    }
    
    private void Update() {
        if (value != consumer.Value) {
            value = consumer.Value;
            text.text = string.Format("{0}%", Mathf.Clamp(Mathf.RoundToInt(value * 100), 0, 100));
        }
    }

}
