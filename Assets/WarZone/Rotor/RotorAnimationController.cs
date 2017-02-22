using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RotorAnimationController : MonoBehaviour {


	public	Text	DebugText;

	public	float			RotorForce;			//Force applied to Rotor

	public	float			RotorMaxSpeed;		//Current Rotor Speed

	float	RotorSpeed;			//Current Speed

	Animator	mANI;

	// Use this for initialization
	void Start () {
		mANI = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		mANI.SetBool ("Running", (InputController.GetInput (InputController.Directions.Thrust) > 0f));
		RotorSpeed = Mathf.Clamp (RotorSpeed + RotorForce, 0f, RotorMaxSpeed);
		mANI.SetFloat ("RotorSpeed", RotorSpeed);
		transform.Rotate(0, RotorSpeed * Time.deltaTime, 0);
		DebugText.text=string.Format("Force {0:f2} Speed {1:f2}",RotorForce,RotorSpeed);
	}
}
