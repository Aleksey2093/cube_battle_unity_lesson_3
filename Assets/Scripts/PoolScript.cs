using System.Collections.Generic;
using UnityEngine;

public class PoolScript : MonoBehaviour {
    
    public int size;
    public float clearTimer;
    public float lastClear;
    public Queue<PoolItemScript> poolFree = new Queue<PoolItemScript>();

    void Update() {
        if (size < poolFree.Count && Time.time - lastClear > clearTimer) {
            while (poolFree.Count > size) {
                PoolItemScript poolItemScript = poolFree.Dequeue();
                Destroy(poolItemScript.gameObject);
            }
            lastClear = Time.time;
        }
    }

    public PoolItemScript getFree(PoolItemScript prefab) {
        PoolItemScript poolItemScript;
        if (poolFree.Count == 0) {
            poolItemScript = Instantiate(prefab,transform);
            poolItemScript.poolScript = this;
        }
        else {
            poolItemScript = poolFree.Dequeue();
        }
        return poolItemScript;
    }
}
