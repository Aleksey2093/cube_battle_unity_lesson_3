using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOneScript : MonoBehaviour {

	public Rigidbody2D r2d;
	public Vector2 velocity;
	public float damage;
	public Animator animator;
	public float hp;

	void FixedUpdate() {
		r2d.velocity = velocity;
	}

	private PlayerControlScript player;
	
	void OnTriggerEnter2D(Collider2D other) {
		player = other.GetComponent<PlayerControlScript>();
		if (player != null && animator.GetBool("Attack") == false) {
			animator.SetBool("Attack", true);
		}
	}

	void attack() {
		if (player != null) {
			player.AddHp(damage);
		}
		player = null;
		gameObject.SetActive(false);
	}

	IEnumerator damageAnim() {
		while (animator.GetBool("Damage")) {
			yield return null;
		}
		if (this.hp <= 0) {
			gameObject.SetActive(false);
		}
	}

	public void AddHp(float value) {
		this.hp += value;
		if (value < 0 && animator.GetBool("Damage") == false) {
			animator.SetBool("Damage", true);
			StartCoroutine(damageAnim());
		}
	}
}
