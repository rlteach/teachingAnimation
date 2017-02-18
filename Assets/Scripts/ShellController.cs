using UnityEngine;
using System.Collections;

public class ShellController : AnimationHelper {

	// Use this for initialization
	protected	override	void Start () {
		base.Start ();		//Ensure Base method is called
		mAnimator.SetFloat ("Speed",2.5f);
		mAnimator.SetInteger ("Direction",1);
	}

	protected override void OnHitEnemy(InvaderController vAH) {
		vAH.Explode ();		//Tell Enemy to explode
	}
}
