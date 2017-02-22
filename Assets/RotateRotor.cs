using UnityEngine;
using System.Collections;

public class RotateRotor : StateMachineBehaviour {


    public float RotorMaxSpeed;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
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
//        Debug.Log(vAni.GetBool("Running").ToString() + ":" +  tRotorSpeed.ToString());
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
