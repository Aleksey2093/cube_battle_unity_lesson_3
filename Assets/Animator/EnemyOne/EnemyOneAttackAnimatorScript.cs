using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOneAttackAnimatorScript : StateMachineBehaviour {
	
	public Transform explosionPrefab;

	public Transform parentExp;
	
	void OnEnable() {
		parentExp = GameObject.Find("Explosions").transform;
	}

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if (parentExp == null) {
			parentExp = GameObject.Find("Explosions").transform;
		}
		Transform transform = Instantiate(explosionPrefab);
		transform.localPosition = animator.transform.localPosition;
		transform.gameObject.SetActive(true);
	}

	public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		animator.SetBool("Attack", false);
	}
}
