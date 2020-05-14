using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOneDamageAnimatorScript : StateMachineBehaviour {

	public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		animator.SetBool("Damage", false);
	}
}
