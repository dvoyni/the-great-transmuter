using UnityEngine;
using System.Collections;

[System.Serializable]
public class ConsumerItem {
    public ElementType type;
    public int count;
    [System.NonSerialized]
    public int consumed;
}

public class Consumer : MonoBehaviour, IConsumer {
    public ConsumerItem[] items;

    public float Value { get; private set; }
    
    public void Consume(Element element) {
        var consumed = false;
        for (var i = 0; i < items.Length; i++) {
            var item = items[i];
            if (item.type == element.type) {
                item.consumed = Mathf.Clamp(item.consumed + 1, 0, item.count);
                consumed = true;
                break;
            }
        }
        
        if (!consumed) {
            Reset();
        }
        
        element.Destroy();
        
        var total = 0f;
        var consumeAmount = 0f;

        for (var i = 0; i < items.Length; i++) {
            var item = items[i];
            total += item.count;
            consumeAmount += item.consumed;
        }

        Value = consumeAmount / total;
    }
    
    public void Reset() {
        for (var i = 0; i < items.Length; i++) {
            var item = items[i];
            item.consumed = 0;
        }
        Value = 0;
    }
}
