using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Rule {
    public ElementType[] input;
    public bool changeType;
    public ElementType output;
    public Vector3 direction;
    public float speed = 1;
    public bool speedMultiplier = true;
}

[RequireComponent(typeof(Spawner))]
public class Transmuter : MonoBehaviour, IConsumer {

    public Rule[] rules;
    public Element elementPrefab;
    
    private List<Element> consumed = new List<Element>();
    private Spawner spawner;
    
    private void Awake() {
        spawner = GetComponent<Spawner>();
    }
    
    public void Consume(Element element) {
        for (var i = 0; i < rules.Length; i++) {
            var rule = rules[i];
            
            if (rule.input.Length == 0) {
                ApplyRule(rule, element);
                element.consumer = this;
                consumed.Add(element);
                return;
            }
            
            if (System.Array.IndexOf(rule.input, element.type) != -1) {
                bool alreadyConsumed = false;
                for (var c = consumed.Count - 1; c >= 0; c--) {
                    var consumedElement = consumed[c];
                    if (consumedElement.type == element.type) {
                        alreadyConsumed = true;
                    }
                }
                if (alreadyConsumed) {
                    continue;
                }
                
                for (var c = consumed.Count - 1; c >= 0; c--) {
                    var consumedElement = consumed[c];
                    if (System.Array.IndexOf(rule.input, consumedElement.type) == -1) {
                        consumed.RemoveAt(c);
                        if (consumedElement) {
                            consumedElement.Destroy();
                        }
                    }
                }
                
                consumed.Add(element);
                element.consumer = this;
                
                if (consumed.Count == rule.input.Length) {
                    ApplyRule(rule, element);
                }
                return;
            }
        }
        
        if (element) {
            element.Destroy();
        }
    }
    
    private void ApplyRule(Rule rule, Element originalElement) {
        var speed = rule.speedMultiplier ? rule.speed * originalElement.speed : rule.speed;
        var type = rule.changeType ? rule.output : originalElement.type;
        var direction = rule.direction == Vector3.zero ? originalElement.direction : rule.direction;
        spawner.Spawn(type, direction, speed);
        
        Clear();
    }
    
    public void Clear() {
        for (var i = 0; i < consumed.Count; i++) {
            if (consumed[i]) {
                consumed[i].Destroy();
            }
        }
        consumed.Clear();
    }
}
