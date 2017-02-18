using UnityEngine;
using System.Collections;

public class InvaderController : AnimationHelper {

	// Use this for initialization
	protected	override	void Start () {
		base.Start ();		//Ensure Base method is called
	}

	public	void	Explode() {
		mAnimator.SetTrigger ("Explode");
	}
}
