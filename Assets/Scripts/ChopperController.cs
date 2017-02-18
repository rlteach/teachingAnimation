using UnityEngine;
using System.Collections;

public class ChopperController : MonoBehaviour {


	Animator	mANI;
	Rigidbody	mRB;

	RotorProxy	mRP;		//Rotor Helper

	// Grab references to stuff we will need
	void Start () {
		mANI = GetComponent<Animator> ();
		mRB = GetComponent<Rigidbody> ();
		mRP = GetComponentInChildren<RotorProxy> (); //Get Reference to rotor helper
		mRB.centerOfMass=Vector3.down * 0.5f;		//Makes it more stable
	}


	void FixedUpdate () {
		float	tRotorSpeed = mRP.RotorSpeed/5.0f;
		float	tThrust = InputController.GetInput (InputController.Directions.Fire);
		float	tYaw = InputController.GetInput (InputController.Directions.MoveX);
		float	tPitch = InputController.GetInput (InputController.Directions.MoveY);
		mANI.SetBool ("EngineOn",(tThrust > 0f));
		//mRB.MoveRotation(Quaternion.Euler(tYaw*15f,0,tPitch*15f));
		Vector3	tForce = Vector3.zero;
		Debug.Log (tRotorSpeed);
		tForce.y = -Physics.gravity.y * 1.2f  * tRotorSpeed;
		if (transform.position.y > 10f) {
			Vector3	tVelocity = mRB.velocity;	//Clamp Height
			tVelocity.y=0f;
			mRB.velocity = tVelocity;
		}
		tForce.x = -tPitch * tRotorSpeed;
		tForce.z = tYaw	* tRotorSpeed;
		Debug.Log (tForce);
		mRB.AddForce (tForce);		//Engine 1.5x G and depends on Rotor speed
	}

	void	LateUpdate () {
	}
}
