using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
    
    public static GameController Instance { get; private set; }
    
    public bool Won { get; private set; }
    
    private Consumer[] consumers;
    private Draggable[] dragables;
    
    private void Awake() {
        Instance = this;
    }
    
    private void Start() {
        consumers = GameObject.FindObjectsOfType<Consumer>();
        dragables = GameObject.FindObjectsOfType<Draggable>();
    }
	
	private void Update () {
        if (!Won) {
            Won = consumers.Length > 0;
            for (var i = 0; i < consumers.Length; i++) {
                Won = Won && (consumers[i].Value >= 1);
            }
        }
        if (!Won) {
            for (var i = 0; i < dragables.Length; i++) {
                if (dragables[i].Dragging) {
                    for (var j = 0; j < consumers.Length; j++) {
                        consumers[j].Reset();
                    }
                    break;
                }
            }
        }
	}
}
