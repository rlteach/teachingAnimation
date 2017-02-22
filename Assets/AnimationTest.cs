using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AnimationTest : MonoBehaviour {

	public	Text	DebugText;

	public	float			RotorForce;
	public	float			RotorMaxSpeed;
	public	GameObject		RotorGO;

	float	RotorSpeed;

	Animator	mANI;

	// Use this for initialization
	void Start () {
		mANI = GetComponent<Animator> ();	
	}
	
	// Update is called once per frame
	void Update () {
		RotorSpeed = Mathf.Clamp (RotorSpeed + RotorForce, 0f, RotorMaxSpeed);
		mANI.SetFloat ("RotorSpeed", RotorSpeed);
		RotorGO.transform.Rotate(0, RotorSpeed * Time.deltaTime, 0);
		DebugText.text=string.Format("Force {0:f2} Speed {1:f2}",RotorForce,RotorSpeed);
	}
}
