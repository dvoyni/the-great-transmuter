using UnityEngine;
using System.Collections;

public class MultiRuleRenderer : MonoBehaviour {
    public RuleRenderer ruleRendererPrefab;
    public Rule[] info;

    private void Start() {
        var offset = 0f;
        var totalHeight = 0f;

        for (var i = 0; i < info.Length; i++) {
            var ruleRendererObject = Instantiate(ruleRendererPrefab.gameObject);
            var ruleRenderer = ruleRendererObject.GetComponent<RuleRenderer>();
            var rule = info[i];
            ruleRenderer.info = new ElementIconInfo[Mathf.Max(1, rule.input.Length) + 2];
            
            var index = 0;
            if (rule.input.Length == 0) {
                ruleRenderer.info[index++] = new ElementIconInfo {
                    anyType = true
                };
            }
            else {
                for (var j = 0; j < rule.input.Length; j++) {
                    ruleRenderer.info[index++] = new ElementIconInfo {
                        type = rule.input[j]
                    };
                }
            }
            
            ruleRenderer.info[index++] = new ElementIconInfo {
                arrow = true,
                direction = rule.direction
            };
            
            ruleRenderer.info[index++] = new ElementIconInfo {
                anyType = (!rule.changeType && rule.input.Length == 1) ? false : ! rule.changeType,
                type = (!rule.changeType && rule.input.Length == 1) ? rule.input[0] : rule.output 
            };

            var height = ruleRenderer.Size.y;
            if (i == 0) {
                offset += .5f * height;
            }

            ruleRendererObject.transform.SetParent(transform);
            ruleRendererObject.transform.localPosition = new Vector3(0, -offset, 0);
            offset += height;
            totalHeight += height;
        }

        var e = transform.GetEnumerator();
        totalHeight *= .5f;
        while (e.MoveNext()) {
            var tf = e.Current as Transform;
            var pos = tf.localPosition;
            pos.y += totalHeight;
            tf.localPosition = pos;
        }
    }
}
