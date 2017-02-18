using UnityEngine;
using System.Collections;

public class AnimationHelper : MonoBehaviour {

	protected	Animator	mAnimator;		//Reference for Animator
	protected	Rigidbody2D	mRB;			//Reference for RigidBody

	protected	virtual	void	Start() {
		mAnimator = GetComponent<Animator> ();
		mRB = GetComponent<Rigidbody2D> ();
	}

	public	virtual	void	Kill() {		//Usually called from animation
		Destroy (gameObject);
	}

	public	virtual	void	Explode() {		//Trigger default Explode Animation
		mAnimator.SetTrigger ("Explode");
	}

	void	OnTriggerEnter2D(Collider2D vOther) {	//Call correct trigger based on tag hit
		if (vOther.gameObject.tag == "Enemy") {
			OnHitEnemy(vOther.gameObject.GetComponent<InvaderController> ());
		} else 	if (vOther.gameObject.tag == "Player") {
			OnHitPlayer(vOther.gameObject.GetComponent<TankController> ());
		} else 	if (vOther.gameObject.tag == "Shell") {
			OnHitShell(vOther.gameObject.GetComponent<ShellController> ());
		}
	}
	protected virtual void OnHitEnemy(InvaderController vAH) {
	}
	protected virtual void OnHitPlayer(TankController vAH) {
	}
	protected virtual void OnHitShell(ShellController vAH) {
	}
}
