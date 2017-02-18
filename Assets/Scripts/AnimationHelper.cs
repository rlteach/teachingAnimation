using UnityEngine;
using System.Collections;

public class AnimationHelper : MonoBehaviour {

	protected	Animator	mAnimator;		//Reference for Animator
	protected	Rigidbody2D	mRB;			//Reference for RigidBody

	protected	virtual	void	Start() {
		mAnimator = GetComponent<Animator> ();
		mRB = GetComponent<Rigidbody2D> ();
//		Invoke ("TestTrigger",Random.Range(1f,5f));
	}

	void	TestTrigger() {
		mAnimator.SetTrigger ("Explode");
	}

	public	void	Kill() {
		Destroy (gameObject);
	}
}
