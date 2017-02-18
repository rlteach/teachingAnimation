using UnityEngine;
using System.Collections;

public class ChopperController : MonoBehaviour {


	Animator	mANI;
	Rigidbody	mRB;

	// Grab references to stuff we will need
	void Start () {
		mANI = GetComponent<Animator> ();
		mRB = GetComponent<Rigidbody> ();
		//mRB.centerOfMass=Vector3.down * 0.5f;		//Makes it more stable
	}


	void FixedUpdate () {
		float	tThrust = InputController.GetInput (InputController.Directions.Fire);
		float	tYaw = InputController.GetInput (InputController.Directions.MoveX);
		float	tPitch = InputController.GetInput (InputController.Directions.MoveY);
        if (tThrust > 0f) {
            mANI.SetBool("EngineOn", true);
        } else {
            //mANI.SetBool("EngineOn", false);
        }
        Vector3	tForce = Vector3.zero;
		tForce.y = -Physics.gravity.y * 1.2f  ;
		if (transform.position.y > 10f) {
			Vector3	tVelocity = mRB.velocity;	//Clamp Height
			tVelocity.y=0f;
			mRB.velocity = tVelocity;
		}
		tForce.x = -tPitch;
		tForce.z = tYaw;
		Debug.Log (tForce);
		//mRB.AddForce (tForce);		//Engine 1.5x G and depends on Rotor speed
	}

	void	LateUpdate () {
	}
}
