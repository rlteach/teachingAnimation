using UnityEngine;
using System.Collections;

public class ShellController : AnimationHelper {

	// Use this for initialization
	protected	override	void Start () {
		base.Start ();		//Ensure Base method is called
		mAnimator.SetFloat ("Speed",2.5f);
		mAnimator.SetInteger ("Direction",1);
	}

	void	OnTriggerEnter2D(Collider2D vOther) {
		if (vOther.gameObject.tag == "Enemy") {
			InvaderController tSC = vOther.gameObject.GetComponent<InvaderController> ();
			tSC.Explode ();
		}
	}
}
