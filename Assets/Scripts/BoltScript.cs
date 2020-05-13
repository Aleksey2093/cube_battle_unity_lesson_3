using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltScript : PoolItemScript {
	public Rigidbody2D r2d;
	public float speed;
	public Vector2 velocity;
	public float timeEnable;
	public float life;
	public float damage;

	void Update() {
		if (Time.time - timeEnable > life) {
			timeEnable = Time.time;
			gameObject.SetActive(false);
		}
	}

	void FixedUpdate() {
		r2d.velocity = velocity;
	}

	void OnTriggerEnter2D(Collider2D other) {
		EnemyOneScript enemy = other.GetComponent<EnemyOneScript>();
		if (enemy != null) {
			enemy.AddHp(-damage);
			timeEnable = Time.time;
			gameObject.SetActive(false);
		}
	}

	public void Fire(Vector2 position, Vector2 target) {
		transform.localPosition = position;
		velocity = target * speed;
		timeEnable = Time.time;
		gameObject.SetActive(true);
	}
}

