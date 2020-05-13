using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerControlScript : MonoBehaviour {
    public SpriteRenderer spriteRender;
    public Rigidbody2D r2d;
    public float speed;
    public BoltScript boltScriptPrefab;
    public PoolScript boltPoolScript;
    public float lastFire;

    public float hp = 10;
    
    void Update() {
        float fire1 = Input.GetAxis("Fire1");
        if (fire1 > 0 && Time.time - lastFire > 0.1f) {
            BoltScript boltScript = (BoltScript)boltPoolScript.getFree(boltScriptPrefab);
            boltScript.Fire(transform.localPosition,Vector2.right);
            lastFire = Time.time;
        }
        BorderScript.borderScript.correctPosition(transform,spriteRender.size);
    }

    void FixedUpdate() {
        float x = Input.GetAxis("Horizontal") * speed;
        float y = Input.GetAxis("Vertical") * speed;
        Vector2 vector2 = new Vector2(x, y);
        r2d.velocity = Vector2.ClampMagnitude(vector2, speed);
    }

    public void AddHp(float value) {
        this.hp += value;
    }
}
