using UnityEngine;
using System.Collections;

public class MoveIt : StateMachineBehaviour {
	Vector3	Direction(Animator vAnimator) {
		Vector3	tMoveVector = Vector3.zero;
		int tDirection = vAnimator.GetInteger ("Direction");
		float	tSpeed = Mathf.Abs (vAnimator.GetFloat ("Speed"));
		tMoveVector = vAnimator.gameObject.transform.rotation * Vector3.up * Time.deltaTime * tSpeed*tDirection;
		return	tMoveVector;
	}

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		animator.gameObject.transform.position += Direction(animator);
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		animator.gameObject.transform.position += Direction(animator);
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		animator.gameObject.transform.position += Direction(animator);
	}
}
