using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderScript : MonoBehaviour {
    public Vector2 min;
    public Vector2 max;

    public static BorderScript borderScript;

    private void Awake() {
        borderScript = this;
    }

    void Start() {
        min = Camera.main.ViewportToWorldPoint(Vector3.zero);
        max = Camera.main.ViewportToWorldPoint(Vector3.one);
    }

    public void correctPosition(Transform obj, Vector2 size) {
        size = size / 2;
        Vector3 vector3 = obj.position;
        vector3.x = Mathf.Clamp(vector3.x, min.x + size.x, max.x - size.x);
        vector3.y = Mathf.Clamp(vector3.y, min.y + size.y, max.y - size.y);
        obj.position = vector3;
    }
}


