using UnityEngine;
using System.Collections;

public class ChopperButton : MonoBehaviour {

	Animator	mAni;
	int			mBoolKey;

	void	Start() {
		mAni = GetComponent<Animator> ();
		mBoolKey = Animator.StringToHash ("Power");		//Get power Hash, faster
	}

	public	void	Power() {
		mAni.SetBool (mBoolKey, !mAni.GetBool (mBoolKey));
	}
}
