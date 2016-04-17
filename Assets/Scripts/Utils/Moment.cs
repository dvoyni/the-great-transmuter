using UnityEngine;
using System.Collections;

public static class Moment {
    
    public static float Delta {
        get {
            return Time.deltaTime;
        }
    }
    
    public static float CurrentTime {
        get {
            return Time.timeSinceLevelLoad;
        }
    }
}
