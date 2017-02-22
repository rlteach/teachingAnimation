using UnityEngine;
using System.Collections;

public class RotateRotor : StateMachineBehaviour {

	AudioSource	mAud;

    public float RotorMaxSpeed;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		mAud = animator.gameObject.GetComponent<AudioSource> ();
        DoRotor(animator);
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        DoRotor(animator);
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        DoRotor(animator);
    }
    void DoRotor(Animator vAni) {
        float tRotorSpeed = vAni.GetFloat("RotorSpeed");
        float tRotorForce =vAni.GetFloat("RotorForce");
        tRotorSpeed = Mathf.Clamp(tRotorSpeed + tRotorForce, 0f, RotorMaxSpeed);
        vAni.SetFloat("RotorSpeed", tRotorSpeed);
        Quaternion tStep = Quaternion.Euler(0, tRotorSpeed * Time.deltaTime, 0);
        vAni.gameObject.transform.rotation*= tStep;
		PlayRotorAudio (tRotorSpeed);
//        Debug.Log(vAni.GetBool("Running").ToString() + ":" +  tRotorSpeed.ToString());
    }

	void	PlayRotorAudio(float vRotorSpeed) {
		if (vRotorSpeed < 100f) {
			if (vRotorSpeed > 1) {
				mAud.volume = vRotorSpeed/100f;
			} else {
				if (mAud.isPlaying) {
					mAud.Stop ();
				}
			}
		} else {
			mAud.volume = 1f;
			if (!mAud.isPlaying) {
				mAud.Play ();
			}
			mAud.pitch = Mathf.Clamp (2 * vRotorSpeed / RotorMaxSpeed, 0.3f, 2f);
		}

	}


    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}
