using UnityEngine;
using System.Collections;

public class PitchRoll : StateMachineBehaviour {



	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        DoPitchRoll(animator);
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
	}
    void DoPitchRoll(Animator vAni) {
        Vector2 tPitchRollTarget = new Vector2(vAni.GetFloat("Pitch"), vAni.GetFloat("Roll"));
        Vector2 tPitchRollNow = new Vector2(vAni.gameObject.transform.rotation.eulerAngles.x, vAni.gameObject.transform.rotation.eulerAngles.z);
        float tRate = vAni.GetFloat("Rate");
        Vector2 tCurrent = Vector2.Lerp(tPitchRollNow, tPitchRollTarget, tRate * Time.deltaTime);
        vAni.gameObject.transform.rotation = Quaternion.Euler(tCurrent.x, 0, tCurrent.y);

        Debug.Log(tCurrent);
    }
}
