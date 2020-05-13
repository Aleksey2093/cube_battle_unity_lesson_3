using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolItemScript : MonoBehaviour {
public PoolScript poolScript;
	public float lastUse;
	void Awake() { lastUse = Time.time; }
	void OnEnable() { lastUse = Time.time; }
	void OnDisable() { 
		lastUse = Time.time;
		poolScript.poolFree.Enqueue(this);
	}
}
